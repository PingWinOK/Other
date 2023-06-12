print("Введите строку: ")
STR = input()
A = STR[:STR.find('h')] 
B = STR[STR.find('h'):STR.rfind('h') + 1]
C = STR[STR.rfind('h') + 1:]
STR = A + B[::-1] + C
print(STR)