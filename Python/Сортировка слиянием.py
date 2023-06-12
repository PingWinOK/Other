a =[1,5,2,3,8,6,7,10]
def merg(A,B):
    i,j = 0,0
    Fin = []
    while i < len(A) and j < len(B):
        if A[i] <= B[j]:
            Fin.append(A[i])
            i += 1
        else:
            Fin.append(B[j])
            j += 1
    Fin += A[i:]
    Fin += B[j:]
    return Fin

def sliyanie(a):
    if len(a) <= 1:
        return
    q = len(a)//2
    C = []
    L = []
    L = a[:q]
    R = []
    R = a[q:]
    sliyanie(L)
    sliyanie(R)
    C = merg(L,R)      
    k = 0
    for i in C:
        a[k] = i
        k += 1
    return a

print(sliyanie(a))
