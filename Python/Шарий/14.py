def non_empty(funcToDec):
    def wrapper(): #Обертка
        print ('Было')
        print (funcToDec())
        temp = funcToDec() 
        
        for i, data in enumerate(temp):
            if data == ' ' or data == '':
                del temp[i]
        print ('Стало') 
        print (temp)
    return wrapper()

@non_empty 
def get_pages():
    return ['chapter1', ' ', 'contents', '', 'line1']