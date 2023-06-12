print("Введите строку: ")
A = input()
if A.count('f') == 1:
    print(A.find('f'))
elif A.count('f') >= 2:
    print(A.find('f'), A.rfind('f'))
