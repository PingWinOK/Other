def pre_process(a):
    def d_process(foo):
        print ('Стартовый препроцесс')
        print (s)
        i=0
        for i in range(len(s)):
            s[i] = s[i] - a*s[i-1] 
        print ('препроцесс')    
        print (s)
    return d_process

s = [3.2,2.0,0.339] #Массив который задали

@pre_process(a=0.93) #parametr
def plot_signal(s):
    return 0