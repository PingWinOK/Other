A = [chr(ord("а") + i) for i in range(32)]
print(A)
print("Введите слово,которое нужно зашифровать: ")
Slovo = str(input())
Slovo = Slovo.split("")
print("Введите число: ")
Bukva = int(input())
print(Slovo)
print(Bukva)
for i in range(Slovo):
    
