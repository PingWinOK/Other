A = input("Введите пароль: ")
#Проверка на цифры
C = 0
for i in A:
    if i.isdigit():
        C += 1
#print(C)
#Проверка на буквы
B = 0
for i in A:
    if i.isalpha():
        B += 1
#print(B)
#Проверка на спецсимволы
S = 0
s = ["!","@","#","$","%","^","&","*","(",")","_","+","=","-","/","?","<",">","'","|","[","]","{","}",".",",",":",";"]
for i in A:
    for j in s:
        if i == j:
            S += 1
#print(S)
#Проверка на регистр
U = 0
L = 0
for i in A:
    if i.islower():
        L += 1
    if i.isupper():
        U += 1
#print(L,U)
#Проверка на длинну
D = len(A)

#Итог
I = D+L+U+B+S+C
if I > 30 and I < 50:
    print("Ваш пароль средний")
elif I < 30:
    print("Ваш пароль слабый")
elif I > 50:
    print("Ваш пароль сложный")

