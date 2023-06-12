print("Введите строку: ")
A = input()
if A.count('f') == 1:
    print(-1)
elif A.count('f') < 1:
    print(-2)
else:
    print(A.find('f', A.find('f') + 1))