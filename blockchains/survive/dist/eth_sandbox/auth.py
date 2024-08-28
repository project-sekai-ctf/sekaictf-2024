import os

def get_shared_secret():
    return os.getenv("SHARED_SECRET", "secret_key")