try:
    import sudokum
    from Crypto.Util.number import long_to_bytes, bytes_to_long
except:
    print('Woah woah woah, are you trying to reverse me?')
    __import__('os')._exit(1)

from base64 import b64encode, b64decode
from ctypes import CDLL
from time import time
from operator import eq

for a in range(20): # just multiply 20 times
    # CODE OBJ
    while True:
        grid = sudokum.generate(mask_rate=0.56)
        # ensure there's only one solution
        solves = []
        for _ in range(10):
            solves.append(sudokum.solve(grid)[1])

        tmp = []
        for x in solves:
            tmp.append(x==solves[0])
        if all(tmp):
            real_solve = solves[0]
            break
    # END CODE OBJ

    # print(b64encode(long_to_bytes(int(''.join([''.join(list(map(str,x)))for(x)in dirg])))).decode())
    condensed_grid = ''.join([''.join(list(map(str,x))) for x in grid])
    to_output = b64encode(long_to_bytes(int(condensed_grid))).decode()

    print(to_output)
    libc = CDLL('/lib/x86_64-linux-gnu/libc.so.6')
    libc.srand(int(time()))

    # modify real_solve, just multiply 11 times
    for b in range(11):
        real_solve[libc.rand() % 9][libc.rand() % 9] = (libc.rand() % 9) + 1

    # check if they give us the same answer
    # CODE OBJ
    try:
        inp = input('> ')
        inp = str(bytes_to_long(b64decode(inp))).zfill(81)
        inp = [[int(inp[i+j]) for j in range(9)] for i in range(0, 81, 9)]
    except:
        print('bad')
        __import__('os')._exit(1)
    # END CODE OBJ

    exec(getattr(['print("no");__import__("os")._exit(1)',''],'__getitem__')(eq(inp,real_solve)))

try:
    flag = open('flag.txt').read().strip()
    print('Good job! Here is your flag:')
    print(flag)
except:
    print('Woah woah woah, are you trying to reverse me?')
    __import__('os')._exit(1)