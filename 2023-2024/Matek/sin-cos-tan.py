import math,os

def calculate_sides():
	angle_deg = float(input("Enter the angle in degrees: "))
	side_length = float(input("Enter the length of the known side: "))
	side_position = input("Enter the position of the known side relative to the angle (opposite (a-val szemközti bef.), adjacent (a melletti bef.), hypotenuse (Átfogó)): ")
	print()
	if side_position[0].lower() == "o":
		opposite = side_length
		adjacent = round(opposite / math.tan(math.radians(angle_deg)), 2)
		hypotenuse = round(opposite / math.sin(math.radians(angle_deg)), 2)
		print("Adjacent side length =", adjacent)
		print("Hypotenuse length =", hypotenuse)
	elif side_position[0].lower() == "a":
		adjacent = side_length
		opposite = round(adjacent * math.tan(math.radians(angle_deg)), 2)
		hypotenuse = round(adjacent / math.cos(math.radians(angle_deg)), 2)
		print("Opposite side length =", opposite)
		print("Hypotenuse length =", hypotenuse)
	elif side_position[0].lower() == "h":
		hypotenuse = side_length
		opposite = round(hypotenuse * math.sin(math.radians(angle_deg)), 2)
		adjacent = round(hypotenuse * math.cos(math.radians(angle_deg)), 2)
		print("Opposite side length =", opposite)
		print("Adjacent side length =", adjacent)
	else:
		raise ValueError("Unknown side position")
	print()

while True:
	calculate_sides()
