from datetime import datetime

def Lim(func):
    def Obertka():
        s = datetime.now()
        rez = func()
        print(datetime.now() - s)
        return rez
    return Obertka

@Lim
def Fib(A):
    if(A <= 1):
        return A
    return Fib(A-1) + Fib(A-2)
Fib(1000)

@Lim
def F(A):
    Fib = [0,1]+[0]*(A-1)
    for i in range(2,A+1):
        Fib[i] = Fib[i-1]+ Fib[i-2]
    print(Fib[A])
F(1000)

l1 = Fib()
l2 = F()

