# Programozási tételek  
## Unió  
- Kiválasztjuk két sorozat elemeit (akármelyikben benne van)  
- Nincsen egy érték kétszer (nincs duplikáció)  
### Mondatszerű leírással  
- Két sorozat jelenlétét feltételezzünk:  
	- `A`  
	- `B`  
- Ezeknek hossza meg van adva a következő neveken:  
	- `A_n`  
	- `B_n`  
```  
eljárás unio  
	unioArr := A elemeinek másolata  
	db := A_n  
	i := 0  
	ciklus amíg i < B_n  
		j := 0  
		benneVan := hamis  
		ciklus amíg j < db és nem benneVan  
			ha unioArr[j] = B[i] akkor  
				benneVan := igaz  
			elágazás vége  
			j := j + 1  
		ciklus vége  
		ha nem benneVan akkor  
			unioArr[db] := B[i]  
			db := db + 1  
		elágazás vége  
		i := i + 1  
	ciklus vége  
	ki unioArr  
eljárás vége  
```  
## Metszet  
- Kiválasztjuk két sorozat közös elemeit (mindkettőben benne van)  
- Ezeket az elemeket egy külön sorozatba tesszük  
- Nincsenek ismétlődő értékek (nincs duplikáció)  
### Mondatszerű leírással  
- Két sorozat jelenlétét feltételezzünk:  
	- `A`  
	- `B`  
- Ezeknek hossza meg van adva a következő neveken:  
	- `A_n`  
	- `B_n`  
```  
eljárás metszet  
	metszet := []  
	db := 0  
	i := 0  
	ciklus amíg i < A_n  
		j := 0  
		benneABben := hamis  
		ciklus amíg j < B_n és nem benneABben  
			ha A[i] = B[j] akkor  
				benneABben := igaz  
			elágazás vége  
			j := j + 1  
		ciklus vége  
	  
		ha benneABben  
			j := 0  
			marBenne := hamis  
			ciklus amíg j < db és nem marBenne  
				ha metszet[j] = A[i] akkor  
					marBenne := igaz  
				elágazás vége  
				j := j + 1  
			ciklus vége  
			ha nem marBenne  
				metszet[db] := A[i]  
				db := db + 1  
			elágazás vége  
		elágazás vége  
		i := i + 1  
	ciklus vége  
	ki metszet  
eljárás vége  
```  
## Kiválogatás  
- Kiválasztjuk egy sorozatból azokat az elemeket, amik megfelelnek a feltételnek  
- A megfelelő elemeket új sorozatba tesszük  
### Mondatszerű leírással  
- Feltételezünk egy `A` sorozatot  
	- Ennek hosszát deklaráljuk az `n` változóval  
- Feltételezünk egy `K` tulajdonságot  
```  
eljárás kivalogatas  
	kivalogatott := []  
	db := 0  
	i := 0  
	ciklus amíg i < n  
		ha A[i].K akkor  
			kivalogatott[db] = A[i]  
			db := db + 1  
		elágazás vége  
		i := i + 1  
	ciklus vége  
	ki kivalogatott  
eljárás vége  
```  
## Rendezések  
- A linkek a w3schools-os vizualizációkhoz vezetnek, ahonnan ezek le vannak írva  
	- Innen van a logika is dekódolva pszeudokóddá  
### [Az időkomplexitásról](https://www.w3schools.com/dsa/dsa_timecomplexity_theory.php)  
- Jelölése: O(`érték`)  
- Példák:  
	- O(n<sup>2</sup>)  
	- O(n)  
	- O(log<sub>2</sub>n)  
- A legrosszabb esetet feltételezi  
- Megmutatja, meddig tart egy algoritmus futás ideje  
- Általában az `n` értéket szokták használni a sorozat elemszámának jelölésére  
### [Buborékos](https://www.w3schools.com/dsa/dsa_algo_bubblesort.php)  
- "Bubble sort"  
- Időkomplexitás: O(n<sup>2</sup>)  
#### Működés  
- Végig megyünk a sorozaton  
- Minden elemnél összehasonlítjuk a következő elemmel (ha van)  
	- Ha nagyobb a következő, mint a jelenlegi, nem történik csere  
	- Különben felcseréljük az értékeket  
