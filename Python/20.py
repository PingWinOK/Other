STR = "В MMXIII году в школе CXXIII состоялся очередной выпуск XI классов"
A = {'M': 1000 ,'CM': 900,'D': 500,'CD': 400,'C':100,'XC':90,'L':50,'XL':40,'X':10,'IX':9,'V':5,'IV':4,'I':1,' ':0}
D = []
for letter in STR:
    D.append(A[letter])
print(D)
