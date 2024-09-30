from math import sqrt,sin,cos,tan,log,pi
while True:
	try:
		print(str(eval(input("> ").replace("^", "**"))) + "\n")
	except Exception as e:
		print(f"error: {e}\n")