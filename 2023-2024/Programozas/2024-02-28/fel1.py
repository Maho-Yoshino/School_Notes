'''Írj egy programot, amely tartalmaz egy 'osszegzo' nevű függvényt, ami a paraméterként átvett listaelemeket (egész számokat) összeadja és az összegükkel tér vissza! A program tartalmazza a függvény hívását is!'''
def osszegzo(L:list):
	osszeg = 0
	for i in L:
		osszeg+=i
	return osszeg
lista = [1,4,5,6,2,7,1,9]
osszeg = osszegzo(lista)
print(osszeg)