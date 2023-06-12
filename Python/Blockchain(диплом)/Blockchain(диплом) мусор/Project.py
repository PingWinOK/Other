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
import Blockchain
import Block

"""message = b'qqqq'
priv, pub = Signature.Gen()
h = SHA256.new(message)
# print(h.hexdigest())


ZEP = Signature.Encript(h, priv)
REP = Signature.Verify(h, ZEP, pub)"""

Users = []
for i in range(10):
    T = []
    priv, pub = Signature.Gen()
    Users.append(User.User(T, 100, pub, priv))
    #print(Users[i].transaction,Users[i].balace,Users[i].public_key,Users[i].private_key)

t = Transaction.Transaction(1, Users[0].public_key, Users[1].public_key, 1)
t.sign_transaction(Users[0].private_key)
for U in Users:
    U.transaction.append(t)


"""Users[0].transaction[0].value = 100 #Транзакция не будет валидна

for U in Users:
    U.transaction[0].chek()"""
"""Blocks = []
Blocks.append(Block.Block(t))
Blocks.append(Block.Block(t))
Blocks.append(Block.Block(t)) 
Blocks.append(Block.Block(t))"""
BCH = Blockchain.Blockchain()
BCH.NewBlock(t,1)
BCH.NewBlock(t,2)
BCH.NewBlock(t,3)
BCH.NewBlock(t,4)
BCH.NewBlock(t,5)
for i in BCH.Blocks:
    print(i.this_hash.hexdigest())
#print(BCH.Blocks[1].Mining().hexdigest())

#BCH.ChekBlocks()

