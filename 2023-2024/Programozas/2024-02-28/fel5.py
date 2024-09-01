'''Írj egy programot, ami addig kér be egész pozitív számokat, amíg a felhasználó negtív számot nem ír! A megadott számokat tárolja a program egy listában, és ezt adja át paraméterként egy függvények, amely a lista legkisebb elemével tér vissza. A program írja ki, hogy melyik volt a megadott legkisebb szám!'''

def legkisebb(X:list, N:int): #https://progalap.elte.hu/downloads/seged/eTananyag/lecke30_lap1.html#hiv5
	for i in range(0,N-1):
		minI=i
		for j in range(i+1, N):
			if X[minI]>X[j]:
				minI=j
		tmp = X[i]
		X[i]=X[minI]
		X[minI]=tmp
	return X[0]

	

numlist = []
cont = True
while cont:
	temp = int(input("Adjon meg egy pozitív egész számot (negatív szám abbahagyja a felsorolást):"))
	if temp < 0:
		cont=False
	else:
		numlist.append(temp)
legkicsi = legkisebb(numlist, len(numlist))
print(f"A legkisebb elem:{legkicsi}")