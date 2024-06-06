def main():
	def negyzet(a:float, b:float=None):
		if b is None:
			b = a
		return a*b, a+b
	a = float(input("a="))
	b = float(input("b="))
	T, K = negyzet(a,b)
	print(f"{T = }\n{K = }")
if __name__ == "__main__":
	main()
