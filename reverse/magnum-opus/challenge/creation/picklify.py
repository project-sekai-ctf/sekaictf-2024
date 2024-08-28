# python 3.11.9

"""
Idea: make a pickle that generates a random sudoku board + solves it incorrectly, they need to analyze broken solving algorithm, implement themselves, then solve on remote 10 times to get the flag
"""
from pickle import *
from pwn import flat


### GENERATOR SCRIPTS ###
use_deadcode = 1
if use_deadcode:
    d1 = deadcode1 = flat(MARK,POP)
    d2 = deadcode2 = flat(DUP,POP)           # must be something on stack
    d3 = deadcode3 = flat(MARK,APPENDS)      # must be something on stack
    d4 = deadcode4 = flat(MARK,ADDITEMS)     # must be something on stack
    d5 = deadcode5 = b''#b'T\x00\x00\x00\x80'+b'a'*0x80000000
else:
    d1 = deadcode1 = b''
    d2 = deadcode2 = b''
    d3 = deadcode3 = b''
    d4 = deadcode4 = b''
    d5 = deadcode5 = b''

# maps a-z to their respective locations in the memo
poly_alph_memo = flat(
    MARK, d1,                                           # mark so easy to get rid of non-popped stack objs

    SHORT_BINSTRING, b'\x01k', d2, BINPUT, b'\x1c', d3, # memo[28] = 'k'
    b'S"n"\n', BINPUT, b'\x1b',                         # memo[27] = 'n'
    SHORT_BINSTRING, b'\x01x', LONG_BINPUT,             # memo[18] = 'x'
        b'\x12\x00\x00\x00',
    b'S"r"\n', BINPUT, b'\x03',                         # memo[3]  = 'r'
    BINSTRING, b'\x01\x00\x00\x00q', BINPUT, b'\x0a',   # memo[10] = 'q'
    b'S"i"\n', BINPUT, b'\x08',                         # memo[8]  = 'i'
    b'S"e"\n', BINPUT, b'\x14',                         # memo[20] = 'e'
    d4, BINSTRING, b'\x01\x00\x00\x00f', PUT, b'25\n',  # memo[25] = 'f'
    b'S"w"\n', LONG_BINPUT, b'\x0d\x00\x00\x00',        # memo[13] = 'w'
    b'S"c"\n', MEMOIZE,                                 # memo[9]  = 'c'
    BINSTRING, b'\x01\x00\x00\x00j', d3, BINPUT, b'\x17', # memo[23] = 'j'
    GLOBAL, b'builtins\nchr\n', b'I0x74\n', TUPLE1,     # memo[19] = 't'
        REDUCE, BINPUT, b'\x13',
    BINSTRING, b'\x01\x00\x00\x00s', BINPUT, b'\x10',   # memo[16] = 's'
    SHORT_BINSTRING, b'\x01a', d1, BINPUT, b'\x04',     # memo[4]  = 'a'
    b'S"h"\n', BINPUT, b'\x06',                         # memo[6]  = 'h'
    BINSTRING, b'\x01\x00\x00\x00m', PUT, b'5\n',       # memo[5]  = 'm'
    SHORT_BINSTRING, b'\x01z', LONG_BINPUT,             # memo[21] = 'z'
        b'\x15\x00\x00\x00',
    SHORT_BINSTRING, b'\x01v', PUT, b'12\n',            # memo[12] = 'v'
    BINSTRING, b'\x01\x00\x00\x00p', BINPUT, b'\x18',   # memo[24] = 'p'
    d1, BINSTRING, b'\x01\x00\x00\x00o', BINPUT, b'\x0f', # memo[15] = 'o'
    BINSTRING, b'\x01\x00\x00\x00d', PUT, b'22\n',      # memo[22] = 'd'
    b'S"b"\n', BINPUT, b'\x0b',                         # memo[11] = 'b'
    SHORT_BINSTRING, b'\x01u', d4, BINPUT, b'\x1a',     # memo[26] = 'u'
    b'S"g"\n', BINPUT, b'\x0e',                         # memo[14] = 'g'
    b'S"y"\n', LONG_BINPUT, b'\x11\x00\x00\x00',        # memo[17] = 'y'
    b'S"l"\n', d3, BINPUT, b'\x07',                     # memo[7]  = 'l'

    POP_MARK,                                           # pop all stack objs
)

