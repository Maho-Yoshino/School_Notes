from os import chdir, path, getcwd
from sys import argv, exit

chdir(path.dirname(path.abspath(__file__)))

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

if __name__ == "__main__":
	if len(argv) < 2:
		print("Usage: python md_fixer_vscode.py <file.md>")
		exit(1)
	file_path = argv[1]
	if not path.exists(file_path):
		print("❌ File does not exist.")
		exit(1)
	if not file_path.endswith(".md"):
		print("❌ Not a Markdown file.")
		exit(1)
	fix_content(file_path)
