while True:
	try:
		print(eval(input("> ").replace("^", "**"))+"\n")
	except Exception as e:
		print(f"error: {e}\n")