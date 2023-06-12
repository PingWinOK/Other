A=[]
B = []
f=''
#handle = open(r"F:\Вуз\Питон\Новая папка (2)\2input.txt", "r") 
#A = handle.read()
#print(A)
#handle.close()
#Читаем файл 
a = input().lower().split()
max_a = max([a.count(i) for i in set(a)])
c = {i: a.count(i) for i in set(a) if a.count(i) == max_a}
print(sorted(c)[0],c[sorted(c)[0]])
print(f)
#handle = open(r"F:\Вуз\Питон\Новая папка (2)\2output.txt", "w")
#handle.write("".join(f))
#handle.close()
#print("Готово")
#Записываем в файл 