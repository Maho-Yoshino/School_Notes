import os, difflib
os.chdir(os.path.dirname(os.path.abspath(__file__)))
def open_file(file_dir:str):
	with open(file_dir, encoding="utf-8") as file:
		print("File found")
		add_newline(file.readlines(), file_dir)
def add_newline(text:list, file_dir:str):
	new_content = ""
	for i in text:
		i=str(i).removesuffix("\n")
		while i[-2:]!="  ":
			i += " "
		new_content += i+"\n"
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
		print(f"\nFolders:\n\t{'\n\t'.join(folders)}" if folders else "\nNo folders")
		print(f"\nFiles:\n\t{'\n\t'.join(files)}" if files else "\nNo files")

		file_dir = input("Enter filename/folder name: ").strip()
		close_folders = difflib.get_close_matches(file_dir, folders)
		close_files = difflib.get_close_matches(file_dir, files)
		if file_dir == ".":
			os.chdir("..")
			print(f"Moved up to: {os.getcwd()}")
		elif "*" in file_dir:
			for file in files:
				file += ".md"
				with open(file, "r", encoding="utf-8") as F:
					add_newline(F.readlines(), file)
		elif file_dir.lower() == "exit":
			os._exit(0)
		elif close_folders:
			chosen_folder = close_folders[0]
			print(f"Changing directory to: {chosen_folder}")
			os.chdir(os.path.join(os.getcwd(), chosen_folder))
			return thing()
		elif close_files:
			chosen_file = close_files[0] + ".md"
			file_path = os.path.join(os.getcwd(), chosen_file)
			return file_path
		else:
			print("No matches found. Try again.")
			thing()
	file_path = thing()
	if file_path:
		open_file(file_path)
if __name__ == "__main__":
	while True:
		_init_()