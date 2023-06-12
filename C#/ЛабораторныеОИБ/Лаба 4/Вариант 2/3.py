def gcd(n,m):
        a, a_ = 0, 1
        b, b_ = 1, 0
    
        c, d = n, m
    
        q = c // d
        r = c % d
        while r:
            c, d = d, r
            a_, a = a, a_ - q * a
            b_, b = b, b_ - q * b
        
            q = c // d
            r = c % d
        return (d, a, b)

def modinv(r, m):
    g, x, y = gcd(r, m)
    if g != 1:
        raise Exception('modular inverse does not exist')
    else:
        return x % m

e1 = 37
e2 = 41
n = 69796207001437515315691732806410607223334110920429890945679360000001 
c2 = 11847015472181896556020581271198191821137352612225157929235606090089
c1 = 48059162955492665514138549177774571973376041748346039362224761156906
s=-9
r=10
g=e2*s+e1*r
print('g',g)
r= (-1) * r;
c1_inv = modinv(c1, n)
print('c1_inv = ' + str(c1_inv))
c1r = pow(c1_inv,r,n)
print('c1**r = ' + str(c1r))
 
c2s = pow(c2,s,n)
print('c2**s = ' + str(c2s))
m = 0
d=c1r * c2s
print('d = ' + str(d))
m = d % n
print('m = ' + str(m))

text=m.to_bytes((m.bit_length() + 7) // 8, 'big').decode()
print(text)
