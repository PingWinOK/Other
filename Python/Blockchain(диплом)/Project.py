import binascii
import collections
import datetime
import random
import time
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

"""message = b'Roses Are Red'
h = SHA256.new(message)
message = b'Roses are Red'
h_BAD = SHA256.new(message)
print(h.hexdigest())
priv, pub = Signature.Gen()
ENCR = Signature.Encript(h, priv)
VER = Signature.Verify(h, ENCR, pub)

priv_BAD, pub_BAD = Signature.Gen()
ENCR_BAD = Signature.Encript(h, priv_BAD)
VER_BAD1 = Signature.Verify(h, ENCR_BAD, pub)
VER_BAD2 = Signature.Verify(h, ENCR, pub_BAD)
VER_BAD3 = Signature.Verify(h_BAD, ENCR, pub)"""

Users = []
for i in range(10):
    T = []
    Users.append(User.User(T, 100))
    #print(Users[i].transaction,Users[i].balace,Users[i].public_key,Users[i].private_key)"""


t = Transaction.Transaction(1, Users[0].public_key, Users[1].public_key, 10)
t.sign_transaction(Users[0].private_key)
for U in Users:
    U.transaction.append(t)


Users[0].transaction[0].value = 100

for U in Users:
    U.transaction[0].chek()

Blocks = []
Blocks.append(Block.Block(t,100))
Blocks.append(Block.Block(t,200))
Blocks.append(Block.Block(t,300))
Blocks.append(Block.Block(t,400))
"""for B in Blocks:
    B.Viev_block()"""
"""BCH = Blockchain.Blockchain()
start_time = time.time()
BCH.NewBlock(t,342423424)
BCH.NewBlock(t,435345233)
BCH.NewBlock(t,877664554)
BCH.NewBlock(t,743324556)
BCH.NewBlock(t,423454332)
BCH.NewBlock(t,532543456)
BCH.NewBlock(t,453452354)
BCH.NewBlock(t,352556456)
BCH.NewBlock(t,364345234)
BCH.NewBlock(t,564323455)
print("--- %s seconds ---" % (time.time() - start_time))"""
#BCH.ChekBlocks()
"""BCH.NewBlock(t,114324235,'to share')
BCH.NewBlock(t,423454332)
BCH.NewBlock(t,532543456)"""
#BCH.Blocks[0].verified_transactions.value = 1000
#BCH.ChekBlocks()
"""for U in Users:
    U.transaction[0].chek()"""
#BCH.NewBlock(t,'to share')
#BCH.Tree[0].verified_transactions.value = 1000
#for i in BCH.Blocks:
    #print(i.this_hash.hexdigest())
#print(BCH.Blocks[0].Mining().hexdigest())
#print(BCH.Tree[0].Mining().hexdigest())
"""BCH.ChekBlocks()
print(BCH.Blocks[2].verified_transactions.value)"""