# helper function for mono_alph_memo
def gc(char):
    return 'ramhlicqbvwgosyxtezdjpfunk'.index(char)+3

# saves some functions to the memo so they don't have to be reimported each time
save_funcs = flat(
    GLOBAL, b'builtins\ngetattr\n', BINPUT, b'\x90', d3, POP,
    GLOBAL, b'operator\nmul\n', BINPUT, b'\x91', d2, POP,
    GLOBAL, b'operator\neq\n', BINPUT, b'\x92', d2, POP,
    GLOBAL, b'operator\nadd\n', BINPUT, b'\x93', d2, POP,
    SHORT_BINSTRING, b'\x04join', BINPUT, b'\x65', d2, POP,
    GLOBAL, b'operator\nmod\n', BINPUT, b'\x94', d2, POP,
)

# generates a string on the stack using mono_alph_memo
def make_str(str):
    retval = flat(
        # get ''.join on stack
        BINGET, b'\x90', d4,
        SHORT_BINUNICODE, b'\x00', d3, BINGET, b'\x65', d4,
        TUPLE2, REDUCE,

        # put letters 'i', 'n', 'f' on stack to make ['i', 'n', 'f']
        MARK, d1,
    )

    for letter in str:
        try:
            retval += BINGET+gc(letter).to_bytes()
        except ValueError:
            retval += SHORT_BINSTRING + b'\x01' + letter.encode()

    retval += flat(
        d2 if len(str) != 0 else b'',
        LIST,

        # turn ['i', 'n', 'f'] into 'inf'
        TUPLE1, REDUCE, d3,
    )
    return retval

# makes 0
float_logic_0 = flat(
    GLOBAL, b'builtins\nint\n',         # int
    BINGET, b'\x91', d2,                # mul
    BININT, b'\xff\xff\xff\xff',        # -1
    GLOBAL, b'operator\ntruediv\n',     # div
    b'I0x1337\n',                       # 0x1337
    BINGET, b'\x91',                    # mul

    ### GET float('inf') and float('-inf') ON STACK ###
    GLOBAL, b'builtins\nfloat\n',
    make_str('inf'), d3,
    TUPLE1, REDUCE,
    FLOAT, b'-inf\n',

    # float('inf') * float('-inf')
    TUPLE2, REDUCE, d4,

    # 1337 / (float('inf')*float('-inf'))
    TUPLE2, REDUCE,

    # (1337 / (float('inf')*float('-inf'))) * -1
    TUPLE2, REDUCE, d1,

    # 0
    TUPLE1, REDUCE
)

test = flat(
    GLOBAL, b'builtins\nexec\n',
    b'S"print(dirg);print(plus)"\n',
    TUPLE1, REDUCE
)

# beginning stuff
start = flat(
    b'I0x1337\n', POP, d5, poly_alph_memo, save_funcs,
)

