'''Írj egy programot, amelyben van egy 'kerulet' nevű függvény, amely az egyetlen kötelező paramétere mellett fogadhat több paramétert is! Az opcionális paraméterek száma alapján döntse el milyen síkidomról van szó, és számolja ki a kerületét (0 tetszőleges paraméter: négyzet, 1 tetszőleges paraméter: téglalap, 2 tetszőleges paraméter: háromszőg, 3 vagy több tetszőleges paraméter: sokszög)!

A program tartalmazzon mindegyik síkidom típusra egy-egy függvényhívást!'''

def kerulet(a:float, *args:float):
	if len(args) == 0:#Négyzet
		return a*4
	elif len(args) == 1:#Téglalap
		return (a+args[0])*2
	elif len(args) == 2:#Háromszög
		return a+args[0]+args[1]
	elif len(args) == 3: #Sokszög
		kerulet_sok = 0
		for i in args:
			kerulet_sok+=i
		return kerulet_sok

a=5
b=3
c=9
d=16
ker_1 = kerulet(a) #Négyzet
ker_2 = kerulet(a, b) #Téglalap
ker_3 = kerulet(a, b, c) #Háromszög
ker_4 = kerulet(a, b, c, d) #Sokszög
print(f"Négyzet: {ker_1}\nTéglalap: {ker_2}\nHáromszög: {ker_3}\nSokszög: {ker_4}")