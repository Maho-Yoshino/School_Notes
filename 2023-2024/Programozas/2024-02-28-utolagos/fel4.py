'''Írj egy programot, amely a felhasználótól bekér 3 szót, ezeket egy listában tárolja, és egy eljárás segítségével meghatározza, és a képernyőre kiírja, melyik a legrövidebb szó!'''
def rovid(szavak:list):
	szo = None
	hossz = 2**64
	for i in szavak:
		if len(i)<hossz:
			hossz=len(i)
			szo=i
	return szo

cont=True
while cont:
	szoveg = input("Adjon meg 3 szót: ").split()
	if len(szoveg) == 3:
		cont=False
		legrovidebb = rovid(szoveg)
		print(f"A legrövidebb szó: {legrovidebb}")
	else:
		print("Ez nem 3 szó!")
