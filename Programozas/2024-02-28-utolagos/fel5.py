'''5.1 Feladat
A "Próbáld ki!" gombra kattintva elérhető egy program, ami egy eljárás segítségével kirajzol a képernyőre egy 6x3-as mezőt. Alakítsd át ezt a programot úgy, az eljárás hívásakor megadott értékpárnak megfelelően a program az adott pozícióba 'O' helyett '+' jelet írjon ki. A lenti példában az eljárás hivása: mezot_rajzol(0,4)
    O O O O + O    
    O O O O O O
    O O O O O O
   
5.2 Feladat
Alakítsd át az előző programot úgy, hogy a felhasználó adhassa meg a koordinátákat, ahová a program 'O' helyett '+' jelet ír. A koordináták bekérése és a mező kirajzolása addig ismétlődjön, amíg a felhasználó negatív számot nem ad meg koordinátaként!'''

def mezot_rajzol(oszlop_hely:int, sor_hely:int):
	for sor in range(3):
		for oszlop in range(6):
			if oszlop == oszlop_hely-1 and sor == sor_hely-1:
				print('+ ', end='')
			else:
				print('O ', end='')
		print()
cont=True
while cont:
	sor = int(input("Adja meg a sor pozícióját [1,3] intervalumon: "))
	oszlop = int(input("Adja meg az oszlop pozícióját [1,6] intervalumon: "))
	if sor < 0 or oszlop < 0:
		cont=False
	else:
		mezot_rajzol(oszlop, sor)