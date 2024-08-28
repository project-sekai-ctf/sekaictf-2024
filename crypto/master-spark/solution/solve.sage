from itertools import product
from random import sample
from ptrlib import remote, process
from Crypto.Util.number import isPrime

def montgomery(Fp2, A):
    return EllipticCurve(Fp2, [0, A, 0, 1, 0])

def Pohlig_Hellman_Montgomery(Q, P, order, r):
    # https://wstein.org/edu/2010/414/projects/novotney.pdf

    P = (order // r) * P
    Q = (order // r) * Q
    base, exp = factor(r)[0]
    P0 = (order // base) * P
    z = 0
    for i in range(1, exp + 1):
        Q0 = (order // (base ^ i)) * (Q - z * P)
        for k in range(base):
            if Q0 == k * P0:
                z += k * base ^ (i - 1)
                break
    return int(z)

# io = process(["sage", "challenge.sage"])
io = remote("master-spark.chals.sekai.team", 1337, ssl=True)

print(io.recvline().strip().decode())
io.sendlineafter(b"solution: ", input().strip().encode())

dlogs, sendlists = [], []

primes = set(list(Primes()[20:100]))
while len(sendlists) != 10:
    tmp = sample(list(primes), 4)
    base_p = Primes()[len(sendlists) + 1]
    base_p = base_p ^ int(log(2 ^ 32, base_p))
    if not isPrime(4 * base_p * prod(tmp) - 1):
        continue
    sendlists.append(int(4 * base_p * prod(tmp) - 1))
    primes = primes - set(tmp)
    print(int(4 * base_p * prod(tmp) - 1))

crt_primes = []

for p in sendlists:

    io.sendlineafter(b">", p)
    for _p, exp in factor((p + 1) // 4):
        if exp != 1:
            base_prime = _p
            exp_prime = exp
    assert isPrime(p), (isPrime(p), p.bit_length(), p)
    Fp2.<j> =  GF(p ^ 2, modulus=x ^ 2 + 1)
    P = eval(io.recvline().decode())
    Q = eval(io.recvline().decode())
    print("fin recv")
    A = (P[1] ^ 2 - P[0] ^ 3 - P[0]) * pow(P[0] ^ 2, -1, p)
    E = EllipticCurve(Fp2, [0, A, 0, 1, 0])
    P = E(*P)
    Q = E(*Q)

    tmp = Pohlig_Hellman_Montgomery(Q, P, p + 1, base_prime ^ exp_prime)
    crt_primes.append(int(base_prime ^ exp_prime))
    dlogs.append([int(tmp), int(crt_primes[-1] - tmp)])

    if prod(crt_primes).bit_length() >= 256:
        break

for dlog in product(*dlogs):
    secret = int(CRT(list(dlog), crt_primes))
    if isPrime(secret):
        io.sendline(secret)
        a = io.recvline()
        if b"SEKAI" in a:
            print(a)
            exit()
