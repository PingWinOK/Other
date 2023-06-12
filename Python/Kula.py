print("Введите число: ")
A = int(input())
i = 0
while i <= A:
    if i % 2 == 0:
        print(i)
    i = i + 1
print("------------------------------")
for i in range(0 , A+1 , 2):
        print(i)
print("------------------------------")
A = [i for i in range(A+1) if i % 2 == 0]
print(A)
