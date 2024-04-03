#Írj programot, amely generál egy véletlen háromjegyű számot, majd képezd ennek a számnak a számjegyei segítségével a legnagyobb háromjegyűt!
import random

numlist = []
szam = random.randint(100, 999)
for i in str(szam):
    numlist.append(int(i))
nagy = max(numlist)
numlist.remove(nagy)
kicsi = min(numlist)
numlist.remove(kicsi)
kozep = numlist[0]
nagyszam = kicsi+kozep*10+nagy*100
print(f"Random szám legenerálva: {szam}\nA legnagyobb szám, melyet ezen számból tudtunk csinálni: {nagyszam}")