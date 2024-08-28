import os
import random
import subprocess
import signal
import json
import time
import re
from threading import Thread
from typing import Dict

import requests
from eth_account.hdaccount import generate_mnemonic
from eth_sandbox.launcher import sendTransaction
from flask import Flask, Response, request
from flask_cors import CORS, cross_origin
from web3 import Web3
from cheb3.utils import decode_data, calc_create_address

from eth_sandbox import *

app = Flask(__name__)
CORS(app)

HTTP_PORT = os.getenv("HTTP_PORT", "8545")
ETH_RPC_URL = os.getenv("ETH_RPC_URL")
BLOCK_NUMBER = os.getenv("BLOCK_NUMBER")
try:
    os.mkdir("/tmp/instances-by-team")
    os.mkdir("/tmp/instances-by-uuid")
except:
    pass


def has_instance_by_uuid(uuid: str) -> bool:
    return os.path.exists(f"/tmp/instances-by-uuid/{uuid}")


def get_instance_by_uuid(uuid: str) -> Dict:
    with open(f"/tmp/instances-by-uuid/{uuid}", "r") as f:
        return json.loads(f.read())


def delete_instance_info(node_info: Dict):
    os.remove(f'/tmp/instances-by-uuid/{node_info["uuid"]}')


def create_instance_info(node_info: Dict):
    with open(f'/tmp/instances-by-uuid/{node_info["uuid"]}', "w+") as f:
        f.write(json.dumps(node_info))


def really_kill_node(node_info: Dict):
    print(f"killing node {node_info['uuid']}")

    delete_instance_info(node_info)

    os.kill(node_info["pid"], signal.SIGTERM)


def kill_node(node_info: Dict):
    time.sleep(60 * 30)

    if not has_instance_by_uuid(node_info["uuid"]):
        return

    really_kill_node(node_info)


def launch_node(uuid: str) -> Dict:
    port = random.randrange(30000, 60000)
    mnemonic = generate_mnemonic(12, "english")

    proc = subprocess.Popen(
        args=[
            "/opt/foundry/bin/anvil",
            "--accounts",
            "1",  # only for deployer
            "--mnemonic",
            mnemonic,
            "--port",
            str(port),
            "--fork-url",
            ETH_RPC_URL,
            "--block-base-fee-per-gas",
            "5",
        ],
    )

    web3 = Web3(Web3.HTTPProvider(f"http://127.0.0.1:{port}"))
    while True:
        if proc.poll() is not None:
            return None
        if web3.is_connected():
            break
        time.sleep(0.1)

    node_info = {
        "port": port,
        "mnemonic": mnemonic,
        "pid": proc.pid,
        "uuid": uuid,
    }

    reaper = Thread(target=kill_node, args=(node_info,))
    reaper.start()
    return node_info


def is_request_authenticated(request):
    token = request.headers.get("Authorization")

    return token == f"Bearer {get_shared_secret()}"


def send_user_operations(node_info: dict, data: str):
    uuid = node_info["uuid"]
    mnemonic = node_info["mnemonic"]
    deployer_account = Account.from_mnemonic(mnemonic, account_path="m/44'/60'/0'/0/0")
    deployer_addr: str = deployer_account.address
    setup_addr = calc_create_address(deployer_addr, 0)

    web3 = Web3(
        Web3.HTTPProvider(
            f"http://127.0.0.1:{HTTP_PORT}/{uuid}",
            request_kwargs={
                "headers": {
                    "Authorization": f"Bearer {get_shared_secret()}",
                    "Content-Type": "application/json",
                },
            },
        )
    )

    paymaster_selector = web3.keccak(text="paymaster()")[:4].hex()
    paymaster = decode_data(
        web3.eth.call({"to": setup_addr, "data": paymaster_selector}).hex(),
        ["address"],
    )
    entrypoint_selector = web3.keccak(text="entryPoint()")[:4].hex()
    entrypoint = decode_data(
        web3.eth.call({"to": paymaster, "data": entrypoint_selector}).hex(),
        ["address"],
    )

    try:
        rcpt = sendTransaction(
            web3,
            {
                "from": deployer_addr,
                "to": entrypoint,
                "data": data,
            },
            ignore_status=True,
        )
        return rcpt
    except Exception:
        return None


