A = ['vk.com','www.yandex','www.github.com','pythonworld','pythontutor']
print (A) 

for i in range(len(A)):
    B = A[i]
    if B[:4] != ('www.') and (B[:8] != ('https://') or B[:7] != ('http://')):
        A[i] = 'www.' + A[i]
    if B[:8] != ('https://'):
            A[i] = 'https://' + A[i]
            if not A[i].endswith('.com'):
                A[i] = A[i] + '.com'
print(A)
