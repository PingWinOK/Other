  
def get_frames(signal,size,overlap):
        print ('Step: ')
        step = size * overlap
        print (step)
        i = 0
        while i<len(signal):
            print (signal[i:i+size])
            i = i + int(step)


signal = [i for i in range(0,1024)]
get_frames(signal,size=1024,overlap=0.5)