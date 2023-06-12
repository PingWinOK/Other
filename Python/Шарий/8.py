import random

number = int(random.uniform(0, 10000))
print(number, " - Рандомное число")
RandMass = [random.randrange(0, 100) for i in range(number)]
print (RandMass)
print(len(RandMass))
p = 2 
i = 0
while p**i <= number:
    stepen = p**i
    print('2^',i, '= ',stepen)
    i = i + 1
print('2^',i, '= ',p**i)
app =  p**i - number
for i in range(app):
    RandMass.append(0)
print(RandMass)
print(len(RandMass))
