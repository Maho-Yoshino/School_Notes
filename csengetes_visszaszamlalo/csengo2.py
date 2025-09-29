import tkinter as tk, ctypes, asyncio
from tkinter import Tk
from tkinter.ttk import Separator
from tkinter.font import Font
from datetime import datetime, time, timedelta
from os import environ
from sys import platform
from time import perf_counter

# Debug setup
if __name__ == "__main__":
	if environ.get('TERM_PROGRAM') != 'vscode':
		debug = False
	else:
		debug = True
else:
	debug = True
print(f"Debug mode: {'Enabled' if debug else 'Disabled'}")
MAX_CLASSES = 8

ANG = "Angol", "A06"
TOR = "Történelem","206"
IRO = "Irodalom","206"
NYT = "Nyelvtan","206"
MAT = "Matematika","206"
SZK = "Szakmai Angol","206"
OFO = "Osztályfőnöki", "206"
ALL = "Állampolgári Ismeretek", "206"
WEB = "Webprogramozás","M115"
WEB2 = "Webprogramozás","M118"
ASZ = "Aszali Alkalmazások","M114"
IKT = "IKT Projekt","M114"
IKT2 = "IKT Projekt","M012"
SZT = "Szoftvertesztelés", "M012"
TES = "Testnevelés","Tesiterem"
csengetes_offset = 31
orarend = [
	#[1.,	2.,		3.,		4.,		5.,		6.,		7.,		8.]
	[None,	TOR, IRO, IRO, SZK, MAT, ANG, ANG], # Hétfő
	[None, WEB2, SZK, ANG, MAT, ALL, TES, OFO], # Kedd
	[None, TOR, MAT, TES, WEB, IKT, IKT, NYT], # Szerda
	[ASZ, ASZ, MAT, IRO, SZT, SZT, IKT], # Csütörtök
	[ANG, TES, TOR, IKT2, IKT2, ASZ], # Péntek
]
csengetes:tuple[tuple[time, tuple[str,tuple,None]]]
async def generate_csengetes(day:"special_day" = None):
	rn = datetime.now() if dummy_date is None else dummy_date
	if day is None and (weekday := rn.weekday()) in range(len(orarend)):
		day = special_day(rn.replace(hour=8, minute=0, second=csengetes_offset), schedule=orarend[weekday])
	global csengetes
	tmp_csengetes = [tuple([day.date.time(), (datetime.strptime(f"{day.date.hour}:{day.date.minute}:{day.date.second}", "%H:%M:%S")+timedelta(minutes=day.class_lengths[0])).time(), day.orarend[0]])]
	prev_end = tmp_csengetes[0][1]
	for i in range(1, MAX_CLASSES):
		class_begin = (datetime.combine(rn.date(), datetime.strptime(f"{prev_end.hour}:{prev_end.minute}:{prev_end.second}", "%H:%M:%S").time()) + timedelta(minutes=day.break_lengths[i-1])).time()
		class_end = (datetime.combine(rn.date(), datetime.strptime(f"{class_begin.hour}:{class_begin.minute}:{class_begin.second}", "%H:%M:%S").time()) + timedelta(minutes=day.class_lengths[i])).time()
		tmp_csengetes.append(tuple([class_begin, class_end, day.orarend[i]]))
		prev_end = class_end
	csengetes = tuple(tmp_csengetes)

mainlabel:tk.Label|None = None
timelabel:tk.Label|None = None
class1label:tk.Label|None = None
class2label:tk.Label|None = None
loc1label:tk.Label|None = None
loc2label:tk.Label|None = None
vert_separator:Separator|None = None
separator:Separator|None = None
runtime:asyncio.AbstractEventLoop|None = None

