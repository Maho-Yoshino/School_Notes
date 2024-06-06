from heron import heron
def main():
	def teruletelv(a:float, b:float, c:float):
		T = heron(a,b,c)
		R=(a*b*c)/(4*T)
		return R 
	a = float(input("a="))
	b = float(input("b="))
	c = float(input("c="))
	print(teruletelv(a,b,c))

if __name__ == "__main__":
	main()