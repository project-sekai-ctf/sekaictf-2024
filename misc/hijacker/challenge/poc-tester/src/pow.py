import base64
import os
import struct
from Crypto.Util.number import bytes_to_long, long_to_bytes

VERSION = "s"
MOD = 2 ** 1279 - 1
EXP = 2 ** 1277

class Challenge:
    def __init__(self, d, x):
        self.d = d
        self.x = x

    @classmethod
    def from_string(cls, v):
        parts = v.split(".", 2)
        if len(parts) != 3 or parts[0] != VERSION:
            raise ValueError("Incorrect version")
        d_bytes = base64.standard_b64decode(parts[1])
        d = struct.unpack(">I", d_bytes)[0]
        x_bytes = base64.standard_b64decode(parts[2])
        x = bytes_to_long(x_bytes)
        return cls(d, x)

    @classmethod
    def generate(cls, d):
        x = bytes_to_long(os.urandom(16))
        return cls(d, x)

    def __str__(self):
        d_bytes = struct.pack(">I", self.d)
        x_bytes = long_to_bytes(self.x)
        return f"{VERSION}.{base64.standard_b64encode(d_bytes).decode()}.{base64.standard_b64encode(x_bytes).decode()}"

    def solve(self):
        x = pow(self.x, EXP, MOD)
        for _ in range(self.d):
            x ^= 1
            x = pow(x, 2, MOD)
        return f"{VERSION}.{base64.standard_b64encode(long_to_bytes(x)).decode()}"

def decode_solution(s):
    parts = s.split(".", 1)
    if len(parts) != 2 or parts[0] != VERSION:
        raise ValueError("Incorrect version")
    y_bytes = base64.standard_b64decode(parts[1])
    return bytes_to_long(y_bytes)

def check(challenge, s):
    y = decode_solution(s)
    for _ in range(challenge.d):
        y ^= 1
        y = pow(y, 2, MOD)
    x = challenge.x
    if x == y:
        return True
    x = (MOD - challenge.x) % MOD
    return x == y
