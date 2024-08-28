from os import urandom
from util import *
from pwn import *

def rand(a):
    return b"\x00"*a
randombytes=urandom
# randombytes=rand

io = remote("hayabusa.chals.sekai.team", int(1337), ssl=True)
n = int(io.recvline().decode().strip().split(" ")[-1][:-1])
io.recvline()
exec(io.recvline().decode())
io.recvline()

message = b"Can you break me"
int_header = 0x30 + logn[n]
header = int(int_header).to_bytes(1, "little")
salt = randombytes(SALT_LEN)
hashed = hash_to_point(message, salt, n)

PR.<x> = PolynomialRing(GF(q))
PR.<x> = QuotientRing(PR,x^n+1)

h = sum([x^i*int(h[i])  for i in range(n)])
a = ([(h*x^i).list() for i in range(n)])

K = int(sqrt(int(q)))
mat_h = Matrix(ZZ,a)*(-1)
I = Matrix.identity(ZZ, n)
qI = Matrix.identity(ZZ, n)*q
Zero = zero_matrix(n,n)

MAT = block_matrix([[qI,Zero],[mat_h,I] ], subdivide=False )
MAT = MAT.augment(vector([0]*(2*n)))
MAT = MAT.stack(vector(hashed +[0]*n +[K]))

llled = MAT.LLL()

for row in llled:
    if row[-1] == K:
        s1 = row[n:2*n]
        s0 = sum([x^i*int(row[i])  for i in range(n)])
        s1 = sum([x^i*int(s1[i])  for i in range(n)])
        break


h = sum([x^i*int(h[i])  for i in range(n)])
c = sum([x^i*int(hashed[i])  for i in range(n)])

print("find s0",s0.list())
print("find s1",s1.list())
assert c == s0 + h*s1

sig = compress(s1.list(), Params[n]["sig_bytelen"] - HEAD_LEN - SALT_LEN)
print(sig)
io.sendlineafter(b">", (header + salt + sig).hex().encode())
print(io.recvline())
print(io.recvline())

