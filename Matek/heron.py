from math import sqrt
def main():
	a,b,c = map(float, input("a,b,c: ").split(","))
	print(a,b,c)
	print(heron(a,b,c))

def heron(a:int|float,b:int|float,c:int|float):
	s = (a+b+c)/2
	return round(sqrt(s*(s-a)*(s-b)*(s-c)), 2)
if __name__ == "__main__":
	while True:
		main()
		print()