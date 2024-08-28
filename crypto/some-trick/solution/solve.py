from pwn import *
import random
from tqdm import tqdm
from Crypto.Util.number import *

io = remote("sometrick.chals.sekai.team", 1337, ssl=True)
# io = process(["python","sometrick.py"])
GSIZE = 8209
GNUM = 79
LIM = GSIZE**GNUM

def gen(n):
    p, i = [0] * n, 0
    for j in random.sample(range(1, n), n - 1):
        p[i], i = j, j
    return tuple(p)

def gmul(g,res):
    return tuple(res[i] for i in g)

def gexp(g, e):
    res = tuple(g)
    while e:
        if e & 1:
            res = tuple(res[i] for i in g)
        e >>= 1
        g = tuple(g[i] for i in g)
    return res

def solve1(g,e, enc):
    return list(gexp(g, e)).index(enc)

def solve2(g,m, enc):
    res = tuple(g)
    
    for k in tqdm(range(GSIZE)):
        if g[m] == enc:
            break
        g = gmul(g,res)
    return k        

def enc(k, m, G):
    if not G:
        return m
    mod = len(G[0])
    return gexp(G[0], k % mod)[m % mod] + enc(k // mod, m // mod, G[1:]) * mod

def dec1(k, ct, G):
    if not G:
        return 0
    mod = len(G[0])
    enc_ = ct % mod
    return solve1(G[0],k % mod, enc_) + dec1(k // mod, ct // mod, G[1:]) * mod

def dec2(ct, m, G):

    if not G:
        return 0
    mod = len(G[0])
    enc_ = ct % mod
    return solve2(G[0], m % mod, enc_) + dec2(ct // mod, m // mod, G[1:]) * mod

def inverse(perm):
    res = list(perm)
    for i, v in enumerate(perm):
        res[v] = i
    return res

CIPHER_SUITE = int(io.recvline().decode().split("4.0.")[1])
random.seed(CIPHER_SUITE)
G = [gen(GSIZE) for i in range(GNUM)]

G_inv = [inverse(i) for i in G]
bob_encr  = int(io.recvline().decode().split(" ")[-1])
alice_encr = int(io.recvline().decode().split(" ")[-1])
bob_decr  = int(io.recvline().decode().split(" ")[-1])
io.close()

alice_key = dec1(bob_encr, alice_encr, G)
print("FIN1",alice_key)
bob_key = dec1(alice_encr, bob_decr, G_inv)
print("FIN2",bob_key)
FLAG = dec2(bob_encr, bob_key, G)

print(bin(FLAG)[2:].index(bin(bytes_to_long(b"SEKAI{"))[2:]))

for i in range(int(FLAG).bit_length()):
    if long_to_bytes(FLAG >> i)[-1] == ord("}"):
        print(long_to_bytes(FLAG >> i))
