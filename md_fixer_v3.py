from tkinter import filedialog
from os import chdir, path, getcwd, listdir

chdir(path.dirname(path.abspath(__file__)))

def main():
	def get_type():
		print("1. File\n2. Folder")
		while True:
			type_ = input("Select type: ")
			if type_ in ("1", "2"):
				return type_
			print("Wrong answer.")
	folder = None
	file = None
	type_ = get_type()
	try:
		input("Press Enter to select the file or folder.")
		if type_ == "1":
			file = filedialog.askopenfilename(initialdir = getcwd(), title = "Select a file", filetypes = (("Markdown files", "*.md"), ("all files", "*.*")))
		if type_ == "2":
			folder = filedialog.askdirectory(initialdir = getcwd(), title = "Select a folder")
	except Exception as e:
		return print(f"An error occurred: {e}")
	assert file or folder, "No file or folder selected."
	def fix_content(file_dir:str):
		with open(file_dir, encoding="utf-8") as file:
			text = file.readlines()

		def replace_space_tab(line:str) -> str:
			if "   " in line:
				line = line.replace("   ", "\t")
			first_char = -1
			for i in range(len(line)):
				if line[i] not in (" ", "\t"):
					first_char = i
					break
			count_spaces = line.count("  ", 0, first_char)
			if "  " in line[:first_char]:
				line = line.replace("  ", "\t", count_spaces)
			count_spaces = line.count(" ", 0, first_char)
			if " " in line[:first_char]:
				line = line.replace(" ", "\t", count_spaces)
			return line.removesuffix("\n").removesuffix("\r\n").removesuffix("\t")
		
		new_content = ""
		for line in text:
			if line in ("\n", "\r\n"):
				new_content += line
				continue
			line = replace_space_tab(line)
			while line[-2:] != "  ":
				line += " "
			new_content += line + "\n" 

		with open(file_dir, "w", encoding="utf-8") as file:
			file.write(new_content)
			print("Finished.")
	if file:
		print(f"{file} selected.")
		fix_content(file)
	elif folder:
		print(f"{folder} selected.")
		files = []
		for i in listdir(folder):
			if i.split(".")[-1] == "md":
				files.append(i)
		for file in files:
			fix_content(f"{folder}\\{file}")

if __name__ == "__main__":
	while True:
		try:
			main()
		except KeyboardInterrupt:
			print("Exiting...")
			break