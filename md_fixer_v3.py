import tkinter as tk
from os import chdir, path, listdir

chdir(path.dirname(path.abspath(__file__)))
window = tk.Tk()
window.title("File Explorer")
# Global Settings
window.geometry("300x400")
window.resizable = False

if __name__ == "__main__":
	window.mainloop()