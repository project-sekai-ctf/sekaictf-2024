pragma solidity 0.8.25;

import "@openzeppelin/contracts/token/ERC20/ERC20.sol";

contract MockToken is ERC20 {
    constructor(string memory name_, string memory symbol_, uint amount)
        ERC20(name_, symbol_)
    {
        _mint(msg.sender, amount);
    }
}