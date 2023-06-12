A = (str(input("Введите строку:")))
A = A.split(" ")
for i in range(len(A)):
    if ((A[i])[0]).isupper():
        A[i] = A[i].upper()
print(" ".join(A)) 
