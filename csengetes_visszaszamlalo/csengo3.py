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

# Settings window
async def setup_tray(root:Tk):
	def create_image():
		return Image.open("icon.ico")
	def on_quit(icon, item):
		print_info("Closing application")
		icon.stop()
		root.quit()
	def settings_callback():
		runtime.create_task(open_settings(root))
	icon = pystray.Icon("Csengetés időzítő", create_image(), menu=pystray.Menu(
		pystray.MenuItem("Show Overlay", lambda: root.deiconify()),
		pystray.MenuItem("Settings", settings_callback),
		pystray.MenuItem("Quit", lambda icon, item: on_quit(icon, item))
	))
	Thread(target=icon.run, daemon=True).start()
class Settings:
	def __init__(self, filename: str = "settings.json", encoding:str="utf-8"):
		self.filename = filename
		self.encoding = encoding
		self._data: Dict[str, Any] = {}
		self.load_settings()
	def load_settings(self):
		try:
			with open(self.filename, "r", encoding=self.encoding) as f:
				self._data = jload(f)
				print_info("Settings loaded properly")
		except FileNotFoundError:
			print_warning("Settings file not found, creating a default one.")
			with open(self.filename, "x", encoding=self.encoding) as f:
				f.write(r"""{
	"classlist": {},
	"teacherlist": {},
	"default_schedule": [
		[],
		[],
		[],
		[],
		[]
	],
	"special_days": {},
	"classtimes": [],
	"breaktimes": [],
	"special_classtimes": {},
	"special_breaktimes": {},
	"special_begintimes": {},
	"classes_begin":8,
	"delay":0
}
"""
					)
			with open(self.filename, "r", encoding=self.encoding) as f:
				self._data = jload(f)
		# Set default values if missing
		self._data.setdefault("teacherlist", {})
		self._data.setdefault("special_days", None)
		self._data.setdefault("debug", False)
		self._data.setdefault("special_classtimes", {})
		self._data.setdefault("special_breaktimes", {})
		self._data.setdefault("special_begintimes", {})
	def save(self):
		with open(self.filename, "w", encoding="utf-8") as f:
			jdump(self._data, f, indent=4, ensure_ascii=False)
	@property # classlist
	def classlist(self) -> Dict[str, List[str]]:
		return self._data["classlist"]
	@classlist.setter
	def classlist(self, value: Dict[str, List[str]]):
		self._data["classlist"] = value
		self.save()
	@property # default_schedule
	def default_schedule(self) -> List[List[str]]:
		return self._data["default_schedule"]
	@default_schedule.setter
	def default_schedule(self, value: List[List[str]]):
		self._data["default_schedule"] = value
		self.save()
	@property # teacherlist
	def teacherlist(self) -> Dict[str, str]:
		return self._data["teacherlist"]
	@teacherlist.setter
	def teacherlist(self, key: str, value: str):
		if self._data["teacherlist"].get(key, None) is not None:
			self._data["teacherlist"][key] = value
		else:
			self._data["teacherlist"].update({key:value})
		self.save()
	@property # special_days
	def special_days(self) -> Optional[Dict[str, List[str]]]:
		return self._data["special_days"]
	@special_days.setter
	def special_days(self, value: Optional[Dict[str, List[str]]]):
		self._data["special_days"] = value
		self.save()
	@property # debug
	def debug(self) -> bool:
		return self._data["debug"]
	@debug.setter
	def debug(self, value: bool):
		self._data["debug"] = value
		self.save()
	@property # classtimes
	def classtimes(self) -> list[int]:
		return self._data["classtimes"]
	@classtimes.setter
	def classtimes(self, value: list[int]):
		self._data["classtimes"] = value
		self.save()
	@property # breaktimes
	def breaktimes(self) -> list[int]:
		return self._data["breaktimes"]
	@breaktimes.setter
	def breaktimes(self, value: list[int]):
		self._data["breaktimes"] = value
		self.save()
	@property # special_classtimes
	def special_classtimes(self) -> dict[str, int]:
		return self._data["special_classtimes"]
	@special_classtimes.setter
	def special_classtimes(self, value: dict[str, int]):
		self._data["breaktimes"] = value
		self.save()
	@property # special_breaktimes
	def special_breaktimes(self) -> dict[str, int]:
		return self._data["special_breaktimes"]
	@special_breaktimes.setter
	def special_breaktimes(self, value: dict[str, int]):
		self._data["special_breaktimes"] = value
		self.save()
	@property # special_begintimes
	def special_begintimes(self) -> dict[str, int]:
		return self._data["special_begintimes"]
	@special_begintimes.setter
	def special_begintimes(self, value: dict[str, int]):
		self._data["special_begintimes"] = value
		self.save()
	@property # classes_begin
	def classes_begin(self) -> list[int]:
		return self._data["classes_begin"]
	@classes_begin.setter
	def classes_begin(self, value: list[int]):
		self._data["classes_begin"] = value
		self.save()
	@property # delay
	def delay(self) -> int:
		return self._data["delay"]
	@delay.setter
	def delay(self, value: int):
		self._data["delay"] = value
		self.save()
