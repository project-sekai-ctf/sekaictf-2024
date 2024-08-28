import base64
import struct
import secrets

VERSION = "s"

mod = (1 << 1279) - 1
exp = 1 << 1277
one = 1
two = 2

class Challenge:
    def __init__(self, d, x):
        self.d = d
        self.x = x

    @classmethod
    def decode_challenge(cls, v):
        parts = v.split('.', 2)
        if len(parts) != 3 or parts[0] != VERSION:
            raise ValueError("Incorrect version")

        d_bytes = base64.b64decode(parts[1])
        if len(d_bytes) > 4:
            raise ValueError("Difficulty too long")

        d_bytes = b'\x00' * (4 - len(d_bytes)) + d_bytes
        d = struct.unpack('>I', d_bytes)[0]

        x_bytes = base64.b64decode(parts[2])
        x = int.from_bytes(x_bytes, byteorder='big')

        return cls(d, x)

    @classmethod
    def generate_challenge(cls, d):
        b = secrets.token_bytes(16)
        x = int.from_bytes(b, byteorder='big')  # Convert to integer
        return cls(d, x)

    def __str__(self):
        d_bytes = struct.pack('>I', self.d)
        x_bytes = self.x.to_bytes((self.x.bit_length() + 7) // 8, byteorder='big')
        return f"{VERSION}.{base64.b64encode(d_bytes).decode()}.{base64.b64encode(x_bytes).decode()}"

    def solve(self):
        x = self.x
        for _ in range(self.d):
            x = pow(x, exp, mod)
            x ^= one
        x_bytes = x.to_bytes((x.bit_length() + 7) // 8, byteorder='big')
        return f"{VERSION}.{base64.b64encode(x_bytes).decode()}"

    def check(self, s):
        parts = s.split('.', 1)
        if len(parts) != 2 or parts[0] != VERSION:
            raise ValueError("Incorrect version")

        y_bytes = base64.b64decode(parts[1])
        y = int.from_bytes(y_bytes, byteorder='big')

        for _ in range(self.d):
            y ^= one
            y = pow(y, two, mod)

        x = self.x
        if x == y:
            return True
        return (mod - x) == y