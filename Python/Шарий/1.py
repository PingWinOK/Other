print('Введите деньги: ')
try:
    A = float(input())
    if A <=0:
        raise ValueError
except (ValueError, TypeError):
    print('Введено число с минусом')
    raise SystemExit
a = float(A) // 1
b = float(A) % 1
print("Рублей: " ,int(a))
print("Копеек: " ,int(b * 100))

