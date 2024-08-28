from Crypto.Hash import SHAKE256

q = 12 * 1024 + 1

logn = {
    2: 1,
    4: 2,
    8: 3,
    16: 4,
    32: 5,
    64: 6,
    128: 7,
    256: 8,
    512: 9,
    1024: 10
}


# Bytelength of the signing salt and header
HEAD_LEN = 1
SALT_LEN = 40
SEED_LEN = 56


# Parameter sets for Falcon:
# - n is the dimension/degree of the cyclotomic ring
# - sigma is the std. dev. of signatures (Gaussians over a lattice)
# - sigmin is a lower bounds on the std. dev. of each Gaussian over Z
# - sigbound is the upper bound on ||s0||^2 + ||s1||^2
# - sig_bytelen is the bytelength of signatures
Params = {
    # FalconParam(2, 2)
    2: {
        "n": 2,
        "sigma": 144.81253976308423,
        "sigmin": 1.1165085072329104,
        "sig_bound": 101498,
        "sig_bytelen": 44,
    },
    # FalconParam(4, 2)
    4: {
        "n": 4,
        "sigma": 146.83798833523608,
        "sigmin": 1.1321247692325274,
        "sig_bound": 208714,
        "sig_bytelen": 47,
    },
    # FalconParam(8, 2)
    8: {
        "n": 8,
        "sigma": 148.83587593064718,
        "sigmin": 1.147528535373367,
        "sig_bound": 428865,
        "sig_bytelen": 52,
    },
    # FalconParam(16, 4)
    16: {
        "n": 16,
        "sigma": 151.78340713845503,
        "sigmin": 1.170254078853483,
        "sig_bound": 892039,
        "sig_bytelen": 63,
    },
    # FalconParam(32, 8)
    32: {
        "n": 32,
        "sigma": 154.6747794602761,
        "sigmin": 1.1925466358390344,
        "sig_bound": 1852696,
        "sig_bytelen": 82,
    },
    # FalconParam(64, 16)
    64: {
        "n": 64,
        "sigma": 157.51308555044122,
        "sigmin": 1.2144300507766141,
        "sig_bound": 3842630,
        "sig_bytelen": 122,
    },
    # FalconParam(128, 32)
    128: {
        "n": 128,
        "sigma": 160.30114421975344,
        "sigmin": 1.235926056771981,
        "sig_bound": 7959734,
        "sig_bytelen": 200,
    },
    # FalconParam(256, 64)
    256: {
        "n": 256,
        "sigma": 163.04153322607107,
        "sigmin": 1.2570545284063217,
        "sig_bound": 16468416,
        "sig_bytelen": 356,
    },
    # FalconParam(512, 128)
    512: {
        "n": 512,
        "sigma": 165.7366171829776,
        "sigmin": 1.2778336969128337,
        "sig_bound": 34034726,
        "sig_bytelen": 666,
    },
    # FalconParam(1024, 256)
    1024: {
        "n": 1024,
        "sigma": 168.38857144654395,
        "sigmin": 1.298280334344292,
        "sig_bound": 70265242,
        "sig_bytelen": 1280,
    },
}

def hash_to_point(message, salt, n):
    """
    Hash a message to a point in Z[x] mod(Phi, q).
    Inspired by the Parse function from NewHope.
    """
    if q > (1 << 16):
        raise ValueError("The modulus is too large")

    k = (1 << 16) // q
    # Create a SHAKE object and hash the salt and message.
    shake = SHAKE256.new()
    shake.update(salt)
    shake.update(message)
    # Output pseudorandom bytes and map them to coefficients.
    hashed = [0 for i in range(n)]
    i = 0
    j = 0
    while i < n:
        # Takes 2 bytes, transform them in a 16 bits integer
        twobytes = shake.read(2)
        elt = (twobytes[0] << 8) + twobytes[1]  # This breaks in Python 2.x
        # Implicit rejection sampling
        if elt < k * q:
            hashed[i] = elt % q
            i += 1
        j += 1
    return hashed


def compress(v, slen):
    """
    Take as input a list of integers v and a bytelength slen, and
    return a bytestring of length slen that encode/compress v.
    If this is not possible, return False.

    For each coefficient of v:
    - the sign is encoded on 1 bit
    - the 7 lower bits are encoded naively (binary)
    - the high bits are encoded in unary encoding
    """
    print(slen)
    u = ""
    for coef in [int(vi) if vi < q//2 else -1*(int(q) - int(vi)) for vi in v]:
        # Encode the sign
        s = "1" if coef < 0 else "0"
        # Encode the low bits
        s += format(int((abs(coef) % (1 << 7))), '#09b')[2:]
        # Encode the high bits
        s += "0" * int(abs(coef) >> 7) + "1"
        u += s
    # The encoding is too long
    if len(u) > 8 * slen:
        print(len(u) , 8 * slen)
        return False
    u += "0" * (8 * slen - len(u))
    w = [int(u[8 * i: 8 * i + 8], 2) for i in range(len(u) // 8)]
    x = bytes(w)
    print(x)
    return x