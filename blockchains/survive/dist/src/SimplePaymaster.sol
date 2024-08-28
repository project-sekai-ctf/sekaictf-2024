pragma solidity 0.8.25;

import "@openzeppelin/contracts/token/ERC20/extensions/IERC20Metadata.sol";
import "@openzeppelin/contracts/token/ERC20/utils/SafeERC20.sol";
import "@openzeppelin/contracts/utils/cryptography/EIP712.sol";

import "@account-abstraction/contracts/interfaces/IEntryPoint.sol";
import "@account-abstraction/contracts/core/BasePaymaster.sol";
import "@v2-periphery/contracts/interfaces/IUniswapV2Router02.sol";

interface IUniswapV2Pair {
    function getReserves() external view returns (uint112 reserve0, uint112 reserve1, uint32 blockTimestampLast);
}

/// @title Simple ERC-20 Token Paymaster for ERC-4337
/// This Paymaster covers gas fees in exchange for ERC20 tokens charged using allowance pre-issued by ERC-4337 accounts.
/// The contract refunds excess tokens if the actual gas cost is lower than the initially provided amount.
/// The token price cannot be queried in the validation code due to storage access restrictions of ERC-4337.
/// The price is cached inside the contract and is updated in the 'postOp' stage if the change is >10%.
/// It is theoretically possible the token has depreciated so much since the last 'postOp' the refund becomes negative.
/// The contract reverts the inner user transaction in that case but keeps the charge.
/// The contract also allows honest clients to prepay tokens at a higher price to avoid getting reverted.
/// It also allows updating price configuration and withdrawing tokens by the contract owner.
/// The contract uses an Oracle to fetch the latest token prices.
/// @dev Inherits from BasePaymaster.
contract SimplePaymaster is BasePaymaster {

    using UserOperationLib for PackedUserOperation;

    event UserOperationSponsored(
        address indexed user, uint256 actualTokenCharge, uint256 actualGasCost, uint256 actualTokenPrice
    );
    event PostOpReverted(address indexed user, uint256 preCharge);

    /// @notice All 'price' variables are multiplied by this value to avoid rounding up
    uint256 private constant PRICE_DENOMINATOR = 1e26;

    IUniswapV2Router02 public constant UniswapV2Router02 =
        IUniswapV2Router02(0x7a250d5630B4cF539739dF2C5dAcb4c659F2488D);

    /// @notice The ERC20 token used for transaction fee payments
    IERC20 public immutable token;

    /// @notice The ERC-20 token that wraps the native asset for current chain
    IERC20 public immutable mockWETH;

    /// @notice The cached token price from the UniV2pair, always in (native-asset-per-token) * PRICE_DENOMINATOR format
    uint256 public cachedPrice;

    /// @notice The price markup percentage applied to the token price (1e26 = 100%). Ranges from 1e26 to 2e26
    uint256 public priceMarkup;

    /// @notice Estimated gas cost for refunding tokens after the transaction is completed
    uint48 public refundPostopCost;

    address public pair;

    mapping (address => uint) balances;

    /// @notice Initializes the TokenPaymaster contract with the given parameters.
    /// @param _token The ERC20 token used for transaction fee payments.
    /// @param _entryPoint The EntryPoint contract used in the Account Abstraction infrastructure.
    /// @param _mockWETH The ERC-20 token that wraps the native asset for current chain.
    /// @param _owner The address that will be set as the owner of the contract.
    constructor(IERC20Metadata _token, IEntryPoint _entryPoint, IERC20 _mockWETH, address _owner, address _pair)
        BasePaymaster(_entryPoint)
    {
        token = _token;
        mockWETH = _mockWETH;
        priceMarkup = 12e25; // 120%
        refundPostopCost = 100000; // transfer
        pair = _pair;
        transferOwnership(_owner);
    }

    /// @notice Deposits tokens that a specific account can use to pay for gas.
    function depositFor(address account, uint256 amount) external {
        SafeERC20.safeTransferFrom(token, msg.sender, account, amount);
        balances[account] += amount;
    }

    /// @notice Validates a paymaster user operation and calculates the required token amount for the transaction.
    /// @param userOp The user operation data.
    /// @param requiredPreFund The maximum cost (in native token) the paymaster has to prefund.
    /// @return context The context containing the token amount and user sender address (if applicable).
    /// @return validationResult A uint256 value indicating the result of the validation (always 0 in this implementation).
    function _validatePaymasterUserOp(PackedUserOperation calldata userOp, bytes32, uint256 requiredPreFund)
        internal
        override
        returns (bytes memory context, uint256 validationResult)
    {
        unchecked {
            uint256 maxFeePerGas = userOp.unpackMaxFeePerGas();
            require(refundPostopCost < userOp.unpackPostOpGasLimit(), "TPM: postOpGasLimit too low");
            uint256 preChargeNative = requiredPreFund + (refundPostopCost * maxFeePerGas);
            uint256 cachedPriceWithMarkup = cachedPrice * PRICE_DENOMINATOR / priceMarkup;

            uint256 tokenAmount = weiToToken(preChargeNative, cachedPriceWithMarkup);

            balances[userOp.sender] -= tokenAmount;
            context = abi.encode(tokenAmount, userOp.sender);
            validationResult = 0;
        }
    }

    /// @notice Performs post-operation tasks, such as updating the token price and refunding excess tokens.
    /// @dev This function is called after a user operation has been executed or reverted.
    /// @param context The context containing the token amount and user sender address.
    /// @param actualGasCost The actual gas cost of the transaction.
    /// @param actualUserOpFeePerGas - the gas price this UserOp pays. This value is based on the UserOp's maxFeePerGas
    //      and maxPriorityFee (and basefee)
    //      It is not the same as tx.gasprice, which is what the bundler pays.
    function _postOp(PostOpMode mode, bytes calldata context, uint256 actualGasCost, uint256 actualUserOpFeePerGas) internal override {
        unchecked {
            (
                uint256 preCharge,
                address userOpSender
            ) = abi.decode(context, (uint256, address));

            if (mode == PostOpMode.postOpReverted) {
                emit PostOpReverted(userOpSender, preCharge);
                // Do nothing here to not revert the whole bundle and harm reputation
                return;
            }            

            uint256 _cachedPrice = updateCachedPrice();
            // note: as price is in native-asset-per-token and we want more tokens increasing it means dividing it by markup
            uint256 cachedPriceWithMarkup = _cachedPrice * PRICE_DENOMINATOR / priceMarkup;
            // Refund tokens based on actual gas cost
            uint256 actualChargeNative = actualGasCost + refundPostopCost * actualUserOpFeePerGas;
            uint256 actualTokenNeeded = weiToToken(actualChargeNative, cachedPriceWithMarkup);
            if (preCharge > actualTokenNeeded) {
                // If the initially provided token amount is greater than the actual amount needed, refund the difference
                balances[userOpSender] += preCharge - actualTokenNeeded;
            } else if (preCharge < actualTokenNeeded) {
                // Attempt to cover Paymaster's gas expenses by withdrawing the 'overdraft' from the client
                // If the transfer reverts also revert the 'postOp' to remove the incentive to cheat
                SafeERC20.safeTransferFrom(
                    token,
                    userOpSender,
                    address(this),
                    actualTokenNeeded - preCharge
                );
            }

            emit UserOperationSponsored(userOpSender, actualTokenNeeded, actualGasCost, _cachedPrice);

            // Not supported yet :(
            // refillEntryPointDeposit();
        }
    }

    function updateCachedPrice() public returns (uint256) {
        // This function updates the cached ERC20/mockETH price ratio from pair
        (address token0,) = sortTokens(address(token), address(mockWETH));
        (uint256 reserve0, uint256 reserve1,) = IUniswapV2Pair(pair).getReserves();
        (uint256 reserveToken, uint256 reserveNative) =
            address(token) == token0 ? (reserve0, reserve1) : (reserve1, reserve0);
        require(reserveToken != 0, "reserveToken is zero");
        return cachedPrice = reserveNative * PRICE_DENOMINATOR / reserveToken;
    }

    function weiToToken(uint256 amount, uint256 price) public pure returns (uint256) {
        return amount * PRICE_DENOMINATOR / price;
    }

    function sortTokens(address tokenA, address tokenB) internal pure returns (address token0, address token1) {
        require(tokenA != tokenB, "UniswapV2Library: IDENTICAL_ADDRESSES");
        (token0, token1) = tokenA < tokenB ? (tokenA, tokenB) : (tokenB, tokenA);
        require(token0 != address(0), "UniswapV2Library: ZERO_ADDRESS");
    }
}
