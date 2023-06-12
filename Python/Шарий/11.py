def frange(start,end,step):
    st = start
    start = float(start)
    end = float(end)
    step = float(step)

    A = []
    A.append(start)
    end = int((end-start)/step)
   
    for i in range(st,end):
        A.append(A[i-1] + step)
    return A
   
for y in frange(1, 5, 0.1):
    print (round(y,2)) 