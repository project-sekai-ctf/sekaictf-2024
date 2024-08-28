from falcon import falcon
from flag import flag
from timeout_decorator import timeout

@timeout(30)
def main():
    sk = falcon.SecretKey(64)
    pk = falcon.PublicKey(sk)
    print(pk)

    your_sig = bytes.fromhex(input("what is your sig? >"))

    if pk.verify(b"Can you break me", your_sig):
        print("well done!!")
        print(flag)
        exit()

    print("Broken your wing T_T")


main()