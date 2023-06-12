print("Введите два слова: ")
s = input()
A = s[:s.find(" ")]
B = s[s.find(" ") + 1:]
print(B + " " + A)