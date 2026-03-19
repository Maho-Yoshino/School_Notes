# Vezérlési Szerkezetek  
## Szekvencia  
- Egymást követő lépések sorozata  
```cs  
using System;  

static void Main(string[] args) {  
	Console.WriteLine("1");  
	Console.WriteLine("2");  
	...  
}  
```  
- Először kiírja, hogy 1, majd 2, mivel sorrendbe megy végig a program a sorokon  
- Ez az alapja a programok végrehajtási sorrendjének  
## Elágazás  
- Két fő módja van az elágazás megvalósításnak  
### Klasszikus  
```cs  
if (ertek == 0) {  
	...  
}  
else if (ertek == 1) {  
	...  
}  
else {  
	...  
}  
```  
### Switch  
```cs  
switch(ertek) {  
	case 0:  
		...  
		break;  // Általában kötelező hogy ne fusson tovább a következő case-re  
	case 1:  
		...  
		break;  
	default:  
		...  
		break;  
}  
```  
### Feltételes (ternary) operátor  
- Ezt inkább csak egyszerű értékadásnak használjuk, de elágazásnak tekinthető  
```cs  
string eredmeny = ertek == 0 ? "Nulla":"Nem nulla";  
```  
- Hosszabb verziója ennek a kódnak:  
```cs  
string eredmeny;  
if (ertek == 0) {  
	eredmeny = "Nulla";  
}  
else {  
	eredmeny = "Nem nulla";  
}  
```  
## Ciklusok  
- Folyamatosan ismétlik a bennük lévő kódot (más néven ciklusmag) amíg egy feltétel (ciklusfeltétel) nem igaz  
- 3 Ciklus típust ismerünk  
### Előtesztelő  
- Előre le kell ellenőrizni egy feltételt, és igaznak kell lennie, mielőtt a ciklus elindul  
- Amíg igaz a feltétel addig fut  
	- Lehetséges végtelen ciklust, akár direkt, akár véletlen csinálni velük  
```cs  
bool ciklusFolytat = true;  
int[] ertekek = new int[] {0, 1, 1, 2, 6, -1, 8, 9, 1};  
int i = 0;  
while (ciklusFolytat && i < ertekek.Length) { // Addig fut amíg ciklusFolytat nem hamis, vagy a tömb végéig nem érünk  
	if (ertekek[i] == -1) {  
		ciklusFolytat = false;  // Ezt a ciklust még lefuttatja a program, és a következőnél leáll a ciklus, mivel a feltétel már nem lesz igaz  
	}  
	Console.WriteLine(ertekek[i]);  
	i++;  
}  
```  
- A keresés tételére tökéletesen használható  
### Hátultesztelő  
- Lehet a ciklusmagon belül ellenőrizni egy értéket, majd azt használni a ciklusfeltételben  
- Amíg igaz a feltétel addig fut  
	- Ez is képes végtelen ciklust csinálni  
```cs  
bool folytatCiklus; // típust deklarálni kell a ciklusmagon kívül  
do {  
	Console.WriteLine("Szeretne kilépni? (i/n)");  
	folytatCiklus = Console.ReadLine().ToLower()[0] != 'i'; // Hamis ha igennel válaszolunk és kilép a ciklusmag; különben újra megkérdezi  
}  
while (folytatCiklus);  
```  
### Számláló  
- Megadott számszor fut le a ciklusmag  
```cs  
for (int i = 0; i < 10; i++) {  
	Console.WriteLine(i);  
}  
```  
- Ez a program 10x le fogja futtatni a ciklusmagot, kiírva a számokat 0-tól 9-ig  
- Ciklusfeltétel összetétele:  
	- Kezdőérték (és lehetséges érték típus) deklarálása  
	```cs  
	int i = 0; ...  
	```  
	- Feltétel (amíg igaz addig fut a ciklus)  
	```cs  
	...; i < 10; ...  
	```  
	- Iterátor (Minden ismétlés végén ezt az utasítást végrehajtja)  
	```cs  
	...; i++) {...  
	```  
### Foreach  
- Könnyebb verziója a `számláló ciklusnak`, ha egy tömbön, vagy más iterálható adatszerkezeten szeretnénk **végigmenni**  
```cs  
int[] szamok = new int[] {0, 1, 5, 3, 4, 7};  
foreach (int szam in szamok) {  
	...  
}  
```  
### EXTRA: Break  
- A szent és megmentő: `break`  
- Ha egy ciklusba (akármelyik típusba) beletesszük a kód 10x jobb lesz (*egyesek nem értenek egyet a világnézetemmel*)  
- A switchben az egyetlen elfogadott hely, ahol **kötelező** használni  
