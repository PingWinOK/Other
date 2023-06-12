
# from datetime import datetime
import time
def benchmark(func):
    def wrapper(*args,**kwargs):
        start = time.time()
        result = func(*args,**kwargs)
        print('[*] Время выполнения: {} секунд.'.format(time.time()-start))
        return result
    return wrapper

@benchmark
# Код найденный на просторах интернета - расширенный алгоритм Евклида через
# рекурсию
#
# def gcd_extended(num1, num2):
#     if num1 == 0:
#         return (num2, 0, 1)
#     else:
#         div, x, y = gcd_extended(num2 % num1, num1)
#         print(div, y - (num2 // num1) * x, x)
#         return div, y - (num2 // num1) * x, x
# gcd_extended(225,10)
#
def fetch_webpage(a,b):

    if b == 0:
        return a, 1, 0 # d=a, x=1, y=0
    else:
        d, x, y = fetch_webpage(b, a % b)
        print(d, y, x - y * (a // b))
        # return d, y, x - y * (a // b)
fetch_webpage(225,15)




def is_odd (number):
   return (number & 1) == 1

@benchmark
def gcd (a,b):
    if a == 0:
        return b                            
    elif b == 0:
        return a                            
    elif a == b:
        return a                            
    elif a == 1 or b == 1:
        return 1                            
    elif is_odd(a):                         
        if is_odd(b):                       
            return gcd(b, abs(a - b))       
        else:                               
            return gcd(a, b >> 1)           
    else:                                   
        if is_odd(b):                       
            return gcd(a >> 1, b)          
        else:                               
            return gcd(a >> 1, b >> 1) << 1
    #print(gcd (a, b))

gcd(340,15)

#######################################################################

def x():
    y,Last = 1,0
    x,Last = 0,1

@benchmark

def egcd(a,b):
    def x():
    
    #y,Last = 1,0
    #x,Last = 0,1
    
    
        while(b!=0):
            q=a//b
            a,b=b,a%b
            x,Lastx=Lastx-x*q,x
            y,Lasty=Lasty*y,y
        return Lastx, Lasty

        x,y=egcd(a,b)
        print(x*a+y,b)

egcd(225,15)












        