# import sudokum
import_sudokum = flat(
    # get exec and CodeType on the stack
    GLOBAL, b'builtins\nexec\n',
    GLOBAL, b'types\nCodeType\n',

    # 0, 0, 0
    MARK, d1, b'K\x00', float_logic_0, b'I0x0\n', d3,

    # rely on b'I 0\n.' parsing discrepancy to get 3 for pickle.c and 0 for pickle.py, which will throw an error in the CodeObject
    BINGET, b'\x91', d4,
    BINGET, b'\x92', d4,
    GLOBAL, b'builtins\ntype\n', d4,

    b'I 0\n' if use_deadcode else NEWFALSE, # in pickle.c, this is False, in pickle.py, this is 0

    TUPLE1, REDUCE, d1,
    GLOBAL, b'builtins\nbool\n', d2,
    TUPLE2, REDUCE,
    b'K\x03', d2,
    TUPLE2, REDUCE,

    # 4, 3
    b'K\x04', b'L0x3\n', d3,

    BINBYTES, b'\x92\x00\x00\x00', b'\x97\x00\t\x00d\x01d\x00l\x00}\x00d\x01d\x02l\x01m\x02}\x01m\x03}\x02\x01\x00d\x00S\x00#\x00\x01\x00t\t\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x03\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00t\x0b\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x04\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\xa0\x06\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x05\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00Y\x00d\x00S\x00x\x03Y\x00w\x01', 

    MARK,
        # add items to consts
        NONE, float_logic_0, MARK, d1,
            # long_to_bytes
            BINGET, b'\x90',
            SHORT_BINUNICODE, b'\x01_', SHORT_BINSTRING, b'\x04join',
            TUPLE2, REDUCE,
            MARK,
                make_str('long'), make_str('to'), make_str('bytes'), d4,
            LIST,
            TUPLE1, REDUCE, d3,
            BINPUT, b'\x77',
            
            # bytes_to_long
            BINGET, b'\x90',
            SHORT_BINUNICODE, b'\x01_', SHORT_BINSTRING, b'\x04join',
            TUPLE2, REDUCE, d2,
            MARK,
                make_str('bytes'), make_str('to'), make_str('long'),
            LIST, d2,
            TUPLE1, REDUCE,
            BINPUT, b'\x78',
        TUPLE,
        BINSTRING, b'\x2d\x00\x00\x00Woah woah woah, are you trying to reverse me?',
        make_str('os'), b'I0001\n' if use_deadcode else b'I1\n', d1,
    TUPLE,

    MARK,
        # varnames? imports?
        make_str('sudokum'), d1,
        b'S"Crypto.Util.number"\n', d2,
        BINGET, b'\x77',
        BINGET, b'\x78',
        make_str('print'),

        # __import__
        BINGET, b'\x90', d3,
        SHORT_BINUNICODE, b'\x01_', SHORT_BINSTRING, b'\x04join',
        TUPLE2, REDUCE,
        MARK,
            make_str(''), make_str(''), make_str('import'), make_str(''), make_str(''),
        LIST,
        TUPLE1, REDUCE, d4,

        # _exit
        BINGET, b'\x90',
        SHORT_BINUNICODE, b'\x01_', SHORT_BINSTRING, b'\x04join',
        TUPLE2, REDUCE,
        MARK,
            make_str(''), make_str('exit'),
        LIST,
        TUPLE1, REDUCE, d3,
    TUPLE,

    MARK, 
        make_str(''), make_str(''), make_str(''), d3,
    TUPLE,

    b'U\x00',b'U\x00',b'U\x00', b'I0001\n' if use_deadcode else b'I1\n',

    SHORT_BINBYTES, b'\x6b', b'\x80\x00\xf0\x02\x05\x05"\xd8\x08\x16\x88\x0e\x88\x0e\x88\x0e\xd8\x08C\xd0\x08C\xd0\x08C\xd0\x08C\xd0\x08C\xd0\x08C\xd0\x08C\xd0\x08C\xd0\x08C\xd0\x08C\xf8\xf0\x02\x02\x05"\xdd\x08\r\xd0\x0e=\xd1\x08>\xd4\x08>\xd0\x08>\xdd\x08\x12\x904\xd1\x08\x18\xd4\x08\x18\xd7\x08\x1e\xd2\x08\x1e\x98q\xd1\x08!\xd4\x08!\xd0\x08!\xd0\x08!\xd0\x08!\xd0\x08!\xf8\xf8\xf8', d3,
    
    BINBYTES8, b'\x09\x00\x00\x00\x00\x00\x00\x00', b'\x82\x0c\x10\x00\x903A\x06\x03', 
    
    EMPTY_TUPLE, EMPTY_TUPLE, d1,

    # call CodeType and exec
    TUPLE, REDUCE,
    TUPLE1, REDUCE,
)

