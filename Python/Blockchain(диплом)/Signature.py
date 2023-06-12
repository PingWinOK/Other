import base64
import binascii

import Crypto
import Crypto.Random
from Crypto.Random import get_random_bytes
from Crypto.Cipher import PKCS1_v1_5, PKCS1_OAEP
from Crypto.Hash import SHA256
from Crypto.PublicKey import RSA
from Crypto.Signature import PKCS1_v1_5, pkcs1_15


def Gen():
    random = Crypto.Random.new().read
    private_key = RSA.generate(1024, random)
    public_key = private_key.publickey()
    return private_key, public_key


def Encript(hash, private_key):
    signature = pkcs1_15.new(private_key).sign(hash)
    return signature

def Verify(hash, signature,public_key):
    try:
        pkcs1_15.new(public_key).verify(hash, signature)
        print("Сигнатура валидна")
    except (ValueError, TypeError):
        print("Сигнатура невалидна")
