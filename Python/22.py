STR = "1+2-3"
A = STR.replace("-", " ")
A = A.replace("+", " ")
A = map(int,A.split(" "))
B = STR
for d in '1234567890':
    B = B.replace(d, " ")
B = B.split(" ")
print(A)
print(B)