'''1. Feladat
Készíts egy programot, amely [1;10] intervallumon generál 5 darab véletlen egész számot, és ezeket tárolja el egy listában! A program adja össze a lista elemeit, írja ki a képernyőre az összegüket és a lista elemeit!

2. Feladat
Módosítsd úgy a fenti programot, hogy a program csak a páros számokat adja össze!'''
import random
def fel(mode:int):
	iters = 0
	numlist = []
	osszeg = 0
	while iters < 5:
		iters += 1
		temp = random.randint(1,10)
		numlist.append(temp)
		if mode == 2:
			if temp % 2 == 0:
				osszeg+=temp
		else:
			osszeg+=temp
	print(f"Az elemek összege: {osszeg}\nA lista: {numlist}")
mode = int(input("1 vagy 2? "))
if mode in [1,2]:
	fel(mode)