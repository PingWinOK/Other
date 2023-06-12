W = [0,7,3,1,5,4]
P = [0,10,4,2,6,7]
S = 12
n = len(W)-1
F = [[0]*(S + 1) for i in range(n + 1)]
for i in range(1,n + 1):
    for j in range(S + 1):
        if j >= W[i]:
            F[i][j] = max(F[i - 1][j],F[i - 1][j - W[i]] + P[i])
        else:
            F[i][j] = F[i - 1][j]
print(F[-1][-1])
Ans = []
k = S
for i in range(n,0,-1):
    if F[i][k] != F[i-1][k]:
        Ans.append(i)
        k -= W[i]
print(Ans)
