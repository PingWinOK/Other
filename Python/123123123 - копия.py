a = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
b = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
A = set(a)
B = set(b)
print(A&B)
print(A|B)
print(A.update(B))
print(A.intersection_update(B))
print(A.difference(B))
print(A.difference_update(B))
print(A^B)
print(A.symmetric_difference_update(B))
print(A<=B)
print(A>=B)
print(A>B)
print(A<B)

