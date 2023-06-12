m=int.from_bytes("Danil".encode(),"big")
e = 5
print("e = ",e)
q = 35742549198872617291353508656626642567
print("q = ",q)
p = 359334085968622831041960188598043661065388726959079837
print("p = ",p)
n = q * p
print("n = ",n)
#phi=(p - 1)*(q-1)
c = pow(m,e,n)
print("c =",c)
def iroot(a, b):
    if b < 2:
        return b
    a1 = a - 1
    c = 1
    d = (a1 * c + b // (c ** a1)) // a
    e = (a1 * d + b // (d ** a1)) // a
    while c not in (d, e):
        c, d, e = d, e, (a1 * e + b // (e ** a1)) // a
    return min(d, e)
x=2185060952897314094136326517364215260684060392375315770368
n=5
m =iroot(n, x)
print ('m n-root is',m)
s1=m.to_bytes((m.bit_length() + 7) // 8, 'big').decode()
print('decript',s1)

