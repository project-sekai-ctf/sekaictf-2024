import json
import os
import time
from dataclasses import dataclass
from typing import Callable, Dict, List, Optional
from uuid import uuid4, UUID

import requests
from eth_account import Account
from web3 import Web3
from web3.exceptions import TransactionNotFound
from web3.types import TxReceipt
from .ticket import Challenge

from eth_sandbox import get_shared_secret

HTTP_PORT = os.getenv("HTTP_PORT", "8545")
PUBLIC_IP = os.getenv("PUBLIC_IP", "127.0.0.1")

PLAYER_VALUE = int(os.getenv("PLAYER_VALUE", "1"))
FLAG = os.getenv("FLAG", "SEKAI{place-holder}")

Account.enable_unaudited_hdwallet_features()

@dataclass
class Action:
    name: str
    handler: Callable[[], int]


def sendTransaction(web3: Web3, tx: Dict) -> Optional[TxReceipt]:
    if "gas" not in tx:
        tx["gas"] = 15_000_000

    if "gasPrice" not in tx:
        tx["gasPrice"] = 0

    txhash = web3.eth.send_transaction(tx)

    while True:
        try:
            rcpt = web3.eth.get_transaction_receipt(txhash)
            break
        except TransactionNotFound:
            time.sleep(0.1)

    if rcpt.status != 1:
        raise Exception("failed to send transaction")

    return rcpt


def new_launch_instance_action(
    do_deploy: Callable[[Web3, str], str],
):
    def action() -> int:
        
        challenge = Challenge.generate_challenge(5000)
        print(f"curl -sSfL https://pwn.red/pow | sh -s {str(challenge)}")
        solution = input("solution please: ")
        is_valid = challenge.check(solution)
        if not is_valid:
            print("invalid solution!")
            return 1
        uuid = str(uuid4())

        data = requests.post(
            f"http://127.0.0.1:{HTTP_PORT}/new",
            headers={
                "Authorization": f"Bearer {get_shared_secret()}",
                "Content-Type": "application/json",
            },
            data=json.dumps(
                {
                    "uuid": uuid,
                }
            ),
        ).json()

        if data["ok"] == False:
            print(data["message"])
            return 1

        mnemonic = data["mnemonic"]
        
        deployer_acct = Account.from_mnemonic(mnemonic, account_path=f"m/44'/60'/0'/0/0")
        player_acct = Account.from_mnemonic(mnemonic, account_path=f"m/44'/60'/0'/0/1")

        web3 = Web3(Web3.HTTPProvider(
            f"http://127.0.0.1:{HTTP_PORT}/{uuid}",
            request_kwargs={
                "headers": {
                    "Authorization": f"Bearer {get_shared_secret()}",
                    "Content-Type": "application/json",
                },
            },
        ))

        player_balance = web3.eth.get_balance(player_acct.address)
        if player_balance > web3.to_wei(PLAYER_VALUE, "ether"):
            value_to_send = player_balance - web3.to_wei(PLAYER_VALUE, "ether")

            raw_transaction = {
                "nonce": web3.eth.get_transaction_count(player_acct.address),
                "gasPrice": 0,
                "gas": 21000,  # gas limit - 21000 is the intrinsic gas for transaction
                "to": deployer_acct.address,
                "value": value_to_send,
            }

            signed_transaction = web3.eth.account.sign_transaction(
                raw_transaction, player_acct.key
            )

            tx_hash = web3.eth.send_raw_transaction(signed_transaction.rawTransaction)

            web3.eth.wait_for_transaction_receipt(tx_hash)

        setup_addr = do_deploy(web3, deployer_acct.address, player_acct.address)

        with open(f"/tmp/{uuid}", "w") as f:
            f.write(
                json.dumps(
                    {
                        "uuid": uuid,
                        "mnemonic": mnemonic,
                        "address": setup_addr,
                    }
                )
            )

        print()
        print(f"your private blockchain has been deployed")
        print(f"it will automatically terminate in 30 minutes")
        print(f"here's some useful information")
        print(f"uuid:           {uuid}")
        print(f"rpc endpoint:   https://{PUBLIC_IP}/{uuid}")
        print(f"private key:    {player_acct.key.hex()}")
        print(f"your address:   {player_acct.address}")
        print(f"setup contract: {setup_addr}")
        return 0

    return Action(name="launch new instance", handler=action)


def new_kill_instance_action():
    def action() -> int:
        uuid = check_uuid(input("uuid please: "))
        if not uuid:
            print("invalid uuid!")
            return 1

        data = requests.post(
            f"http://127.0.0.1:{HTTP_PORT}/kill",
            headers={
                "Authorization": f"Bearer {get_shared_secret()}",
                "Content-Type": "application/json",
            },
            data=json.dumps(
                {
                    "uuid": uuid,
                }
            ),
        ).json()

        print(data["message"])
        return 1

    return Action(name="kill instance", handler=action)

def is_solved_checker(web3: Web3, addr: str) -> bool:
    result = web3.eth.call(
        {
            "to": addr,
            "data": web3.keccak(text="isSolved()")[:4],
        }
    )
    return int(result.hex(), 16) == 1

def check_uuid(uuid) -> bool:
    try:
        UUID(uuid)
        return uuid
    except Exception:
        return None

def new_get_flag_action(
    checker: Callable[[Web3, str], bool] = is_solved_checker,
):
    def action() -> int:
        uuid = check_uuid(input("uuid please: "))
        if not uuid:
            print("invalid uuid!")
            return 1

        try:
            with open(f"/tmp/{uuid}", "r") as f:
                data = json.loads(f.read())
        except:
            print("bad uuid")
            return 1

        web3 = Web3(Web3.HTTPProvider(f"http://127.0.0.1:{HTTP_PORT}/{data['uuid']}"))

        if not checker(web3, data['address']):
            print("are you sure you solved it?")
            return 1

        print(FLAG)
        print('')
        print('for your safety, you should delete your instance now that you are done')
        return 0

    return Action(name="get flag", handler=action)


def run_launcher(actions: List[Action]):
    for i, action in enumerate(actions):
        print(f"{i+1} - {action.name}")

    action = int(input("action? ")) - 1
    if action < 0 or action >= len(actions):
        print("can you not")
        exit(1)

    exit(actions[action].handler())