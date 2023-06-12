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
        self.Tree = []
        self.count = len(self.Blocks)

    def NewBlock(self, Tran, hashrate = 0,i = ''):
        B = Block.Block(Tran,hashrate)
        if i == 'to share' or len(self.Tree) > 0:
            self.Blocks.append(B)
            self.Tree.append(B)
        else:
            self.Blocks.append(B)

        if len(self.Tree) == 3:
            HB,HT = 0,0
            for B in self.Blocks[-3:]:
                HB += B.hashrate
            for T in self.Tree:
                HT += T.hashrate
            if HB <= HT:
                self.Tree.clear()
            else:
                self.Merge(self.Tree)
                self.Tree.clear()

    def Merge(self,Tree):
        del self.Blocks[Tree[0].number:Tree[len(Tree)-1].number+1]
        for i in Tree:
            self.Blocks.append(i)


    def ChekBlocks(self):
        for i in self.Blocks:
            A = i.hash_block()
            B = i.this_hash
            if A != B:
                print("Блок ", i.number, " невалидный")
            else:
                print("Блок ", i.number, " валидный")

    def Viev_Blockchein(self):
        for i in self.Blocks:
            print(i)