settings = Settings()
_settings:tk.Toplevel|None = None
async def open_settings(root:Tk):
	def exit_seq():
		root.destroy()
		runtime.stop()
	global _settings
	_settings = tk.Toplevel(root)
	_settings.title("Timer Settings")
	_settings.resizable(False, False)
	_settings.grid(20, 20, 200, 200)
	_settings.grid_propagate(False)
	tk.Button(_settings, text="Exit Program", command=exit_seq).grid(column=19, row=0)
	_settings.update()

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
root:Tk
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
async def startup(root:Tk):
	global mainlabel, timelabel, loc1label, loc2label, class1label, class2label, separator, vert_separator
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
	await setup_tray(root)
	root.update()
	asyncio.create_task(update_cycle())
	root.protocol("WM_DELETE_WINDOW", root.withdraw)
	print_info("Startup complete")

class Schedule:
	classes:list["ClassData", list["ClassData"]] = []
	date:datetime = None
	special_day:bool = False
	class ClassData:
		begin:time
		end:time
		classname:str = None 
		room:str = None 
		def __init__(self, _class:str|None, index:int, parent:"Schedule"):
			tmp = settings.classlist.get(_class, [])
			if len(parent.classes) > 0:
					self.begin = (parent.classes[-1].end if not isinstance(parent.classes[-1], list) else parent.classes[-1][0].end) + timedelta(minutes=(settings.special_breaktimes if parent.special_day else settings.breaktimes)[index-1])
			else:
				temp = (settings.special_begintimes.get(parent.date) if parent.special_day else settings.classes_begin)
				self.begin = datetime.strptime(f"{parent.date.strftime("%Y.%m.%d")} {temp//100}:{temp%100}", "%Y.%m.%d %H:%M")
			self.end = self.begin + timedelta(minutes=(settings.special_classtimes if parent.special_day else settings.classtimes)[index])
			if tmp:
				self.classname = tmp[0]
				self.room = tmp[1]
	def __init__(self):
		self.date = (datetime.now() if dummy_date is None else dummy_date).date()
		weekday = self.date.weekday()
		self.special_day = any([day == self.date.date() for day in settings.special_days])
		if weekday in [5,6] and not self.special_day:
			return
		if self.special_day:
			tmp = settings.special_days.get(self.date.date())
			if tmp is None:
				tmp = settings.default_schedule[weekday]
		else: 
			tmp = settings.default_schedule[weekday]
		for ind, classinfo in enumerate(tmp):
			if classinfo is not None and len(classinfo.split("/")) > 1:
				self.classes.append([self.ClassData(_classinfo if _classinfo != "None" else None, ind, self) for _classinfo in classinfo.split("/")])
			else:
				self.classes.append(self.ClassData(classinfo, ind, self))
		print_debug("Initialized Schedule class")
