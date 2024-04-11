import math, random
from typing import Union
def teglalap_ker_ter(a:Union[float, int], b:Union[float, int]):
	return (a+b)*2, a*b
def kor_ker_ter(r:Union[float, int]):
	return 2*r*math.pi(), r**2*math.pi()
def random_num(iters:int=1):
	numbers = []
	for i in range(iters):
		numbers.append(random.randint(1, 101))
	return numbers
def pitagoras(a:int, b:int):
	return math.sqrt(a**2+b**2)
def negyzet_ker_ter(a:Union[int, float]):
	return a*4, a**2
def szoveg_a(szoveg:str):
	a_num = 0
	for i in szoveg:
		if i.lower() == "a":
			a_num += 1
	return a_num
def szoveg_mgh_msh(szoveg:str):
	mgh = ["a","á","e","é","i","í","o","ó","ö","ő","u","ú","ü","ű"]
	mgh_num = 0
	msh_num = 0
	for i in szoveg:
		if i.lower() in mgh:
			mgh_num += 1
		else:
			msh_num += 1
	return mgh_num, msh_num
