def extra_enumerate(Mass, start):
    A = start 
    cum = 0 
    for elem in Mass:   
        yield A, elem
        A += 1
        cum = cum + elem
        print("(",elem,',',cum,',',cum*0.1,")")
        
x  = [1,3,4,2] 
for i in extra_enumerate(x,0):
    print() 