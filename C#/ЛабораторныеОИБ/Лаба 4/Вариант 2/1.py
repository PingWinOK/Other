
text = "Kulakov Danil"
m=int.from_bytes(text.encode(),"big")
e = 13
p=8683317618811886495518194401279999999 
q=263130836933693530167218012159999999

n = p * q
phi=(p - 1)*(q-1)
print(phi)

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

print(egcd(e, phi))
inv = mulinv(e, phi)
print('iverse', inv)
d = inv

c=pow(m,e,n)
print(c)
m=pow(c,d,n)
print(m)
m = m.to_bytes((m.bit_length() + 7) // 8, 'big').decode()
print(m)


