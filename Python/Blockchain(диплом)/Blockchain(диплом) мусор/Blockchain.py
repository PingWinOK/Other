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
import Block


class Blockchain:
    def __init__(self):
        self.Blocks = []
        self.count = len(self.Blocks)

    def NewBlock(self, Tran,difficult):
        self.Blocks.append(Block.Block(Tran,difficult))

    def ChekBlocks(self):
        for i in self.Blocks:
            A = i.hash_block()
            B = i.this_hash
            if A.hexdigest() != B.hexdigest():
                print("Блок ", i.number, " не валидный")
            else:
                print("Блок ", i.number, " валидный")

    def Viev_Blockchein(self):
        for i in self.Blocks:
            print(i)
