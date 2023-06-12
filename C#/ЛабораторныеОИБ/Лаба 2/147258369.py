Fraza="шж щлужнлрш июъ тфущзй, л июъ ыьъэюъ эыфэъц прч".split(" ")
for i in Fraza:
    for d in i:
        print(int(ord(d)))
a = ord('а')
A = ord('А')
AlfLil =''.join([chr(i) for i in range(a,a+32)])
AlfBig=''.join([chr(i) for i in range(A,A+32)])
print(AlfLil , AlfBig)
