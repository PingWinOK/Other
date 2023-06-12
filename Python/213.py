from datetime import datetime

def Lim(func):
    def Obertka():
        s = datetime.now()
        rez = func()
        print(datetime.now() - s)
        return rez
    return Obertka

@Lim
def Foo():
    A = 100**3
    #s = datetime.now()
    B = []
    for i in range(A):
        if(i%2 == 0):
           B.append(i)
    #print(datetime.now() - s)
@Lim
def Foo1():
    #s = datetime.now()
    A = [i for i in range(100**3) if i%2 == 0]
    #print(datetime.now() - s)
@Lim
def Foo2():
    #s = datetime.now()
    A = 100**3
    i = 0
    B = []
    while i < A:
        if(i%2 == 0):
            B.append(i)
        i+=1
    #(datetime.now() - s)

l1 = Foo()
l2 = Foo1()
l3 = Foo2()
