import math
while True:
	num_input = input("Give numbers: ")
	if num_input == "":
		break
	numlist = []
	for item in num_input.split(","):
		if '*' in item:
			times, num = item.split('*')
			numlist.extend([int(num)] * int(times))
		else:
			numlist.append(int(item))
	abs_ertek = int(input("Abszolútértékes eltérés \"a\" értéke: "))
	if abs_ertek == "":
		abs_ertek = max(numlist)
	# Gyakoriság + Átlag
	avg_num = 0
	nums_dict = {}
	for i in numlist:
		avg_num += i
		if i in nums_dict:
			nums_dict[i] += 1
		else:
			nums_dict[i] = 1
	myKeys = list(nums_dict.keys())
	myKeys.sort()
	sorted_dict = {i: nums_dict[i] for i in myKeys}

	average = round((avg_num/len(numlist)), 3)
	# Medián
	if len(numlist) % 2 == 0:
		median = (int(sorted(numlist)[len(numlist) // 2]) + int(sorted(numlist)[len(numlist) // 2 - 1])) / 2
	else:
		median = int(sorted(numlist)[len(numlist) // 2])
	max_count = max(nums_dict.values())
	modus = [key for key, value in nums_dict.items() if value == max_count]
	# Abszolútértékes eltérés + Szórás
	abs_egyenlet = 0
	szoras = 0
	for i in numlist:
		abs_egyenlet += abs(i-abs_ertek)
		szoras += (i-average)**2
	abs_egyenlet = abs_egyenlet/len(numlist)
	szoras = math.sqrt(szoras/len(numlist))
	# Kvadrilisek
	# Végeredmény
	print(f"Átlag:{average}\nTerjedelem:{max(numlist)-min(numlist)}\nMódusz:{modus}\nMedián:{median} \nGyakoriság: {sorted_dict}\nAbszolútértékes eltérés (a={abs_ertek}):{abs_egyenlet}\nSzórás:{szoras}\nFelső Kvadrilis: {max(numlist)}\nAlsó Kvadrilis: {min(numlist)}\n\n")