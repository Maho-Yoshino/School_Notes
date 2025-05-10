from math import sqrt, sin, cos, tan, log, pi, floor, ceil, degrees as r2d, log10 as lg, asin, acos, atan, radians as d2r, factorial as fact
import pyperclip, re, traceback
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
def isin(radian:int|float): return round(r2d(asin(radian)), round_val)
def icos(radian:int|float): return round(r2d(acos(radian)), round_val)
def itan(radian:int|float): return round(r2d(atan(radian)), round_val)
def eq(eq_num:int|None=None):
	equations = [
		# [egyenlet, elnevezés, változók]
		# ["", "", ""]
		["(-b+-sqrt(b^2-4*a*c))/(2*a)", "Másodfokú függvény", "a, b, c"],
		["sqrt(a^2+b^2)", "Pitagorasz tétel", "a, b"],
		["a+b>c and a+c>b and b+c>a", "Háromszög validálás", "a, b, c"],
		["sqrt((x2-x1)^2+(y2-y1)^2)", "Távolság két pont között", "x1, y1, x2, y2"],
		["((x1+x2)/2), (y1+y2)/2", "Két pont felezőpontja", "x1, y1, x2, y2"],
		["sqrt(s*(s-a)*(s-b)*(s-c))", "Háromszög területe (Heron)", "a, b, c, s"],
		["(a+b+c)/2", "Heron s változó", "a, b, c"],
		["sqrt(((a+b+c)/2)*(((a+b+c)/2)-a)*(((a+b+c)/2)-b)*(((a+b+c)/2)-c))","Kompakt Heron képlet", "a, b, c"],
		["y-yo=m(x-xo) -r", "Lineáris egyenlet", "m, xo, yo"]
	]
	while eq_num is None or eq_num not in range(1, len(equations)+1):
		try:
			eq_num = int(input(f"\nEquations:\n\t{"\n\t".join([f"{num+1}. {i[1]} (Változók: {i[2]})\n\t\t{i[0]}" for num, i in enumerate(equations)])}\neq>").strip())
		except:
			continue
	return equations[eq_num-1][0]
def rep(string:str, **items:dict[str, int|float]):
	"""Replaces all items entered, like "x=2" in given string, so rep(x^2, x=2) returns "2^2"."""
	string = insert_multiplication(string)
	for item_name, item_data in sorted(items.items(), key=lambda x: -len(x[0])):
		pattern = rf'\b{re.escape(item_name)}\b'
		replacement = f"({item_data})" if isinstance(item_data, (int, float)) and item_data < 0 else str(item_data)
		string = re.sub(pattern, replacement, string)
	return string
def extract_rep_content(equation: str):
	pattern = r"rep\((.*)\)"
	match = re.search(pattern, equation)
	if match:
		return match.group(1)
def insert_multiplication(expression: str) -> str:
	expression = re.sub(r'(\d)([a-zA-Z\(])', r'\1*\2', expression)
	return re.sub(r'(\))(\d|[a-zA-Z\(])', r'\1*\2', expression)
def avg(*numbers:int|float) -> float: return sum(numbers) / len(numbers)
prev_eq:str|bool|int|float|None = None
round_val = 4
def set_round(num:int):
	global round_val
	round_val = num
while True:
	try:
		equation = input("> ").lower().strip()
		_copy = equation.__contains__("-c")
		raw = equation.__contains__("-r")
		if _copy:
			equation = equation.replace("-c", "")
			if not equation and prev_eq:
				pyperclip.copy(prev_eq)
				continue
			elif not equation and not prev_eq:
				print("No previous equation to copy.")
				continue
		if "rep(" in equation:
			equation_split = extract_rep_content(equation).split(",")
			if equation_split[0].count("(") != equation_split[0].count(")"):
				open_count = equation_split[0].count("(")
				close_count = equation_split[0].count(")")
				raise SyntaxError(f"Unbalanced parentheses. (add {"\"(\"" if open_count < close_count else "\")\""} (*{max(open_count, close_count)-min(open_count, close_count)}))")
			if equation_split[0].__contains__("eq("):
				equation_split[0] = eq(int(equation_split[0].split("(")[1].split(")")[0])) if not equation_split[0].__contains__("eq()") else eq()
			equation = eval(f"rep(\"{equation_split[0]}\",{','.join(equation_split[1:])})")
		try:
			for item, replacant in replace_dict.items():
				equation = equation.replace(item, replacant)
			if raw:
				equation = equation.replace("-r", "")
				print(finished_eq := str(equation))
			elif "+-" in equation:
				print(finished_eq := str(round(eval(equation.replace("+-", "+")), round_val)) + "(+), " + str(eval(equation.replace("+-", "-"))) + "(-)")
			else:
				equation = eval(equation)
				try:
					print(finished_eq := str(round(equation, round_val)))
				except:
					print(finished_eq := equation)
		except Exception as e:
			print(finished_eq := str(eval(equation)))
		pyperclip.copy(finished_eq) if _copy else None
		print()
		prev_eq = finished_eq
	except KeyboardInterrupt:
		from os import _exit
		print("\nKeyboard interrupt. Closing...")
		_exit(0)
	except ZeroDivisionError:
		print("Division by zero.\n")
	except Exception as e:	
		print(f"error: {e}\n")