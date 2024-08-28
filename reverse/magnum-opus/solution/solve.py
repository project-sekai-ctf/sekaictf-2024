from Crypto.Util.number import bytes_to_long, long_to_bytes
from base64 import b64decode, b64encode
import sudokum
from ctypes import CDLL
from time import time as t
from pwn import *



### SETUP ###
p = remote('magnum-opus.chals.sekai.team', 1337, ssl=True)
libc = CDLL('/lib/x86_64-linux-gnu/libc.so.6')


### LOOP ###
for _ in range(10):
    ### SOLVE SUDOKU ###
    inp = p.recvline().decode().strip()
    print(f'Puzzle {_}: {inp}')
    libc.srand(int(t()))

    # solve the right way
    inp = str(bytes_to_long(b64decode(inp))).zfill(81)
    grid = [[int(inp[i+j]) for j in range(9)] for i in range(0, 81, 9)]
    actual_solve = sudokum.solve(grid)[1]

    #print(actual_solve)
    #print(b64encode(long_to_bytes(int(''.join([''.join(list(map(str,x))) for x in actual_solve])))).decode())

    # adjust the solution for rand() calls
    for b in range(11):
        row = libc.rand() % 9
        col = libc.rand() % 9
        num = libc.rand() % 9 + 1
        actual_solve[row][col] = num

    answer = b64encode(long_to_bytes(int(''.join([''.join(list(map(str,x))) for x in actual_solve]))))
    print(f'Answer {_}: {answer}')
    p.sendline(answer)



### FLAG ###    
p.interactive()