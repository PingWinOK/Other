from functools import reduce
a = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
D = list(filter(lambda x : x < 5,a))
print(D)

a1 = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
b1 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
D1 = list(filter(lambda x: x in b1, a1))
print(D1)

b2 = [100, 15, 30, 60, 5, 6, 7, 8, 9, 10, 11, 12, 13]
D2 = list(filter(lambda x: x%15==0,b2))
print(D2)

b3 = [1, 15, 30, 60, 5, 6, 7, 8, 9, 3, 2, 3, 2]
D3 = reduce(lambda x, x1: x*x1,b3)
print(D3)

b4 = [1, 15, 30, 60, 5, 6, 7, 8, 9, 3, 2, 3, 2]
D4 = reduce(lambda x,y: x if (x > y) else y, b4)
print(D4)

b3 = [1, 15, 30, 60, 5, 6, 7, 8, 9, 3, 2, 3, 2]
D3 = reduce(lambda x, x1: x+x1,b3)
print(D3)

def D(a1,b1):
    Q =list(filter(lambda x: x not in b1, a1))
    print(Q)
    
a1 = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
b1 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
D(a1,b1)

A = int(input())
R = reduce(lambda x,y: x * y, range(2,A+1))
print(R) 
