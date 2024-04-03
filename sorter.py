import os
os.chdir(os.path.dirname(os.path.abspath(__file__)))
directory = os.listdir(os.getcwd())
folders = []
for i in directory:
	if i.split(".")[-1]==i:
		folders.append(i)
	else:
		continue
print("Directory:\n\t"+"\n\t".join(folders))

def sorting(subject:str=None, *, file_copy:str=None, file_paste:str=None):
	valid = False
	while not valid:
		if None in [file_copy, file_paste]:
			file_copy = input("Name of file to copy: ")
			file_paste = input("New file name: ")
		if file_copy.lower() == "default" and subject != None:
			file_copy = f"{subject.lower()}.md"
		if file_copy != file_paste:
			valid = True
		else:
			print("You cannot copy the file to itself!")
			file_copy = input("Name of file to copy: ")
			file_paste = input("New file name: ")
	with open(file_copy, "r", encoding="utf-8") as file:
		content = file.read().split("\n# ")[0]
	with open(file_paste):
		print("File created")
	


while True:
	try:
		subject = input("Subject: ")
		if subject.capitalize() in folders or subject == "IKT":
			os.chdir(subject)
			break
		else:
			raise Exception
	except Exception as e:
		continue
directory_content = '\n\t'.join(os.listdir(os.getcwd()))
print(f"Directory:\n\t{directory_content}")
sorting(subject)
	