# other imports
other_imports = flat(
    # base64
    BINGET, b'\x90',
    SHORT_BINUNICODE, b'\x0264', SHORT_BINSTRING, b'\x04join',
    TUPLE2, REDUCE,
    MARK,
        make_str('base'), make_str(''),
    LIST,
    TUPLE1, REDUCE, d3,

    # b64encode
    BINGET, b'\x90',
    SHORT_BINUNICODE, b'\x0264', SHORT_BINSTRING, b'\x04join',
    TUPLE2, REDUCE,
    MARK,
        make_str('b'), make_str('encode'),
    LIST,
    TUPLE1, REDUCE, d3,

    STACK_GLOBAL, BINPUT, b'\x80',


    # base64
    BINGET, b'\x90',
    SHORT_BINUNICODE, b'\x0264', SHORT_BINSTRING, b'\x04join',
    TUPLE2, REDUCE,
    MARK,
        make_str('base'), make_str(''),
    LIST,
    TUPLE1, REDUCE, d3,

    # b64decode
    BINGET, b'\x90',
    SHORT_BINUNICODE, b'\x0264', SHORT_BINSTRING, b'\x04join',
    TUPLE2, REDUCE,
    MARK,
        make_str('b'), make_str('decode'),
    LIST,
    TUPLE1, REDUCE, d3,

    STACK_GLOBAL, BINPUT, b'\x81',
    make_str('ctypes'), b'S"CDLL"\n', STACK_GLOBAL, BINPUT, b'\x82',
    make_str('time'), DUP, STACK_GLOBAL, BINPUT, b'\x83',

    make_str('Crypto.Util.number'), make_str('long_to_bytes'), STACK_GLOBAL, BINPUT, b'\x84',
    make_str('Crypto.Util.number'), make_str('bytes_to_long'), STACK_GLOBAL, BINPUT, b'\x85',
)

# while loop to generate a sudoku board
while_loop = flat(
    # get exec and CodeType on the stack
    GLOBAL, b'builtins\nexec\n', d1,
    GLOBAL, b'types\nCodeType\n',

    MARK, 
        # 0, 0, 0, 4, 6, 3
        b'K\x00', float_logic_0, d2, b'I0x0\n', b'K\x05', b'L0x6\n', d4, b'K\x03',

        BINBYTES, b'\x46\x01\x00\x00', b'\x97\x00d\x01d\x00l\x00}\x00\t\x00|\x00\xa0\x01\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x03\xac\x04\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00a\x02g\x00}\x01t\x07\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x05\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00D\x00]5}\x02|\x01\xa0\x04\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00|\x00\xa0\x05\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00t\x04\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00d\x06\x19\x00\x00\x00\x00\x00\x00\x00\x00\x00\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00\x8c6g\x00}\x03|\x01D\x00]!}\x04|\x03\xa0\x04\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00|\x04|\x01d\x01\x19\x00\x00\x00\x00\x00\x00\x00\x00\x00k\x02\x00\x00\x00\x00\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00\x8c"t\r\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00|\x03\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00r\n|\x01d\x01\x19\x00\x00\x00\x00\x00\x00\x00\x00\x00a\x07d\x00S\x00\x8c\x9d', d4,

        MARK, 
            NONE, float_logic_0, NEWTRUE, d3,

            # {True: 0.0, 1: 0.56}[True] to get 0.56
            BINGET, b'\x90',
            EMPTY_DICT, MARK, d1, 
                NEWTRUE, b'F0.0\n', b'K\x01', d3, BINFLOAT, b'?\xe1\xeb\x85\x1e\xb8Q\xec',
            SETITEMS,
            make_str('get'), d4,
            TUPLE2, REDUCE,
            b'K\x01', TUPLE1, REDUCE, d2,

            # mask_rate
            BINGET, b'\x90', d1,
            SHORT_BINUNICODE, b'\x01_', SHORT_BINSTRING, b'\x04join',
            TUPLE2, REDUCE, d1,
            MARK,
                make_str('mask'), make_str('rate'),
            LIST,
            TUPLE1, d4, REDUCE, TUPLE1, 

            # 10, 1, 0
            b'K\x0a', b'I0001\n' if use_deadcode else b'I1\n',
        TUPLE,

        MARK,
            # ('sudokum', 'generate', 'grid' (dirg), 'range', 'append', 'solve', 'all', 'real_solve' (plus))
            make_str('sudokum'), 
            make_str('generate'), d3, 
            make_str('dirg'), 
            make_str('range'), 
            make_str('append'), d3, 
            make_str('solve'), 
            make_str('all'), 
            make_str('plus'), d4,
        TUPLE,

        MARK,
            make_str('sudokum'), make_str(''), d1, make_str(''), make_str(''), make_str(''), d1,
        TUPLE,

        make_str(''), make_str(''), make_str(''), d4, b'K\x03',

        SHORT_BINBYTES, b'\xba', b"\x80\x00\xf0\x06\x00\x05\x13\x80N\x80N\x80N\xf0\x02\x0c\x05\x12\xd8\x0f\x16\xd7\x0f\x1f\xd2\x0f\x1f\xa8$\xd0\x0f\x1f\xd1\x0f/\xd4\x0f/\x88\x04\xe0\x11\x13\x88\x06\xdd\x11\x16\x90r\x91\x19\x94\x19\xf0\x00\x01\t2\xf0\x00\x01\t2\x88A\xd8\x0c\x12\x8fM\x8aM\x98'\x9f-\x9a-\xad\x04\xd1\x1a-\xd4\x1a-\xa8a\xd4\x1a0\xd1\x0c1\xd4\x0c1\xd0\x0c1\xd0\x0c1\xe0\x0e\x10\x88\x03\xd8\x11\x17\xf0\x00\x01\t%\xf0\x00\x01\t%\x88A\xd8\x0c\x0f\x8fJ\x8aJ\x90q\x98&\xa0\x11\x9c)\x92|\xd1\x0c$\xd4\x0c$\xd0\x0c$\xd0\x0c$\xdd\x0b\x0e\x88s\x898\x8c8\xf0\x00\x02\t\x12\xd8\x19\x1f\xa0\x01\x9c\x19\x88J\xd8\x0c\x11\x88E\xf0\x19\x0c\x05\x12",

        SHORT_BINBYTES, b'\x00',

        EMPTY_TUPLE, EMPTY_TUPLE, d3,
    TUPLE, d4,

    REDUCE, d1, TUPLE1, d2, REDUCE,
)

