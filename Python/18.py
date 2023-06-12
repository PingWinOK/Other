print("Введите URL:")
print("http://somesite.com:80/index.html")
URL = "http://somesite.com:80/index.html"
A = URL[0:URL.find("/")-1]
B = URL[URL.find("/")+2:URL.rfind(":")]
C = URL[URL.rfind(":")+1:URL.rfind("/")]
D = URL[URL.rfind("/")+1:URL.rfind(".")]
E = URL[URL.rfind(".")+1:]
print("Протокол:" + A)
print("Домен:" +B)
print("Порт:" +C)
print("Название файла:" +D)
print("Тип файла:" +E)