schedule:Schedule|None = None
async def update_cycle():
	async def set_dynamic_size():
		if root.winfo_width() == separator.winfo_width(): return
		if settings.debug: print(f"setting dynamic size")
		root.geometry(f"{separator.winfo_width()//2}x{mainlabel.winfo_height()-10}+{root.winfo_screenwidth()-(separator.winfo_width())-50}+0")
		root.update()
	global mainlabel, timelabel, class1label, class2label, loc1label, loc2label, root, vert_separator, separator, schedule
	prev_day:datetime = (await get_rn()).date()
	schedule = Schedule()
	while True:
		_start = perf_counter()
		delay = settings.delay
		if prev_day != schedule.date:
			prev_day = (await get_rn()).date()
			print_debug("Day changed since last cycle")
			schedule = Schedule()
			if len(schedule.classes) == 0: await asyncio.sleep(60*30)
		now = (await get_rn())
		for num, _class in enumerate(schedule.classes):
			tmp_class:Schedule.ClassData|None = None
			if isinstance(_class, list):
				tmp_class = _class[1]
				_class = _class[0]
			if (_class.begin > now and _class.classname is not None):
				tmp = datetime.combine((await get_rn()), _class.begin) - datetime.combine((await get_rn()), now) + timedelta(seconds=delay)
				mainlabel.config(text=f"Szünet végéig")
				timelabel.config(text=f"{f"{tmp.seconds//3600:02}:" if tmp.seconds//3600 != 0 else ""}{(tmp.seconds//60)%60:02}:{tmp.seconds%60:02}")
				class1label.config(text=f"{_class.classname}", anchor="center")
				if tmp_class is not None:
					await set_dynamic_size()
					class2label.config(text=f"{tmp_class.classname}", anchor="center", wraplength=class2label.winfo_width())
					class1label.grid_configure(columnspan=1)
					loc1label.config(text=f"{_class.room}", wraplength=loc1label.winfo_width())
					loc2label.config(text=f"{tmp_class.room}", wraplength=loc2label.winfo_width())
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
					loc1label.config(text=_class.room, wraplength=loc1label.winfo_width())
					loc2label.config(text="", wraplength=loc2label.winfo_width())
					loc1label.grid_configure(columnspan=3)
				if separator is None:
					separator = Separator(root, orient="horizontal")
					separator.grid(row=2, column=0, sticky="ew", padx=5, pady=5, columnspan=3, ipadx=100)
				class1label.config(wraplength=class1label.winfo_width())
			elif (_class.end > now and _class.classname is not None):
					tmp = datetime.combine((await get_rn()), _class.end.time()) - datetime.combine((await get_rn()), now.time())  + timedelta(seconds=delay)
					mainlabel.config(text=f"{num+1}. Óra végéig")
					timelabel.config(text=f"{f"{tmp.seconds//3600:02}:" if tmp.seconds//3600 != 0 else ""}{(tmp.seconds//60)%60:02}:{tmp.seconds%60:02}")
					class1label.config(text=f"{_class.classname}", anchor="center")
					if tmp_class is not None:
						class2label.config(text=f"{tmp_class.classname}", anchor="center")
						class1label.grid_configure(columnspan=1)
						loc1label.config(text=f"{_class.room}")
						loc2label.config(text=f"{tmp_class.room}")
						loc1label.grid_configure(columnspan=1)
						if vert_separator is None:
							vert_separator = Separator(root, orient="vertical")
							vert_separator.grid(row=3, column=1, sticky="ns", padx=5, pady=5, rowspan=2)
					else:
						class2label.config(text="")
						class1label.grid_configure(columnspan=3)
						class1label.config(wraplength=class1label.winfo_width())
						loc1label.config(text=f"{_class.room}")
						loc2label.config(text="")
						loc1label.grid_configure(columnspan=3)
						if vert_separator is not None:
							vert_separator = vert_separator.destroy()
					if separator is None:
						separator = Separator(root, orient="horizontal")
						separator.grid(row=2, column=0, sticky="ew", padx=5, pady=5, columnspan=3, ipadx=100)
					await set_dynamic_size()
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
			if separator is not None:
				separator.destroy()
				separator = None
			root.geometry(f"{mainlabel.winfo_width()}x{mainlabel.winfo_height()//8}+{root.winfo_screenwidth()-(mainlabel.winfo_width())}+0")
			root.update()
			await asyncio.sleep(60)
			continue
		root.update()
		update_delay = await is_battery_saver_on(5, 1)
		delay = max(0, update_delay - (perf_counter() - _start))
		await asyncio.sleep(delay)


MAX_LOGS:int=5
def main(_dummy_date:datetime|None = None):
	if _dummy_date is not None:
		global dummy_date
		dummy_date = _dummy_date
		del _dummy_date
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
	async def tk_update_loop(root, interval=0.1):
		while True:
			root.update()
			await asyncio.sleep(interval)
	global root, runtime
	root = Tk()
	runtime = asyncio.new_event_loop()
	asyncio.set_event_loop(runtime)
	runtime.create_task(tk_update_loop(root))
	runtime.create_task(startup(root))
	runtime.run_forever()
	runtime.close()

#main(datetime(2025, 9, 30, 9, 15))
main()