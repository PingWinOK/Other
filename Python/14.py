print("Введите строку: ")
Stroka = input()
A = Stroka[:Stroka.find("h") + 1] 
B = Stroka[Stroka.find("h") + 1:Stroka.rfind("h")]
C = Stroka[Stroka.rfind("h"):]
Stroka = A + B.replace("h", "H") + C
print(Stroka)