print_out = flat(
    # print
    make_str('builtins'), make_str('print'), d2, STACK_GLOBAL,

    # getattr
    make_str('builtins'), make_str('getattr'), STACK_GLOBAL,

    # b64decode
    BINGET, b'\x80',

    # long_to_bytes
    BINGET, b'\x84', d2, 

    # eval("int(''.join([''.join(list(map(str,x)))for(x)in dirg]))")
    make_str('builtins'), make_str('eval'), STACK_GLOBAL,

    # b64decode 'aW50KCcnLmpvaW4oWycnLmpvaW4obGlzdChtYXAoc3RyLHgpKSlmb3IoeClpbiBkaXJnXSkp'
    BINGET, b'\x81', d2,

    # base64-encoded b"int(''.join([''.join(list(map(str,x)))for(x)in dirg]))"
    make_str('aW50KCcnLmpvaW4oWycnLmpvaW4obGlzdChtYXAoc3RyLHgpKSlmb3IoeClpbiBkaXJnXSkp'),

    TUPLE1, d3, REDUCE,

    TUPLE1, d1, REDUCE,

    TUPLE1, d4, REDUCE,

    TUPLE1, d2, REDUCE,

    make_str('decode'),

    TUPLE2, d3, REDUCE, 
    
    EMPTY_TUPLE, REDUCE,

    TUPLE1, d4, REDUCE,
)

libc = flat(
    # CDLL
    BINGET, b'\x82',
    make_str('/lib/x86_64-linux-gnu/libc.so.6'), d4, 

    TUPLE1, REDUCE, d3, 

    BINPUT, b'\x64', d1, 

    POP*10, d1, 
)

seed = flat(
    # getattr
    make_str('builtins'), make_str('getattr'), STACK_GLOBAL, d4, 

    # libc
    BINGET, b'\x64',

    # srand
    make_str('srand'), d4, 

    TUPLE2, REDUCE,

    # int()
    make_str('builtins'), make_str('int'), STACK_GLOBAL,

    # time()
    BINGET, b'\x83', d3, 
    EMPTY_TUPLE, REDUCE,

    TUPLE1, REDUCE, d2, 

    TUPLE1, REDUCE, POP, d1, 
)

