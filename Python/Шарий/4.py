print("Введите текст: ")
A = input().split(" ")
i = 0
A.sort()
print(A)
print("______Больше 7 символов______")
for i in A:
    if len(i) > 7:
        print(i)
print("______Меньше 7 символов и больше 4 символов______ ")
for i in A:
    if (len(i) <= 7) and (len(i) >= 4):
        print(i)
print("______Остальные______")
for i in A:
    if len(i) < 4:
        print(i)
