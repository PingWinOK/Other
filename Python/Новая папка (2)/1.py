A=[]
B = []
f=''
handle = open(r"F:\Вуз\Питон\Новая папка (2)\1input.txt", "r") 
A = handle.read()
print(A)
handle.close()
#Читаем файл 
for i in range(len(A)):
    if A[i].lower() in 'qwertyuiopasdfghjklzxcvbnm': #Ищем буквы
        B+=A[i] #записываем буквы в массив b
        A=A[:i]+"_"+A[i+1:] #заменяем буквы на "_"
C=A.split('_')[1:] #засовываем в список "с" цифры по разделителю  
for i in range(len(B)):
    f+=(B[i]*int(C[i])) #умножаем буквы на цифры  
print(f)
handle = open(r"F:\Вуз\Питон\Новая папка (2)\1output.txt", "w")
handle.write("".join(f))
handle.close()
print("Готово")
#Записываем в файл 
