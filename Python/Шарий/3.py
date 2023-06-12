print("Введите номер карты (16 цифр): ")
A = str(input())
a = A[0:4]
b = A[len(A)-4:len(A)]
z = "*" * 4
print(a + " " + z + " "+ z + " " + b)