- Annyiszor megy végig a sorozaton, ahány érték van  
#### Mondatszerű leírással  
- Feltételezett egy `A` sorozat, aminek `n` eleme van  
```  
eljárás bubble_sort  
	i := 0  
	ciklus amíg i < n-1  
		j := 0  
		ciklus amíg j < n-i-1  
			ha A[j] > A[j+1] akkor  
				tmp := A[j+1]  
				A[j+1] := A[j]  
				A[j] := tmp  
				elágazás vége  
			j := j + 1  
		ciklus vége  
		i := i + 1  
	ciklus vége  
	ki A  
eljárás vége  
```  
### [Beillesztéses](https://www.w3schools.com/dsa/dsa_algo_insertionsort.php)  
- "Insertion sort"  
- Időkomplexitás: O(n<sup>2</sup>)  
#### Működés  
- Két részre választja valójában a tömböt, ahol  
	- Az egyik fele az eredeti tömb elemei, rendezetlenül  
	- A másik fele a rendezett sorozat  
- Minden régi elemet a rendezett sorozat végére beilleszti, ahonnan folyamatosan mozgatja balra, amíg az előtte lévő érték nem kisebb, mint a mozgatott érték  
	- Abbahagyja az elemek ellenőrzését ha az elem jó helyen van (megteheti, mert az utána lévő elemek rendezettek)  
#### Mondatszerű leírással  
- Feltételezünk egy `A` sorozatot `n` elemmel  
```  
eljárás insertion_sort  
	i := 1  
	ciklus amíg i < n  
		ertek := A[i]  
		j := i-1  
		ciklus amíg j >= 0 és A[j] > ertek  
			A[j+1] := A[j]  
			j := j - 1  
		ciklus vége  

		A[j+1] := ertek  
		i := i + 1  
	ciklus vége  
	ki A  
eljárás vége  
```  
### [Minimumkiválasztásos](https://www.w3schools.com/dsa/dsa_algo_selectionsort.php)  
- "Selection sort"  
- Időkomplexitás: O(n<sup>2</sup>)  
#### Működés  
- Végigmegy a sorozaton, kiválasztva a legkisebb értéket	  
	- Ez az érték meg lesz cserélve az első, nem rendezett értékkel  
	- A következő iteráció már ezt az értéket kihagyja  
#### Mondatszerű leírással  
- Feltételezünk egy `A` sorozatot, `n` elemmel  
```  
eljárás selection_sort  
	i := 0  
	ciklus amíg i < n-1  
		min_ind := i  
		j := i+1  
		ciklus amíg j < n  
			ha A[j] < A[min_ind] akkor  
				min_ind := j  
			elágazás vége  
			j := j + 1  
		ciklus vége  
		tmp := A[min_ind]  
		A[min_ind] := A[i]  
		A[i] := tmp  
		i := i + 1  
	ciklus vége  
	ki A  
eljárás vége  
```  
## [Logaritmikus keresés](https://www.w3schools.com/dsa/dsa_algo_binarysearch.php)  
- "Binary search"  
- Időkomplexitás: O(log<sub>2</sub>n)  
	- Ezért hívjuk logaritmikus keresésnek  
- **Csak** rendezett listával működik  
- Őrületesen hatékony  
#### Működés  
- Van egy `n` elemű `A` sorozat  
- Van egy `K` érték, amit keresünk  
- Ha `A[közép]` nagyobb, mint `K`, akkor a következő iteráció a `0`-`közép-1` tartományt ellenőrzi  
- Ha kisebb `A[közép]`, mint `K`, akkor az `közép+1`-`n-1` tartományt ellenőrzi  
- Ha `A[közép]` az egyenlő `K`-val, akkor `közép`-t visszaadjuk  
- Addig ismétlődik amíg a keresési tartomány nem válik üressé  
	- Ha a végső érték nem a keresett érték, akkor nincs jelen a sorozatban, ebben az esetben `-1`-et ad vissza indexnek  
#### Mondatszerű leírással  
- Feltételezünk egy `A` sorozatot, `n` elemmel  
- Feltételezünk egy `K` értéket, amit keresünk  
```  
eljárás binary_search  
	bal := 0  
	jobb := n-1  
	ciklus amíg bal <= jobb  
		kozep := (bal + jobb)//2  
		ha A[kozep] == K akkor  
			ki kozep  
		különben ha A[kozep] < K akkor  
			bal := kozep + 1  
		különben  
			jobb := kozep - 1  
		elágazás vége  
	ciklus vége  
	ki -1  
eljárás vége  
```  
