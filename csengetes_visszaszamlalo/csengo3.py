import tkinter as tk, asyncio, pystray, logging
from tkinter import Tk
from tkinter.ttk import Separator
from sys import platform, executable, argv
from tkinter.font import Font
from ctypes import windll, c_byte, byref, Structure
from datetime import datetime, time, timedelta
from time import perf_counter
from os import path, chdir, mkdir, environ
from threading import Thread
from PIL import Image
from json import load as jload, dump as jdump
from typing import Optional, Dict, List, Any
from pathlib import Path
logger = logging.getLogger(__name__)

# Setting PATH
if path.splitext(argv[0])[1].lower() != ".exe":
	print("not an .exe")
	current_dir = path.dirname(path.abspath(__file__))
else:
	current_dir = path.dirname(path.abspath(executable))
chdir(current_dir)

# Settings window
def setup_tray(root):
	def create_image():
		return Image.open("icon.ico")
	def on_quit(icon, item, root):
		icon.stop()
		root.destroy()
	icon = pystray.Icon("Csengetés időzítő", create_image(), menu=pystray.Menu(
		pystray.MenuItem("Show Overlay", lambda: root.deiconify()),
		pystray.MenuItem("Settings", lambda: open_settings(root)),
		pystray.MenuItem("Quit", lambda icon, item: on_quit(icon, item, root))
	))
	Thread(target=icon.run, daemon=True).start()
class Settings:
	def __init__(self, filename: str = "settings.json"):
		self.filename = filename
		self._data: Dict[str, Any] = {}
		self.load_settings()
	def load_settings(self):
		try:
			with open(self.filename, "r", encoding="utf-8") as f:
				self._data = jload(f)
		except FileNotFoundError:
			self._data = {}
		# Set default values if missing
		self._data.setdefault("classlist", {})
		self._data.setdefault("default_schedule", [])
		self._data.setdefault("special_days", None)
		self._data.setdefault("debug", False)
	def save(self):
		with open(self.filename, "w", encoding="utf-8") as f:
			jdump(self._data, f, indent=4, ensure_ascii=False)
	@property
	def classlist(self) -> Dict[str, List[str]]:
		return self._data["classlist"]
	@classlist.setter
	def classlist(self, value: Dict[str, List[str]]):
		self._data["classlist"] = value
		self.save()
	@property
	def default_schedule(self) -> List[List[str]]:
		return self._data["default_schedule"]
	@default_schedule.setter
	def default_schedule(self, value: List[List[str]]):
		self._data["default_schedule"] = value
		self.save()
	@property
	def special_days(self) -> Optional[Dict[str, List[str]]]:
		return self._data["special_days"]
	@special_days.setter
	def special_days(self, value: Optional[Dict[str, List[str]]]):
		self._data["special_days"] = value
		self.save()
	@property
	def debug(self) -> bool:
		return self._data["debug"]
	@debug.setter
	def debug(self, value: bool):
		self._data["debug"] = value
		self.save()
def open_settings(root, settings:Settings):
	_settings = tk.Toplevel(root)
	_settings.title("Timer Settings")
	_settings.winfo_
	_settings.grid(20, 20, 200, 200)
	tk.Button(_settings, text="Exit Program", command=lambda: root.destroy()).grid(column=19, row=0)

# Clock Window
mainlabel:tk.Label|None = None
timelabel:tk.Label|None = None
class1label:tk.Label|None = None
class2label:tk.Label|None = None
loc1label:tk.Label|None = None
loc2label:tk.Label|None = None
vert_separator:Separator|None = None
separator:Separator|None = None
runtime:asyncio.AbstractEventLoop|None = None
dummy_date:None|datetime = None
def font_size(size:int): return Font(size=size)
async def set_click_through():
	if platform != "win32":
		return print(f"User is not on windows. ({platform} instead)")
	print("Setting click-through window")
	try:
		hwnd = windll.user32.FindWindowW(None, u"Csengetés időzítő")  # Get correct window handle
		styles = windll.user32.GetWindowLongW(hwnd, -20)
		styles |= 0x00000020  # WS_EX_LAYERED (Allows transparency)	
		styles |= 0x00000080  # WS_EX_TRANSPARENT (Click-through)
		windll.user32.SetWindowLongW(hwnd, -20, styles)
	except Exception as e:
		print(f"An error occured during transparency setting: {e}")
async def is_battery_saver_on(on_val, off_val):
	class SYSTEM_POWER_STATUS(Structure):
		_fields_ = [
			("ACLineStatus", c_byte),
			("BatteryFlag", c_byte),
			("BatteryLifePercent", c_byte),
			("SystemStatusFlag", c_byte)
		]
	status = SYSTEM_POWER_STATUS()
	if windll.kernel32.GetSystemPowerStatus(byref(status)) == 0:
		return off_val # Failed to get status, assume OFF
	return on_val if bool(status.SystemStatusFlag & 1) else off_val  # 1 means Battery Saver is ON
