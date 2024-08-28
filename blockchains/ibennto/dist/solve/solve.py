# sample solve script to interface with the server
import pwn

# if you don't know what this is doing, look at server code and also sol-ctf-framework read_instruction:
# https://github.com/otter-sec/sol-ctf-framework/blob/rewrite-v2/src/lib.rs#L237
# feel free to change the accounts and ix data etc. to whatever you want
account_metas = [
    ("program", "-r"),  # read only
    ("data account", "-w"),  # writable
    ("user", "sw"),  # signer + writable
    ("user data", "sw"),
    ("system program", "-r"),
]
instruction_data = b"placeholder"

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

p.sendline(str(len(account_metas)).encode())
for name, perms in account_metas:
    p.sendline(f"{perms} {accounts[name]}".encode())
p.sendlineafter(b"ix len: \n", str(len(instruction_data)).encode())
p.send(instruction_data)

p.interactive()
