import base64
import binascii
import collections
from datetime import datetime
import Signature
import Crypto
import Crypto.Random
from Crypto.Random import get_random_bytes
from Crypto.Cipher import PKCS1_v1_5, PKCS1_OAEP
from Crypto.Hash import SHA256
from Crypto.PublicKey import RSA
from Crypto.Signature import PKCS1_v1_5, pkcs1_15


class Transaction:
    def __init__(self, number,sender, recipient, value):
        self.number = number
        self.sender = sender
        self.recipient = recipient
        self.value = value
        self.time = datetime.strftime(datetime.now(), "%Y.%m.%d %H:%M:%S")
        self.hash = self.hash_transaction()



    def hash_transaction(self):
        g = str(self.number) + str(self.sender) + str(self.recipient) + str(self.value) + str(self.time)
        h = SHA256.new(str(g).encode('utf8'))
        return h

    def sign_transaction(self,private_key):
        signature = Signature.Encript(self.hash, private_key)
        self.sing = signature
        return signature

    def chek(self):
        Signature.Verify(self.hash_transaction(),self.sing,self.sender)