async def transparency_check(root:Tk):
	async def is_cursor_over_window(root:Tk):
		win_x = root.winfo_rootx()
		win_y = root.winfo_rooty()
		return (win_x <= root.winfo_pointerx() <= win_x + root.winfo_width() and 
				win_y <= root.winfo_pointery() <= win_y + root.winfo_height())
	while True:
		if not await is_cursor_over_window(root) and root.wm_attributes("-alpha") != 0.65: 
			root.wm_attributes("-alpha", 0.65)
		elif await is_cursor_over_window(root) and root.wm_attributes("-alpha") != 0.10: 
			root.wm_attributes("-alpha", 0.10)
		await asyncio.sleep(await is_battery_saver_on(1, 0.1))
async def get_rn():
	return datetime.now() if dummy_date is None else dummy_date
async def startup():
	global mainlabel, timelabel, loc1label, loc2label, class1label, class2label, root, separator, vert_separator, borderless, transparency_switch
	root = Tk()
	root.configure(background="black")
	root.attributes("-topmost", True)
	root.title("Csengetés időzítő")
	root.resizable(False, False)
	root.overrideredirect(True)
	root.wm_attributes("-alpha", 0.65)
	root.grid(1920//8//3, 1080//8//4, 3, 4)
	root.grid_propagate(False)
	root.config(padx=15, pady=15, border=1, borderwidth=1)
	init_data = {
		"text":"Init",
		"bg":"black",
		"fg":"white"
	}
	mainlabel = tk.Label(root, init_data, font=font_size(20))
	mainlabel.grid(row=0, column=0, sticky="nsew", columnspan=3)
	mainlabel.grid_rowconfigure(0, weight=1)
	timelabel = tk.Label(root, init_data, font=font_size(30))
	timelabel.grid(row=1, column=0, sticky="nsew", columnspan=3)
	timelabel.grid_rowconfigure(1, weight=1)
	separator = Separator(root, orient="horizontal")
	separator.grid(row=2, column=0, sticky="ew", padx=5, pady=5, columnspan=3, ipadx=100)
	separator.grid_rowconfigure(2, weight=1)
	class2label = tk.Label(root, init_data, font=font_size(10))
	class2label.grid(row=3, column=2, sticky="nsew")
	class1label = tk.Label(root, init_data, font=font_size(10),padx=5)
	class1label.grid(row=3, column=0, sticky="nsew")
	class1label.grid_rowconfigure(3, weight=1)
	loc2label = tk.Label(root, init_data, font=font_size(10))
	loc2label.grid(row=4, column=2, sticky="nsew")
	loc1label = tk.Label(root, init_data, font=font_size(10), padx=5)
	loc1label.grid(row=4, column=0, sticky="nsew")
	asyncio.create_task(set_click_through())
	asyncio.create_task(transparency_check(root))
	del init_data
	root.update()
	asyncio.create_task(update_cycle())
	root.protocol("WM_DELETE_WINDOW", root.withdraw)
	setup_tray(root, open_settings)
	print_info("Startup complete")
async def update_cycle():
	async def set_dynamic_size():
		if root.winfo_width() == separator.winfo_width(): return
		if debug: print(f"setting dynamic size")
		root.geometry(f"{separator.winfo_width()//2}x{mainlabel.winfo_height()-10}+{root.winfo_screenwidth()-(separator.winfo_width())-50}+0")
		root.update()
	global mainlabel, timelabel, class1label, class2label, loc1label, loc2label, root, vert_separator
	prev_day:int = (await get_rn()).day
	while True:
		_start = perf_counter()
		if debug: print("Update cycle called")
		if prev_day != (await get_rn()).day:
			prev_day = (await get_rn()).day
			if debug: print("Day changed, generating new csengetes")
			runtime.run_in_executor(None, generate_csengetes)
		for num, tmp in enumerate(csengetes):
			start, end, ora = tmp
			start:time; end:time; ora:tuple[str]|tuple[tuple[str]]|None
			now = (await get_rn()).time()
			if (start > now and ora is not None):
				tmp = datetime.combine((await get_rn()), start) - datetime.combine((await get_rn()), now)
				mainlabel.config(text=f"Szünet végéig")
				timelabel.config(text=f"{f"{tmp.seconds//3600:02}:" if tmp.seconds//3600 != 0 else ""}{(tmp.seconds//60)%60:02}:{tmp.seconds%60:02}")
				class1label.config(text=f"{ora[0]}" if not isinstance(ora[0], tuple) else f"{ora[0][0]}", anchor="center")
				if isinstance(ora[0], tuple):
					await set_dynamic_size()
					class2label.config(text=f"{ora[1][0]}", anchor="center", wraplength=class2label.winfo_width())
					class1label.grid_configure(columnspan=1)
					loc1label.config(text=f"{ora[0][1]}", wraplength=loc1label.winfo_width())
					loc2label.config(text=f"{ora[1][1]}", wraplength=loc2label.winfo_width())
					loc1label.grid_configure(columnspan=1)
					if vert_separator is None:
						vert_separator = Separator(root, orient="vertical")
						vert_separator.grid(row=3, column=1, sticky="ns", padx=5, pady=5, rowspan=2)
				else:
					await set_dynamic_size()
					if vert_separator is not None:
						vert_separator.destroy()
						vert_separator = None
					class2label.config(text="", wraplength=class2label.winfo_width())
					class1label.grid_configure(columnspan=3)
					class1label.config(wraplength=class1label.winfo_width())
					loc1label.config(text=f"{ora[1]}", wraplength=loc1label.winfo_width())
					loc2label.config(text="", wraplength=loc2label.winfo_width())
					loc1label.grid_configure(columnspan=3)
				class1label.config(wraplength=class1label.winfo_width())
				break
			elif (end > now and ora is not None):
				tmp = datetime.combine((await get_rn()), end) - datetime.combine((await get_rn()), now)
				mainlabel.config(text=f"{num+1}. Óra végéig")
				timelabel.config(text=f"{f"{tmp.seconds//3600:02}:" if tmp.seconds//3600 != 0 else ""}{(tmp.seconds//60)%60:02}:{tmp.seconds%60:02}")
				class1label.config(text=f"{ora[0]}" if not isinstance(ora[0], tuple) else f"{ora[0][0]}", anchor="center")
				if isinstance(ora[0], tuple):
					await set_dynamic_size()
					class2label.config(text=f"{ora[1][0]}", anchor="center")
					class1label.grid_configure(columnspan=1)
					loc1label.config(text=f"{ora[0][1]}")
					loc2label.config(text=f"{ora[1][1]}")
					loc1label.grid_configure(columnspan=1)
					if vert_separator is None:
						vert_separator = Separator(root, orient="vertical")
						vert_separator.grid(row=3, column=1, sticky="ns", padx=5, pady=5, rowspan=2)
				else:
					await set_dynamic_size()
					class2label.config(text="")
					class1label.grid_configure(columnspan=3)
					class1label.config(wraplength=class1label.winfo_width())
					loc1label.config(text=f"{ora[1]}")
					loc2label.config(text="")
					loc1label.grid_configure(columnspan=3)
					if vert_separator is not None:
						vert_separator = vert_separator.destroy()
				break
		else:
			mainlabel.config(text="A napnak vége")
			timelabel.config(text="")
			class1label.config(text="")
			class2label.config(text="")
			loc1label.config(text="")
			loc2label.config(text="")
			if vert_separator is not None:
				vert_separator.destroy()
				vert_separator = None
			await asyncio.sleep(60)
			continue
		root.update()
		update_delay = await is_battery_saver_on(5, 1)
		delay = max(0, update_delay - (perf_counter() - _start))
		await asyncio.sleep(delay)

# Logging prints
def print_info(text):
	print(text)
	logger.info(text)
def print_debug(text):
	print(text)
	logger.debug(text)
def print_warning(text):
	print(text)
	logger.warning(text)
def print_error(text):
	print(text)
	logger.error(text)
def print_critical(text):
	print(text)
	logger.critical(text)

MAX_LOGS:int=5
def main():
	def cleanup_old_logs(log_folder: str = "logs", prefix: str = "timer_"):
		"""Delete old log files, keeping only the last MAX_LOGS."""
		folder = Path(log_folder)
		# get all files that start with prefix and end with .log
		log_files = sorted(folder.glob(f"{prefix}*.log"), key=lambda f: f.stat().st_mtime, reverse=True)
		# keep only the first MAX_LOGS, delete the rest
		for old_file in log_files[MAX_LOGS:]:
			old_file.unlink()
	cleanup_old_logs()
	filename = f"logs/timer_{datetime.now().date().isoformat().replace('-', '_')}.log"
	if (not path.isdir("logs")): mkdir("logs")
	log_format = "%(asctime)s::%(levelname)-8s:%(message)s"
	logging.basicConfig(filename=filename, encoding='utf-8', level=logging.DEBUG if environ.get('TERM_PROGRAM') == 'vscode' else logging.WARNING, format=log_format, datefmt="%H:%M:%S")
	print_info("Application Starting up")
	settings = Settings()
	root = Tk()
	setup_tray(root)

main()