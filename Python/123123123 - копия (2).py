def Bin(A,key):
    left = -1
    right = len(A)
    while right - left > 1:
        midle = (right + left)//2
        if A[midle] < key:
            left = midle
        else:
            right = midle
    return right

A = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
print(Bin(A,13))
