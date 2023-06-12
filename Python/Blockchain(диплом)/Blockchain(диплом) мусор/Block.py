import binascii
import collections
import datetime
import random
from datetime import datetime
import Crypto
import Crypto.Random
from Crypto.Cipher import PKCS1_v1_5
from Crypto.Hash import SHA256
from Crypto.PublicKey import RSA
from Crypto.Signature import PKCS1_v1_5
import Signature
import Transaction
import User
import data


class Block:
    def __init__(self, verified_transactions,difficult):
        self.nonce = 0
        self.number = data.number
        self.verified_transactions = verified_transactions
        self.previous_block_hash = data.last_block_hash
        self.time = datetime.strftime(datetime.now(), "%Y.%m.%d %H:%M:%S")
        self.difficult = difficult
        self.this_hash = self.Mining()
        self.info = ""
        data.last_block_hash = self.this_hash
        data.number = self.number + 1

    def hash_block(self):
        g = str(self.number) + str(self.verified_transactions) + str(self.previous_block_hash) + str(self.time) + str(self.nonce)
        h = SHA256.new(str(g).encode('utf8'))
        return h

    def Viev_block(self):
        previous_block_hash = ""
        if self.previous_block_hash == None:
            previous_block_hash = "None"
            print("Номер: ", self.number, "Хеш прошлого блока: ", previous_block_hash,
                  "Хеш этого блока: ", self.this_hash.hexdigest(), "Время: ", self.time)
        else:
            print("Номер: ", self.number, "Хеш прошлого блока: ", self.previous_block_hash.hexdigest(),
                  "Хеш этого блока: ", self.this_hash.hexdigest(), "Время: ", self.time)

    def Mining(self):
        global hash
        prefix = '0' * self.difficult
        n = self.nonce
        while(True):
            hash = self.hash_block()
            if str(hash.hexdigest())[:self.difficult] == prefix:
                return hash
            else:
                n += 1
                self.nonce = n
