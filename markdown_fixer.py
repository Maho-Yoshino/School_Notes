import os
os.chdir(os.path.dirname(os.path.abspath(__file__)))
def open_file(file_dir:str):
	with open(file_dir, encoding="utf-8") as file:
		print("File found")
		add_newline(file.readlines(), file_dir)
def add_newline(text:list, file_dir:str):
	new_content = ""
	for i in text:
		i=str(i)
		if i[-1:-2]!="  ":
			new_content += i.removesuffix("\n")+"  \n"
		else:
			print(i[-1:-2])
			new_content += i
	with open(file_dir, "w", encoding="utf-8") as file:
		file.write(new_content)
		print("Done.\n")
def _init_():
	
	def get_dir():
		folders = []
		files = []
		for i in os.listdir(os.getcwd()):
			if i.split(".")[-1] == i:
				folders.append(i)
			elif i.split(".")[-1]=="md":
				files.append(i.split(".")[0])
			else:
				continue 
		return folders,files
	def thing():
		folders, files = get_dir()		
		print(f"Current directory:{os.getcwd()}")
		if len(folders)!=0:
			print(f"\nFolders:\n\t{'\n\t'.join(folders)}")
		else:
			print("\nNo folders")
		if len(files)!=0:
			print(f"\nFiles:\n\t{'\n\t'.join(files)}")
		else:
			print("\nNo files")
		file_dir = input("Enter filename/folder name: ")
		if file_dir == ".":
			os.chdir("\\".join(os.getcwd().split("\\")[0:-1]))
			print("\\".join(os.getcwd().split("\\")[0:-1]))
		elif file_dir.lower() == "exit":
			os._exit(0)
		elif file_dir in folders:
			os.chdir(os.getcwd()+f"\\{file_dir}")
			return thing()
		elif file_dir in files:
			result = os.path.join(os.getcwd(), file_dir + ".md")
			return result
		else:
			thing()
	file_path = thing()
	if file_path:
		open_file(file_path)
while True:
	_init_()