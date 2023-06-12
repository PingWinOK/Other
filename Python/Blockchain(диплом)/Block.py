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

    def __init__(self, verified_transactions, hashrate):
        self.nonce = 0
        self.number = data.number
        self.hashrate = hashrate
        self.verified_transactions = verified_transactions
        self.previous_block_hash = data.last_block_hash
        self.time = datetime.strftime(datetime.now(), "%Y.%m.%d %H:%M:%S")
        self.this_hash = (self.Mining())
        self.info = ""
        data.last_block_hash = self.this_hash
        data.number = self.number + 1

    def hash_block(self):
        s = str(self.verified_transactions.number) + str(self.verified_transactions.sender)+ str(self.verified_transactions.recipient)+ str(self.verified_transactions.value)+ str(self.verified_transactions.time)+ str(self.verified_transactions.hash)
        g = str(self.number) + s  + str(self.previous_block_hash) + str(self.time) + str(self.nonce)
        h = SHA256.new(str(g).encode('utf8'))
        return h.hexdigest()

    def Viev_block(self):
        if self.previous_block_hash == None:
            previous_block_hash = "None"
            print("Номер: ", self.number, "Хеш прошлого блока: ", previous_block_hash," \n Хеш этого блока: ", self.this_hash, "Время: ", self.time)
        else:
            print("Номер: ", self.number, "Хеш прошлого блока: ", self.previous_block_hash.hexdigest(),"\n Хеш этого блока: ", self.this_hash, "Время: ", self.time)

    def Mining(self):
        difficult = 7
        prefix = '0' * difficult
        n = self.nonce
        while(True):
            hash = self.hash_block()
            if str(hash)[:difficult] == prefix:
                return hash
            else:
                n += 1
                self.nonce = n
