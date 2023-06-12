print("Введите последовательность: ")
a = input()

A = list(map(int,a.split(" ")))
i = 0
G = []
for i in range(len(A)-1):
    if A[i] >= A[i+1]:
        G.append("False")
    else:
        G.append("True")
if G.count("False") > 0:
    print("Это не последовательность")
else:
    print("Это последовательность")

