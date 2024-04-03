'''Írj eljárást, amely paraméterül kapott számról eldönti, és a képernyőre kiírja, hogy negatív, pozitív vagy nulla-e!'''
def neg_poz_null(x:int):
	if x == 0:
		return "Nulla"
	elif x > 0:
		return "Pozitív"
	else:
		return "Negatív"
num = int(input("Adjon meg egy számot: "))
kerdojel = neg_poz_null(num)
print(kerdojel)