modify_plus = flat(
    # exec
    make_str('builtins'), make_str('exec'), STACK_GLOBAL,

    # getattr
    make_str('builtins'), make_str('getattr'), STACK_GLOBAL, d4, 

    # libc
    BINGET, b'\x64', d3,

    # rand
    make_str('rand'), d4, 
    TUPLE2, REDUCE,
    BINPUT, b'\x66', POP,


    # real_solve[libc.rand() % 9][libc.rand() % 9] = (libc.rand() % 9) + 1
    # add
    BINGET, b'\x93', d4,
    BINGET, b'\x93', d4,
    BINGET, b'\x93', d4,
    BINGET, b'\x93', d4,
    BINGET, b'\x93', d4,
    BINGET, b'\x93', d4,

    make_str('plus['),

    # str(libc.rand() % 9)
    make_str('builtins'), make_str('str'), STACK_GLOBAL,
    BINGET, b'\x94',
    BINGET, b'\x66', d3,
    EMPTY_TUPLE, REDUCE,
    b'K\x09',
    TUPLE2, REDUCE, d1,
    TUPLE1, REDUCE, d1,

    # plus[libc.rand() % 9
    TUPLE2, REDUCE,

    # plus[libc.rand() % 9][
    make_str(']['),
    TUPLE2, REDUCE,

    # str(libc.rand() % 9)
    make_str('builtins'), make_str('str'), STACK_GLOBAL,
    BINGET, b'\x94',
    BINGET, b'\x66',
    EMPTY_TUPLE, REDUCE, d2,
    b'K\x09',
    TUPLE2, REDUCE, 
    TUPLE1, REDUCE, d2,

    # plus[libc.rand() % 9][libc.rand() % 9
    TUPLE2, REDUCE,

    # plus[libc.rand() % 9][libc.rand() % 9] = 
    make_str('] = '),
    TUPLE2, REDUCE, d4,

    # str(libc.rand() % 9)
    make_str('builtins'), make_str('str'), STACK_GLOBAL,
    BINGET, b'\x94',
    BINGET, b'\x66',
    EMPTY_TUPLE, REDUCE, d2,
    b'K\x09',
    TUPLE2, REDUCE, d4,
    TUPLE1, REDUCE,

    # plus[libc.rand() % 9][libc.rand() % 9] = (libc.rand() % 9)
    TUPLE2, REDUCE, d1,

    # plus[libc.rand() % 9][libc.rand() % 9] = (libc.rand() % 9) + 1
    make_str(' + 1'), d3,
    TUPLE2, REDUCE,

    TUPLE1, REDUCE,
)

