from tkinter.filedialog import askopenfilenames
from os import chdir, path, getcwd

chdir(path.dirname(path.abspath(__file__)))

def main():
	files = None
	while not files:
		try:
			input("Press Enter to select the file or folder.")
			files = askopenfilenames(initialdir = getcwd(), title = "Select a file", filetypes = (("Markdown files", "*.md"), ("all files", "*.*")))
		except Exception as e:
			return print(f"An error occurred: {e}")
	assert file, "No file(s) selected."
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
			if "  " in line[:first_char]:
				line = line.replace("  ", "\t", line.count(" ", 0, first_char))
			for i in range(len(line)):
				if line[i] not in (" ", "\t"):
					first_char = i
					break
			if " " in line[:first_char]:
				line = line.replace(" ", "\t", line.count(" ", 0, first_char))
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
	print(f"{", ".join(files)} selected.")
	for file in files:
		fix_content(file)

if __name__ == "__main__":
	while True:
		try:
			main()
		except KeyboardInterrupt:
			print("Exiting...")
			break