'''Írj egy programot, amely tartalmaz egy 'paros_e' nevű függvényt, amely True értékkel tér vissza, ha a paraméterként átvett listaelemek (egész számok) között van páros, ellenkező esetben a visszatérési érték False! A program tartalmazza a függvény hívását is!'''
def paros_e(L:list):
	paros = False
	for i in L:
		if i % 2 == 0:
			paros = True
	return paros
lista = [1,5,7,7,2,5,7,3,5,6]
paros = paros_e(lista)
print(paros)