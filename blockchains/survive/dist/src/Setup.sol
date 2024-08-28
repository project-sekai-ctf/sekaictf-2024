pragma solidity 0.8.25;

import { EntryPoint } from "@account-abstraction/contracts/core/EntryPoint.sol";
import { MockToken } from "./MockToken.sol";
import { SimplePaymaster } from "./SimplePaymaster.sol";
import { SimpleAccountFactory } from "@account-abstraction/contracts/samples/SimpleAccountFactory.sol";

import { IEntryPoint } from "@account-abstraction/contracts/interfaces/IEntryPoint.sol";
import "@openzeppelin/contracts/interfaces/IERC20.sol";
import "@v2-periphery/contracts/interfaces/IUniswapV2Router02.sol";

interface IUniswapV2Factory {
    function createPair(address tokenA, address tokenB) external returns (address pair);
}

contract Setup {

    IUniswapV2Router02 constant public router = IUniswapV2Router02(0x7a250d5630B4cF539739dF2C5dAcb4c659F2488D);

    SimplePaymaster immutable public paymaster;
    SimpleAccountFactory immutable public accountFactory;
    address immutable public account;

    address immutable challenger;

    constructor(address _challenger) payable {
        MockToken token = new MockToken("USDT", "USDT", 2 ether);
        MockToken weth = new MockToken("WETH", "WETH", 1 ether);

        address factory = router.factory();
        address pair = IUniswapV2Factory(factory).createPair(address(token), address(weth));
        token.approve(address(router), type(uint256).max);
        weth.approve(address(router), type(uint256).max);
        router.addLiquidity(
            address(token), address(weth), 1 ether, 1 ether, 1 ether, 1 ether, address(this), block.timestamp
        );

        IEntryPoint entryPoint = new EntryPoint();
        SimplePaymaster _paymaster = new SimplePaymaster(
            token,
            entryPoint,
            weth,
            _challenger,
            pair
        );
        _paymaster.updateCachedPrice();

        require(msg.value == 20 ether);
        entryPoint.depositTo{value: 20 ether}(address(_paymaster));

        accountFactory = new SimpleAccountFactory(entryPoint);
        account = accountFactory.getAddress(_challenger, 0);
        token.approve(address(_paymaster), type(uint256).max);
        _paymaster.depositFor(address(account), 1 ether);

        paymaster = _paymaster;
        challenger = _challenger;
    }

    function isSolved() external view returns (bool) {
        return challenger.balance > 19 ether;
    }
}