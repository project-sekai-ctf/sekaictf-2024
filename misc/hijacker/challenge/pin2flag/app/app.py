import os

from pow import Challenge, check

FLAG = os.getenv("FLAG")
POW_DIFFICULTY = int(os.getenv("POW_DIFFICULTY") or 250000)

print("Please provide a proof of work to continue by running this command:")
challenge = Challenge.generate(POW_DIFFICULTY)
print(f"curl -sSfL https://pwn.red/pow | sh -s { challenge }\n")
sol = input("Solution: ")

try:
    success = check(challenge, sol)
except ValueError:
    success = False

if success:
    pin = input("PIN: ")
    if pin == "593720":
        print(FLAG)
    else:
        print("Incorrect PIN.")
else:
    print("Incorrect proof of work.")
