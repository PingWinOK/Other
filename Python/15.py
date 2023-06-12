print("Введите строку: ")
A = input()
B = ''
for i in range(len(A)):
    if i % 3 != 0:
        B = B + A[i]
print(B)