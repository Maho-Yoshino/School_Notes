import os
os.chdir(os.path.dirname(os.path.abspath(__file__)))
def fel1():
	print("1. feladat: Kisebb-nagyobb meghatározása")
	num1 = int(input("Kérem az első számot: "))
	num2 = int(input("Kérem a második számot: "))
	if num1 == num2:
		print("A két szám egyenlő.")
	else:
		print(f"A nagyobb szám {max(num1, num2)}, a kisebb {min(num1, num2)}.")


def szokoev(ev:int):
	return (ev%400==0 or (ev%4==0 and ev%100!=0))

def fel2():
	print("2. feladat: Szökőév listázó")
	int_1 = int(input("Kérem az egyik évszámot: "))
	int_2 = int(input("Kérem a másik évszámot: "))
	if int_1 > int_2:
		int_1,int_2=int_2,int_1
	szokoevek = []
	for i in range(int_1, int_2+1):
		if szokoev(i):
			szokoevek.append(i)
	if len(szokoevek)==0:
		print("Nincs szökőév a megadott tartományban")
	else:
		print(f"Szökőévek: {'; '.join([str(i) for i in szokoevek])}")

class epulet:
	nev = ''
	varos = ''
	orszag = ''
	magassag = 0.0
	emelet = 0
	epult = 0
	def __init__(self, sor:str):
		data = sor.split(";")
		self.nev = data[0]
		self.varos = data[1]
		self.orszag = data[2]
		self.magassag = float(data[3].replace(",", "."))
		self.emelet = int(data[4])
		self.epult = int(data[5])
def fel3():
	epuletek = []
	with open("legmagasabb.txt", encoding="utf-8") as file:
		file.readline()
		sor = file.readline()
		while sor:
			epuletek.append(epulet(sor))
			sor = file.readline()
		print(f"3.2 feladat: Épületek száma: {len(epuletek)} db")
		emeletek = 0
		index = 0
		van_olasz = False
		for e in epuletek:
			emeletek+=e.emelet
			if e.magassag > epuletek[index].magassag:
				index = epuletek.index(e)
			if e.orszag == "Olaszország" and not van_olasz:
				van_olasz = True
		print(f"3.3 feladat: Emeletek összege: {emeletek}")
		print(f"3.4 feladat: A legmagasabb épület adatai:\n\tNév: {epuletek[index].nev}\n\tVáros: {epuletek[index].varos}\n\tOrszág: {epuletek[index].orszag}\n\tMagasság: {epuletek[index].magassag} m\n\tEmeletek száma: {epuletek[index].emelet}\n\tÉpítés éve: {epuletek[index].epult}")
		if van_olasz:
			print("3.5 feladat: Van olasz épület az adatok között")
		else:
			print("3.5 feladat: Nincs olasz épület az adatok között")