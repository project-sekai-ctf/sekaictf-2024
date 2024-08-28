import json
from pathlib import Path

import eth_sandbox
from web3 import Web3


def deploy(web3: Web3, deployer_address: str, player_address: str) -> str:
    rcpt = eth_sandbox.sendTransaction(
        web3,
        {
            "from": deployer_address,
            "data": json.loads(
                Path("/home/ctf/compiled/Setup.sol/Setup.json").read_text()
            )["bytecode"]["object"] + player_address[2:].zfill(64),
            "value": Web3.to_wei(20, "ether"),
        },
    )

    return rcpt.contractAddress


eth_sandbox.run_launcher(
    [
        eth_sandbox.new_launch_instance_action(deploy),
        eth_sandbox.new_bundle_action(),
        eth_sandbox.new_kill_instance_action(),
        eth_sandbox.new_get_flag_action(),
    ]
)
