print("Введите файл: ")
A = input()
print("Введите расширение:")
B = input()
Raz = A[A.rfind("."):]
A = A.replace(Raz,"." + B)
print(A)