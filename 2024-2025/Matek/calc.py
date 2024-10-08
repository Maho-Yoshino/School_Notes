from math import sqrt,sin,cos,tan,log,pi
replace_dict = {
	"^":"**",
	"√":"sqrt",
	"π":"pi"
}
def root(x:int|float|str,n:int|float|str):
	if isinstance(x, str):
		x = float(x)
	if isinstance(n, str):
		n = float(n)
	return x**(1/n)
while True:
	try:
		equation = input("> ")
		for item, replacant in replace_dict.items():
			equation = equation.replace(item, replacant)
		print(str(eval(equation)) + "\n")
	except Exception as e:
		print(f"error: {e}\n")