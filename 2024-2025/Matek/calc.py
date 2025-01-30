from math import sqrt, sin, cos, tan, log, pi, floor, ceil, degrees as r2d, log10 as lg, asin, acos, atan, radians as d2r
import pyperclip, re
replace_dict = {
	"^":"**",
	"√":"sqrt",
	"π":"pi",
	"=":"==",
	"≥":">=",
	"≤":"<=",
	"e+":"*10^",
	";":",",
	"〗":"",
	"〖":""
}
def root(x:int|float,n:int|float=2): return x**(1/n)
def sind(degrees:int|float): return sin(d2r(degrees))
def cosd(degrees:int|float): return cos(d2r(degrees))
def tand(degrees:int|float): return tan(d2r(degrees))
#def sin1(radian:int|float): return r2d(asin(radian))
#def cos1(radian:int|float): return r2d(acos(radian))
#def tan1(radian:int|float): return r2d(atan(radian))
def rep(string:str, **items:dict[str, int|float]):
	"""Replaces all items entered, like "x=2" in given string, so rep(x^2, x=2) returns "2^2"."""
	for item_name, item_data in items.items():
		if item_data < 0:
			item_data = f"({item_data})"
		string = string.replace(str(item_name), str(item_data))
	return string
def extract_rep_content(equation: str):
    pattern = r"rep\((.*)\)"
    match = re.search(pattern, equation)
    if match:
        return match.group(1)
    return None
while True:
	try:
		equation = input("> ").lower()
		copy = False
		raw = False
		if "exit" in equation:
			break
		if "-copy" in equation:
			equation = equation.replace("-copy", "")
			copy = True
		if "-raw" in equation:
			equation = equation.replace("-raw", "")
			raw = True
		if "rep(" in equation:
			equation_split = extract_rep_content(equation).split(",")
			if equation_split[0].count("(") != equation_split[0].count(")"):
				open_count = equation_split[0].count("(")
				close_count = equation_split[0].count(")")
				raise SyntaxError(f"Unbalanced parentheses. (add {"\"(\"" if open_count < close_count else "\")\""} (*{max(open_count, close_count)-min(open_count, close_count)}))")
			equation = eval(f"rep(\"{equation_split[0]}\",{','.join(equation_split[1:])})")
		for item, replacant in replace_dict.items():
			equation = equation.replace(item, replacant)
		if raw:
			print(finished_eq := str(equation) + "\n")
		elif "+-" in equation:
			print(finished_eq := str(round(eval(equation.replace("+-", "+")), 8)) + "(+), " + str(eval(equation.replace("+-", "-"))) + "(-)\n")
		else:
			print(finished_eq := str(round(eval(equation), 8)) + "\n")
		pyperclip.copy(finished_eq) if copy else None
	except KeyboardInterrupt:
		from os import _exit
		print("\nKeyboard interrupt. Closing...")
		_exit(0)
	except ZeroDivisionError:
		print("Division by zero.\n")
	except SyntaxError as e:
		print(f"error: {e}\n")
	except Exception as e:	
		print(f"error: {e}\n")