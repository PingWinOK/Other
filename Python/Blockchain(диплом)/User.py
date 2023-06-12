import base64
import binascii
import Signature
import Transaction
import Crypto
import Crypto.Random
from Crypto.Random import get_random_bytes
from Crypto.Cipher import PKCS1_v1_5, PKCS1_OAEP
from Crypto.Hash import SHA256
from Crypto.PublicKey import RSA
from Crypto.Signature import PKCS1_v1_5, pkcs1_15


class User:
    def __init__(self, transaction, balace,):
        priv, pub = Signature.Gen()
        self.transaction = transaction
        self.balace = balace
        self.public_key = pub
        self.private_key = priv