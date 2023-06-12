A = str(input('Введите текст\n')).lower()
B = [] 
for i in A:
    if A.count(i) == 1:
        B.append(i)
print(' '.join(B))
