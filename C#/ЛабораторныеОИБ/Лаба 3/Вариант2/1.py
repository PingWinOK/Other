def caesar(plainText):
    sdvig = 0
    shifr = []
    text = []
    mass = ''
    for a in plainText:
        if((a == ' ') or (a == ",")):
            continue
        text.append(a)  
    print(text)
    symbols = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я".split(" ")
    for i in range(32):
        for r in text:
            mass += (symbols[(symbols.index(r) + sdvig)%32])
        sdvig += 1
        print("Сдвиг:", sdvig , "Текст:", mass)
        mass = ""
    return mass
print(caesar("шж щлужнлрш июъ тфущзй, л июъ ыьъэюъ эыфэъц прч"))

def CHASTOTNI(TEXT):
    for g in "0123456789-.?,:;\"<>«» ":
        Clov = {}
        TEXT = TEXT.replace(g, "").lower()
        for i in TEXT:
            Clov.setdefault(i, 0)
            print(Clov)
            Clov[i] += round(1/len(TEXT), 2)
    return Clov
print(CHASTOTNI("set defaukt dic"))