@app.route("/")
def index():
    return "sandbox is running!"


@app.route("/new", methods=["POST"])
@cross_origin()
def create():
    if not is_request_authenticated(request):
        return {
            "ok": False,
            "error": "nice try",
        }

    body = request.get_json()

    uuid = body["uuid"]

    if has_instance_by_uuid(uuid):
        print(f"refusing to run a new chain for {uuid}")
        return {
            "ok": False,
            "error": "already_running",
            "message": "An instance is already running!",
        }

    print(f"launching node for {uuid}")

    node_info = launch_node(uuid)
    if node_info is None:
        print(f"failed to launch node for {uuid}")
        return {
            "ok": False,
            "error": "error_starting_chain",
            "message": "An error occurred while starting the chain",
        }
    create_instance_info(node_info)

    print(
        f"launched node for {uuid} (uuid={node_info['uuid']}, pid={node_info['pid']})"
    )

    return {
        "ok": True,
        "uuid": node_info["uuid"],
        "mnemonic": node_info["mnemonic"],
    }


@app.route("/handle", methods=["POST"])
@cross_origin()
def handle() -> dict:
    if not is_request_authenticated(request):
        return {
            "ok": False,
            "error": "nice try",
        }
    body = request.get_json()

    uuid = body["uuid"]
    if not has_instance_by_uuid(uuid):
        print(f"no instance of {uuid}")
        return {
            "ok": False,
            "error": "not_running",
            "message": "No instance is running!",
        }

    encoded = body["data"]
    if not encoded.lower().startswith("0x765e827f"):
        print(f"invalid selector: {encoded[:10].lower()}")
        return {
            "ok": False,
            "error": "invalid_selector",
            "message": "Invalid selector!",
        }

    # replace it anyway :D
    beneficiary = "000000000000000000000000000000000000cafE"
    encoded = re.sub(r"(?<=400{24}).{40}", beneficiary, encoded, 1)

    receipt = send_user_operations(get_instance_by_uuid(uuid), encoded)
    if receipt is None:
        print(f"failed to send transaction for {uuid}")
        return {
            "ok": False,
            "error": "failed_transaction",
            "message": "Failed to send transaction!",
        }

    return {
        "ok": True,
        "status": receipt["status"],
        "tx_hash": receipt["transactionHash"].hex(),
    }


@app.route("/kill", methods=["POST"])
@cross_origin()
def kill():
    if not is_request_authenticated(request):
        return {
            "ok": False,
            "error": "nice try",
        }

    body = request.get_json()

    uuid = body["uuid"]

    if not has_instance_by_uuid(uuid):
        print(f"no instance to kill for {uuid}")
        return {
            "ok": False,
            "error": "not_running",
            "message": "No instance is running!",
        }

    really_kill_node(get_instance_by_uuid(uuid))

    return {
        "ok": True,
        "message": "Instance killed",
    }


ALLOWED_NAMESPACES = ["web3", "eth", "net"]


@app.route("/<string:uuid>", methods=["POST"])
@cross_origin()
def proxy(uuid):
    body = request.get_json()
    if not body:
        return "invalid content type, only application/json is supported"

    if "id" not in body:
        return ""

    if not has_instance_by_uuid(uuid):
        return {
            "jsonrpc": "2.0",
            "id": body["id"],
            "error": {
                "code": -32602,
                "message": "invalid uuid specified",
            },
        }

    node_info = get_instance_by_uuid(uuid)

    if "method" not in body or not isinstance(body["method"], str):
        return {
            "jsonrpc": "2.0",
            "id": body["id"],
            "error": {
                "code": -32600,
                "message": "invalid request",
            },
        }

    ok = (
        any(body["method"].startswith(namespace) for namespace in ALLOWED_NAMESPACES)
        and body["method"] != "eth_sendUnsignedTransaction"
    )
    if not ok and not is_request_authenticated(request):
        return {
            "jsonrpc": "2.0",
            "id": body["id"],
            "error": {
                "code": -32600,
                "message": "invalid request",
            },
        }

    resp = requests.post(f"http://127.0.0.1:{node_info['port']}", json=body)
    response = Response(resp.content, resp.status_code, resp.raw.headers.items())
    return response


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=HTTP_PORT)
