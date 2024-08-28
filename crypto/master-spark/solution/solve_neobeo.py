from sage.all import *
from pwn import *
from tqdm import tqdm

ps = [10424184328164303749975368099, 15965198267244792396666133003, 20682075839508686386414509803, 24163276117715523594103520923, 35037799134674725872693340027, 45395771814531405813321488107]

# io = process(['sage', 'challenge.sage'])
io = remote("master-spark.chals.sekai.team", 1337, ssl=True)
print(io.recvline().strip().decode())
io.sendlineafter(b"solution: ", input().strip().encode())

io.sendlines([str(p).encode() for p in ps])
dlogs = []
orders = []

def get_point():
    x, y = eval(io.readline())
    return EllipticCurve([0, (y**2-x**3-x)/x**2, 0, 1, 0])(x, y)

for p in tqdm(ps):
    F,j = GF(p**2, 'j', [1,0,1]).objgen()
    io.readuntil(b'>')
    P, Q = get_point(), get_point()
    orders.append(P.order())
    dlogs.append(P.discrete_log(Q))
    
for ds in cartesian_product([[d,-d] for d in dlogs]):
    try:
        c = crt(list(ds), orders)
        if c.nbits() <= 256:
            break
    except:
        pass
    
io.sendline(str(c).encode())
print(io.readall())