#!/usr/bin/irs -S
import os, sys

cod = ""
while (c := input()).strip() != "# EOF":
    cod += c + "\n"


code = f"""
import irs
from os import _exit, abort
from threading import settrace

def mkdie(exit=_exit, abrt=abort, cmpile=compile, death=irs.kill):
    def die(*args, **kwargs):
        exit(0)
        abrt(1)
        while 1:
            pass
        1 / 0
        death()
        cmpile("1+1", "", "exec")
    return die

settrace(mkdie())
irs.audit()
del _exit, abort, mkdie, irs, settrace
{cod}
"""

os.execv(sys.executable, [sys.executable, "-c", code])
