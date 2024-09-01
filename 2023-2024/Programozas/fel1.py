'''1. Feladat
Írj egy programot, amely 5 darab véletlenszámot generál [1;7] intervallumon, és ezeket eltárolja egy listában. Kérjen be a felhasználótól egy számot, és vizsgálja meg, hogy ez előfordul-e a listában! Az eredményről tájékoztassa a felhasználót, és írja ki a lista elemeit a képernyőre!'''
import random
iters = 0
numlist = []
while iters < 5:
	iters+=1
	temp = random.randint(1,7)
	numlist.append(str(temp))
num = input("Adjon meg egy számot [1;7] intervalumon: ")
if num in numlist:
	print("Benne van a listában")
else:
	print("Egyszer sincs benne a listában a szám")
print(f"A lista elemei: {','.join(numlist)}")