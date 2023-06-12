print("Введите ФИО:")
A = input()
A1 = A[0:A.find(" ")+1]
A2 = A[A.rfind(" ")+1:len(A)]
A3 = A[A.find(" ")+1:A.rfind(" ")+1]
print(A1 + A3[0] + "." + A2[0] + ".")
