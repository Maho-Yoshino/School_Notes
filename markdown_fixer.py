import os
os.chdir(os.path.dirname(os.path.abspath(__file__)))
def open_file(file_dir:str):
	with open(file_dir, encoding="utf-8") as file:
		add_newline(file.readlines(), file_dir)
def add_newline(text:list, file_dir:str):
	new_content = ""
	for i in text:
		print(i)
		if i[-1:-2]!="  ":
			new_content += i.strip()+"  \n"
	with open(file_dir, "w", encoding="utf-8") as file:
		file.write(new_content)
def _init_():
	folders = []
	files = []
	def thing():
		for i in os.listdir(os.getcwd()):
			if i.split(".")[-1] == i:
				folders.append(i)
			elif i.split(".")[-1]=="md":
				files.append(i.split(".")[0])
			else:
				continue 
		print(f"Current directory:{os.getcwd()}")
		if len(folders)!=0:
			print(f"\n\nFolders:\n{'\n'.join(folders)}")
		if len(files)!=0:
			print(f"\n\nFiles:{'\n'.join(files)}")
		file_dir = input("Enter filename/folder name: ")
		if file_dir in folders:
			os.chdir(os.getcwd()+file_dir)
			thing()
		elif file_dir in files:
			return os.getcwd()+f"\\{file_dir}.md"
	open_file(thing())
_init_()