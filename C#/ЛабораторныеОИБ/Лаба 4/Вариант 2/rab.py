m=int.from_bytes("LabaFour".encode(),"big")
e1 = 37
e2 = 41
q =265252859812191058636308479999999
p = 263130836933693530167218012159999999
n = q * p
c1 = pow(m,e1,n)
c2 = pow(m,e2,n)
print(c1)
print(c2)
def egcd(a, b):
    if a == 0:
        return (b, 0, 1)
    else:
        g, x, y = egcd(b % a, a)
        return (g, y - (b // a) * x, x)

def mulinv(b, n):
    g, x, _ = egcd(b, n)
    print(g, x, _)
    if g == 1:
        return x % n

print(egcd(e1, e2))
inv=mulinv(e1, e2)
print('iverse',inv)