get_input = flat(
    GLOBAL, b'builtins\nexec\n', d1,
    GLOBAL, b'types\nCodeType\n',

    # tuple of CodeType args
    MARK,
        b'K\x00', float_logic_0, d1, b'I0x0\n', b'K\x06', b'L0x9\n', b'K\x03', d1,

        BINBYTES, b'\xf6\x01\x00\x00', b'\x97\x00d\x01d\x02l\x00m\x01}\x00\x01\x00d\x01d\x03l\x02m\x03}\x01\x01\x00\t\x00t\t\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x04\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00}\x02t\x0b\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x02\x00|\x00\x02\x00|\x01|\x02\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\xa0\x06\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x05\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00}\x02g\x00a\x07t\x11\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x01d\x05d\x06\xa6\x03\x00\x00\xab\x03\x00\x00\x00\x00\x00\x00\x00\x00D\x00][}\x03g\x00}\x04t\x11\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x06\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00D\x00]-}\x05|\x04\xa0\t\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00t\x15\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00|\x02|\x03|\x05z\x00\x00\x00\x19\x00\x00\x00\x00\x00\x00\x00\x00\x00\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00\x8c.t\x0e\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\xa0\t\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00|\x04\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00\x8c\\d\x00S\x00#\x00\x01\x00t\x17\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x07\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00t\x19\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x08\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\xa0\r\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\t\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00Y\x00d\x00S\x00x\x03Y\x00w\x01', 

        MARK,
            NONE, float_logic_0, d2,

            MARK,
                # bytes_to_long
                BINGET, b'\x78', d2,
            TUPLE,

            MARK, 
                make_str('b64decode'),
            TUPLE, d3,

            make_str('> '), b'K\x51', b'K\x09',
            make_str('bad'), make_str('os'), b'I0001\n' if use_deadcode else b'I1\n', d2,
        TUPLE, 

        MARK,
            make_str('Crypto.Util.number'), make_str('bytes_to_long'), make_str('base64'), make_str('b64decode'), make_str('input'), make_str('str'), make_str('zfill'), make_str('add'), make_str('range'), make_str('append'), make_str('int'), make_str('print'), make_str('__import__'), make_str('_exit'), 
        TUPLE, d4,

        MARK,
            make_str('bytes_to_long'), make_str('b64decode'), make_str(''), make_str(''), make_str(''), make_str(''), 
        TUPLE, d1,

        make_str(''), make_str(''), make_str(''), b'K\x01', d4,

        NEXT_BUFFER, d4,

        SHORT_BINBYTES, b'\x0c', b'\x8eB2C\x02\x00\xc3\x023C8\x03', EMPTY_TUPLE, EMPTY_TUPLE, d2,
    TUPLE, 

    REDUCE, TUPLE1, REDUCE, d3,
)

check_inp = flat(
    # exec(getattr(['print("no");__import__("os")._exit(1)',''],'__getitem__')(eq(inp,real_solve)))
    GLOBAL, b'builtins\nexec\n', d1,

    GLOBAL, b'builtins\ngetattr\n', d1,
    EMPTY_LIST, make_str('print("no");__import__("os")._exit(1)'), d1, APPEND, make_str(''), d1, APPEND, 
    make_str('__getitem__'), d1,
    TUPLE2, REDUCE, d1,
    
    # operator.eq
    BINGET, b'\x92', d1,

    GLOBAL, b'builtins\neval\n', d1,
    make_str('add'), d1,
    TUPLE1, d1, REDUCE, d1,

    GLOBAL, b'builtins\neval\n', d1,
    make_str('plus'), d1,
    TUPLE1, d1, REDUCE, d1,

    TUPLE2, d1, REDUCE, d1,

    TUPLE1, d1, REDUCE, d1,

    TUPLE1, d1, REDUCE,d1,
)

print_flag = flat(
    GLOBAL, b'builtins\nexec\n',
    GLOBAL, b'types\nCodeType\n',

    # tuple of CodeType args
    MARK,
        b'K\x00', float_logic_0, b'I0x0\n', b'K\x01', b'L0x4\n', b'K\x03',

        BINBYTES, b'\x1c\x01\x00\x00', b'\x97\x00\t\x00t\x01\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x01\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\xa0\x01\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\xa6\x00\x00\x00\xab\x00\x00\x00\x00\x00\x00\x00\x00\x00\xa0\x02\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\xa6\x00\x00\x00\xab\x00\x00\x00\x00\x00\x00\x00\x00\x00}\x00t\x07\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x02\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00t\x07\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00|\x00\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00d\x00S\x00#\x00\x01\x00t\x07\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x03\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00t\t\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x04\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\xa0\x05\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00d\x05\xa6\x01\x00\x00\xab\x01\x00\x00\x00\x00\x00\x00\x00\x00\x01\x00Y\x00d\x00S\x00x\x03Y\x00w\x01',

        MARK,
            NONE, make_str('flag.txt'), make_str('Good job! Here is your flag:'), make_str('Woah woah woah, are you trying to reverse me?'), make_str('os'), b'I0001\n' if use_deadcode else b'I1\n',
        TUPLE,

        MARK,
            make_str('open'), make_str('read'), make_str('strip'), make_str('print'), make_str('__import__'), make_str('_exit'), 
        TUPLE,

        MARK,
            make_str(''),
        TUPLE,

        make_str(''), make_str(''), make_str(''), b'K\x01',

        SHORT_BINBYTES, b'\x87', b'\x80\x00\xf0\x02\x06\x05"\xdd\x0f\x13\x90J\xd1\x0f\x1f\xd4\x0f\x1f\xd7\x0f$\xd2\x0f$\xd1\x0f&\xd4\x0f&\xd7\x0f,\xd2\x0f,\xd1\x0f.\xd4\x0f.\x88\x04\xdd\x08\r\xd0\x0e,\xd1\x08-\xd4\x08-\xd0\x08-\xdd\x08\r\x88d\x89\x0b\x8c\x0b\x88\x0b\x88\x0b\x88\x0b\xf8\xf0\x02\x02\x05"\xdd\x08\r\xd0\x0e=\xd1\x08>\xd4\x08>\xd0\x08>\xdd\x08\x12\x904\xd1\x08\x18\xd4\x08\x18\xd7\x08\x1e\xd2\x08\x1e\x98q\xd1\x08!\xd4\x08!\xd0\x08!\xd0\x08!\xd0\x08!\xd0\x08!\xf8\xf8\xf8', 

        BINBYTES8, b'\x0c\x00\x00\x00\x00\x00\x00\x00', b'\x82A\x11A\x15\x00\xc1\x153B\x0b\x03',

        EMPTY_TUPLE, EMPTY_TUPLE,
    TUPLE,
    REDUCE, TUPLE1, REDUCE,
)