def font_size(size:int): return Font(size=size)
async def set_click_through():
	if platform != "win32":
		return print(f"User is not on windows. ({platform} instead)")
	print("Setting click-through window")
	try:
		hwnd = ctypes.windll.user32.FindWindowW(None, u"Csengetés időzítő")  # Get correct window handle
		styles = ctypes.windll.user32.GetWindowLongW(hwnd, -20)
		styles |= 0x00000020  # WS_EX_LAYERED (Allows transparency)	
		styles |= 0x00000080  # WS_EX_TRANSPARENT (Click-through)
		ctypes.windll.user32.SetWindowLongW(hwnd, -20, styles)
	except Exception as e:
		print(f"An error occured during transparency setting: {e}")
async def is_battery_saver_on(on_val, off_val):
	class SYSTEM_POWER_STATUS(ctypes.Structure):
		_fields_ = [
			("ACLineStatus", ctypes.c_byte),
			("BatteryFlag", ctypes.c_byte),
			("BatteryLifePercent", ctypes.c_byte),
			("SystemStatusFlag", ctypes.c_byte)
		]
	status = SYSTEM_POWER_STATUS()
	if ctypes.windll.kernel32.GetSystemPowerStatus(ctypes.byref(status)) == 0:
		return off_val # Failed to get status, assume OFF

	return on_val if bool(status.SystemStatusFlag & 1) else off_val  # 1 means Battery Saver is ON
class special_day:
	def __init__(self, date:datetime, class_lengths:list[int]|None=None, break_lengths:list[int]|None=None, schedule:tuple[tuple[str]|None]|None=None):
		self.date = date
		if class_lengths:
			tmp = class_lengths
			while len(tmp) < MAX_CLASSES:
				tmp.append(0)
			self.class_lengths = tmp
		else:
			self.class_lengths = [45, 45, 45, 45, 45, 40, 40, 40]
		if break_lengths:
			tmp = break_lengths
			while len(tmp) < MAX_CLASSES:
				tmp.append(0)
			self.break_lengths = tmp
		else:
			self.break_lengths = [10, 10, 10, 10, 20, 10, 5, 0]
		if date.hour == 0 and date.minute == 0 and date.second == 0:
			self.date = self.date.replace(hour=8, minute=0, second=csengetes_offset)
		if schedule:
			schedule = list(schedule)
			while len(schedule) < MAX_CLASSES:
				schedule.append(None)
			self.orarend = tuple(schedule)
		else:
			if (weekday := date.weekday()) and weekday not in range(len(orarend)):
				self.orarend = None
			else:
				self.orarend = tuple(orarend[weekday])
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

async def startup(*special_csengo:special_day):
	global mainlabel, timelabel, loc1label, loc2label, class1label, class2label, root, separator, vert_separator, borderless, transparency_switch
	root = Tk()
	root.configure(background="black")
	root.attributes("-topmost", True)
	root.title("Csengetés időzítő")
	root.resizable(False, False)
	root.overrideredirect(borderless)
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
	if borderless:
		asyncio.create_task(set_click_through())
	today = (await get_rn()).date()
	if special_csengo:
		for _day in special_csengo:
			if _day.date.year == today.year and _day.date.month == today.month and _day.date.day == today.day:
				await generate_csengetes(_day)
				break
		else:
			await generate_csengetes()
	else:
		await generate_csengetes()
	if transparency_switch:
		asyncio.create_task(transparency_check(root))
	del init_data, borderless, transparency_switch
	root.update()
	asyncio.create_task(update_cycle())
	print("Startup complete")

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
	

dummy_date:datetime|None=None # Dummy date for testing purposes, set to None to use current date and time
borderless = True # Set to True to make the window borderless, False to have a normal window
transparency_switch:bool = True # Set to True to enable transparency, False to disable it

if __name__ == "__main__":
	if debug:
		#dummy_date = datetime(2025, 5, 8, 14, 30)
		...
	runtime = asyncio.new_event_loop()
	asyncio.set_event_loop(runtime)
	runtime.create_task(startup())
	runtime.run_forever()
