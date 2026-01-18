import re
from os import chdir, path
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
	def escape_numbers(line:str) -> str:
		m = re.match(r'^(\s{0,3}[0-9]{1,4}\.\s+)', line)
		if m:
			prefix = m.group(1)
			rest = line[len(prefix):]
		else:
			prefix = ""
			rest = line
		rest = re.sub(r'(^|[^0-9])([0-9]{4})\.(?:([^0-9])|$)', lambda m: m.group(1) + m.group(2) + r'\.' + (m.group(3) or ""), rest)
		return prefix + rest
	new_content = ""
	for line in text:
		if line in ("\n", "\r\n"):
			new_content += line
			continue
		line = replace_space_tab(line)
		line = escape_numbers(line)
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
	exit(0)
