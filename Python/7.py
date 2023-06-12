print("Введите стоку: ")
s = input()
print(s[(len(s) + 1) // 2:] + s[:(len(s) + 1) // 2])