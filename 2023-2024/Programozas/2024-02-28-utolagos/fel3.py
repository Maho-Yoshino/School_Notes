'''Írj eljárást, amely paraméterül kapott 2 számot összehasonlít, és a képernyőre kiírja, melyik a nagyobb szám! Kezeld azt az esetet is, ha a két szám egyenlő!'''
def hasonlit(a:int, b:int):
	if a==b:
		return "A két szám egyenlő"
	elif a>b:
		return f"A nagyobb szám {a}"
	elif a<b:
		return f"A nagyobb szám {b}"
num1 = int(input("Adjon meg egy számot: "))
num2 = int(input("Adjon meg egy számot: "))
hasonlat = hasonlit(num1, num2)
print(hasonlat)