### ACTUAL CHALLENGE ###
TEST = 0

final = flat(
    start, import_sudokum, other_imports, 
    (while_loop+print_out+libc+seed+(modify_plus*11)+get_input+check_inp)*10,
    print_flag, b'.',
)

bytestr = b'\x80\x00\xe0\x040\xd0\x040\xd0\x040\xd0\x040\xd0\x040\xd0\x040\xd8\x04 \xd0\x04 \xd0\x04 \xd0\x04 \xd0\x04 \xd0\x04 \xf0\x02\x0c\x05"\xdd\x0f\x14\x90T\x89{\x8c{\x88\x04\xdd\x0f\x12\x90=\x90=\xa0\x19\xa0\x19\xa84\xa1\x1f\xa4\x1f\xd1\x131\xd4\x131\xd1\x0f2\xd4\x0f2\xd7\x0f8\xd2\x0f8\xb8\x12\xd1\x0f<\xd4\x0f<\x88\x04\xd8\x0e\x10\x88\x03\xdd\x11\x16\x90q\x98"\x98a\x91\x1f\x94\x1f\xf0\x00\x05\t\x1d\xf0\x00\x05\t\x1d\x88A\xd8\x13\x15\x88D\xdd\x15\x1a\x981\x91X\x94X\xf0\x00\x01\r,\xf0\x00\x01\r,\x90\x01\xd8\x10\x14\x97\x0b\x92\x0b\x9dC\xa0\x04\xa0Q\xa0q\xa1S\xa4\t\x99N\x9cN\xd1\x10+\xd4\x10+\xd0\x10+\xd0\x10+\xe5\x0c\x0f\x8fJ\x8aJ\x90t\xd1\x0c\x1c\xd4\x0c\x1c\xd0\x0c\x1c\xd0\x0c\x1c\xf0\x0b\x05\t\x1d\xf0\x00\x05\t\x1d\xf8\xf0\x0c\x02\x05"\xdd\x08\r\x88e\x89\x0c\x8c\x0c\x88\x0c\xdd\x08\x12\x904\xd1\x08\x18\xd4\x08\x18\xd7\x08\x1e\xd2\x08\x1e\x98q\xd1\x08!\xd4\x08!\xd0\x08!\xd0\x08!\xd0\x08!\xd0\x08!\xf8\xf8\xf8'



print(final)
if TEST:
    import pickle
    pickle.loads(
        final+b'K\x01.',
        encoding='utf-8',
        buffers=[bytestr]*10
    ) # ensure it runs with no errors
    with open('test.pickle','wb') as f:
        f.write(final+b'K\x01.')