print("Введите строку: ")
A = input()
A = A[:A.find('h')] + A[A.rfind('h') + 1:]
print(A)