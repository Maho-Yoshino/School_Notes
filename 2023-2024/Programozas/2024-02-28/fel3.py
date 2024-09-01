'''3.1 Feladat
Írj egy programot, amely tartalmaz egy 'harommal_oszthatok' nevű függvényt, amely a paraméterként átvett listában megvizsgálja, hogy hány darab hárommal osztható szám van, és ezzel az értékkel tér vissza! A program tartalmazza a függvény hívását is!

3.2 Feladat
Alakítsd át az előző programot úgy, hogy a felhasználó által megadott számokat tárolja el a program egy listában, és ezt értékelje ki a függvény! (Az adatbeolvasás addig tartson, míg a felhasználó negatív számot nem ad meg!)'''
def harommal_oszthatok(L:list):
	oszthato = 0
	for i in L:
		if i % 3 == 0:
			oszthato+=1
	return oszthato

cont = True
lista = []
while cont:
	temp = int(input("Adjon meg egy számot:"))
	if temp < 0:
		cont=False
	else:
		lista.append(temp)
harommal_oszthato = harommal_oszthatok(lista)
print(harommal_oszthato)