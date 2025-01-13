from math import sqrt,sin,cos,tan,log,pi, floor, ceil, degrees as d, log10 as lg
replace_dict = {
	"^":"**",
	"√":"sqrt",
	"π":"pi",
	"=":"==",
	"≥":">=",
	"≤":"<=",
	"e+":"*10^",
	";":","
}
def deg2rad(degrees:int|float): return pi/180*degrees
def root(x:int|float,n:int|float=2): return x**(1/n)
def sind(degrees:int|float): return sin(deg2rad(degrees))
def cosd(degrees:int|float): return cos(deg2rad(degrees))
def rep(string:str, **items:dict[str, int|float]):
	"""Replaces all items entered, like "x=2" in given string, so rep(x^2, x=2) returns "2^2"."""
	for item_name, item_data in items.items():
		item_data = f"({item_data})" 
		string = string.replace(str(item_name), item_data)
	return string
while True:
	try:
		equation = input("> ").lower()
		if "exit" in equation:
			break
		if "rep(" in equation:
			equation_split = equation.split(",")
			equation = eval(f"rep(\"{equation_split[0].removeprefix("rep(")}\",{','.join(equation_split[1:]).removesuffix(")" if equation.count("(")==equation.count(")") else "")})")
		for item, replacant in replace_dict.items():
			equation = equation.replace(item, replacant)
		if "raw(" in equation:
			print(str(equation) + "\n")
		elif "+-" in equation:
			print(str(round(eval(equation.replace("+-", "+")), 8)) + "(+), " + str(eval(equation.replace("+-", "-"))) + "(-)\n")
		else:
			print(str(round(eval(equation), 8)) + "\n")
	except KeyboardInterrupt:
		from os import _exit
		from time import sleep
		print("\nKeyboard interrupt. Closing...")
		sleep(1)
		_exit(0)
	except Exception as e:	
		print(f"error: {e}\n")