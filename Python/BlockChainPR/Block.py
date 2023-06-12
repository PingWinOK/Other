import hashlib, json

Blocks = []


class Block:
    prev_hash = None
    transactions = []
    message = ""

    def __init__(self, prev_hash, transactions, message):
        self.prev_hash = prev_hash
        self.transactions = transactions
        self.message = message


Blocks.append(vars(Block(None, [1, 1, 1, 1, 1], "Перевел бабки1")))
Blocks.append(vars(Block(None, [2, 2, 2, 2, 2], "Перевел бабки2")))
Blocks.append(vars(Block(None, [3, 3, 3, 3, 3], "Перевел бабки3")))
Blocks.append(vars(Block(None, [4, 4, 4, 4, 4], "Перевел бабки4")))


def hash_blocks(Blocks):
    prev_hash = None
    for block in Blocks:
        block['prev_hash'] = prev_hash
        block_ser = json.dumps(block, sort_keys=True, indent=4).encode('utf-8')
        print(block_ser)
        block_hash = hashlib.sha256(block_ser).hexdigest()
        prev_hash = block_hash
    return prev_hash


print("Оригинальный хеш")
print(hash_blocks(Blocks))
"""print("Вмешательство")
Blocks[2]['transactions'][3] = 6
print(hash_blocks(Blocks))"""


