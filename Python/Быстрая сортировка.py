a =[1,5,2,3,8,6,7,10]
def hard_sort(a):
    if len(a) <= 1:
        return
    q = a[0]
    A1 = []
    A2 = []
    A3 = []
    for i in a:
        if i < q:
            A1.append(i)
        elif i > q:
            A2.append(i)
        elif i == q:
            A3.append(i)
    hard_sort(A1)
    hard_sort(A2)
    L = 0
    for i in A1+A3+A2:
        a[L] = i
        L +=1
    return a
print(hard_sort(a))
