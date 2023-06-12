import hashlib
import sys
from PyQt5.QtWidgets import QApplication, QWidget
import binascii
from datetime import datetime
import collections
import Crypto
import Crypto.Random
from Crypto.Hash import SHA256
from Crypto.PublicKey import RSA
from Crypto.Signature import PKCS1_v1_5

import data

IBCoins = []
transactions = []
last_block_hash = ""
last_transaction_index = 0


class Polz:
    def __init__(self):
        random = Crypto.Random.new().read
        self._private_key = RSA.generate(1024, random)
        self._public_key = self._private_key.publickey()
        self._signer = PKCS1_v1_5.new(self._private_key)

    @property
    def identity(self):
        return binascii.hexlify(self._public_key.exportKey(format='DER')).decode('ascii')



class Block:
    def __init__(self):
        self.verified_transactions = []
        self.previous_block_hash = ""
        self.Nonce = ""




class Transaction:
    def __init__(self, sender, recipient, value):
        self.sender = sender
        self.recipient = recipient
        self.value = value
        self.time = datetime.strftime(datetime.now(), "%Y.%m.%d %H:%M:%S")

    def sign_transaction(self):
        private_key = self.sender._private_key
        signer = PKCS1_v1_5.new(private_key)
        h = SHA256.new(str(self.to_dict()).encode('utf8'))

        return binascii.hexlify(signer.sign(h)).decode('ascii')

    def to_dict(self):
        if self.sender == "Genesis":
            identity = "Genesis"
        else:
            identity = self.sender.identity

        return collections.OrderedDict({
            'sender': identity,
            'recipient': self.recipient,
            'value': self.value,
            'time': self.time})


"""
def display_transaction(transaction):
    SlovarTranzakcij = transaction.to_dict()
    print("sender: " + SlovarTranzakcij['sender'])
    print('-----')
    print("recipient: " + SlovarTranzakcij['recipient'])
    print('-----')
    print("value: " + str(SlovarTranzakcij['value']))
    print('-----')
    print("time: " + str(SlovarTranzakcij['time']))
    print('-----')
    for transaction in transactions:
        display_transaction(transaction)
        print('--------------')


def dump_blockchain(self):
    print("Количество блоков в цепочке: " + str(len(self)))
    for x in range(len(IBCoins)):
        block_temp = IBCoins[x]
        print("block # " + str(x))
        for transaction in block_temp.verified_transactions:
            display_transaction(transaction)
            print('--------------')
        print('=====================================')
"""

def sha256(message):
    return hashlib.sha256(message.encode('ascii')).hexdigest()


def mine(message, difficulty=1):
    assert difficulty >= 1
    prefix = '1' * difficulty
    for x in range(1000):
        HashMine = sha256(str(hash(message)) + str(x))
        if HashMine.startswith(prefix):
            print("Понадобилось " + str(x) + " итераций для нахождения дайджеста: " + HashMine)
            return HashMine

"""
Dinesh = Polz()
Ramesh = Polz()
Seema = Polz()
Vijay = Polz()


t2 = Transaction(Dinesh, Seema.identity, 6.0)
t2.sign_transaction()
transactions.append(t2)
t3 = Transaction(Ramesh, Vijay.identity, 2.0)
t3.sign_transaction()
transactions.append(t3)
t4 = Transaction(Seema, Ramesh.identity, 4.0)
t4.sign_transaction()
transactions.append(t4)
t5 = Transaction(Vijay, Seema.identity, 7.0)
t5.sign_transaction()
transactions.append(t5)
t6 = Transaction(Ramesh, Seema.identity, 3.0)
t6.sign_transaction()
transactions.append(t6)
t7 = Transaction(Seema, Dinesh.identity, 8.0)
t7.sign_transaction()
transactions.append(t7)
t8 = Transaction(Seema, Ramesh.identity, 1.0)
t8.sign_transaction()
transactions.append(t8)
t9 = Transaction(Vijay, Dinesh.identity, 5.0)
t9.sign_transaction()
transactions.append(t9)
t10 = Transaction(Vijay, Ramesh.identity, 3.0)
t10.sign_transaction()
transactions.append(t10)

block = Block()
for i in range(3):
    temp_transaction = transactions[last_transaction_index]
    block.verified_transactions.append(temp_transaction)
    last_transaction_index += 1
block.previous_block_hash = last_block_hash
block.Nonce = mine(block, 2)
digest = hash(block)
IBCoins.append(block)
last_block_hash = digest

# Miner 2 adds a block
block = Block()

for i in range(3):
    temp_transaction = transactions[last_transaction_index]
    block.verified_transactions.append(temp_transaction)
    last_transaction_index += 1
block.previous_block_hash = last_block_hash
block.Nonce = mine(block, 2)
digest = hash(block)
IBCoins.append(block)
last_block_hash = digest

# Miner 3 adds a block
block = Block()
for i in range(3):
    temp_transaction = transactions[last_transaction_index]
    block.verified_transactions.append(temp_transaction)
    last_transaction_index += 1
block.previous_block_hash = last_block_hash
block.Nonce = mine(block, 2)
digest = hash(block)
IBCoins.append(block)
last_block_hash = digest

dump_blockchain(IBCoins)"""
