from os import chdir, path, listdir, getcwd, _exit
from difflib import get_close_matches
chdir(path.dirname(path.abspath(__file__)))

"""def get_closest_match(word: str, possibilities: list[str]) -> str:
    if closest_matches := get_close_matches(word, possibilities, n=1, cutoff=0.0): return closest_matches[0]
    for i in range(len(word), 1, -1):
        for possibility in possibilities:
            if possibility.startswith(word[:i]):
                return possibility
    return None"""

def fix_content(file_dir:str) -> str:
	with open(file_dir, encoding="utf-8") as file:
		text = file.readlines()
	
	new_content = ""
	for line in text:
		line = line.replace("   ", "\t").removesuffix("\n")
		while line[-2:] != "  ":
			line += " "
		new_content += line + "\n"
	
	with open(file_dir, "w", encoding="utf-8") as file:
		file.write(new_content)
		print("Finished.")

def CLI():
	def get_dir():
		folders = []
		files = []
		for i in listdir(getcwd()):
			if i.split(".")[-1] == i:
				folders.append(i)
			elif i.split(".")[-1] == "md":
				files.append(i.split(".")[0])
			else:
				continue
		return folders, files
	while True:
		folders, files = get_dir()
		print(f"\nCurrent directory:{getcwd()}")
		print(f"Folders:\n\t{'\n\t'.join(folders)}" if folders else "\nNo folders")
		print(f"Files:\n\t{'\n\t'.join(files)}" if files else "\nNo files")
		file_dir = input("> ").strip().lower()
		close_folders = get_close_matches(file_dir, folders, 1, 0.5)
		close_files = get_close_matches(file_dir, files, 1, 0.5)
		if file_dir == ".":
			chdir("..")
			print(f"Moved up to: {getcwd()}")
		elif "*" in file_dir:
			for file in files:
				file += ".md"
				fix_content(file)
		elif file_dir == "exit":
			_exit(0)
			break
		elif close_folders:
			chosen_folder = close_folders[0]
			print(f"Changing directory to: {chosen_folder}")
			chdir(path.join(getcwd(), chosen_folder))
		elif close_files:
			chosen_file = close_files[0] + ".md"
			fix_content(chosen_file)
		else:
			print("Invalid filename.")
			continue

if __name__ == "__main__":
	CLI()