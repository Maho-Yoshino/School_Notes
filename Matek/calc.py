while True:
	calc = input("> ")
	if calc.lower()[0]not in [str(i) for i in range(0,10)].append(["("]):break
	calc = eval(calc)
	if str(calc).split(".")[-1]=="0":calc = calc.__int__()
	print(f"End result: {calc}")