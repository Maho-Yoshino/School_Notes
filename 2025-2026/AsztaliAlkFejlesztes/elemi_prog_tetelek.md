# Elemi programozási tételek  
![Összes tétel](media/programozas_tetelek/tetelek.png)  
## Összegzés  
- Egy sorozat elemeinek összegét számítjuk ki  
- Végigmegyünk az összes elemen, és egy változóban folyamatosan hozzáadjuk az értékeket  
### Folyamatábra  
![Összegzés tétele folyamatábra](media/programozas_tetelek/osszegzes_folyamat.png)  
### Struktogram  
![Összegzés tétele struktogram](media/programozas_tetelek/osszegzes_strukto.png)  
### Mondatszerű leírás  
```  
eljárás osszegzes  
	osszeg := 0  
	ciklus i := 1 -> N  
		osszeg = osszeg + A\[i]  
	ciklus vége  
	ki osszeg  
eljárás vége  
```  
## Megszámlálás  
- Megszámoljuk, hány elem felel meg egy adott feltételnek  
### Folyamatábra  
![Megszámlálás tétele folyamatábra](media/programozas_tetelek/megszamlalas_folyamat.png)  
### Struktogram  
![Megszámlálás tétele struktogram](media/programozas_tetelek/megszamlalas_strukto.png)  
### Mondatszerű leírás  
```  
eljárás megszamlal  
	j := 0  
	ciklus i := 1 -> N  
		ha A\[i] K tulajdonságnak megfelel  
			j = j + 1  
		elágazás vége  
	ciklus vége  
	ki j  
eljárás vége  
```  
## Szélsőérték kiválasztás  
- Más néven min/max kiválasztás  
- A legkisebb vagy legnagyobb elemet keressük a sorozatban  
### Folyamatábra  
![Szélsőérték (Maximum) tétele folyamatábra](media/programozas_tetelek/szelsoertek_folyamat.png)  
### Struktogram  
![Szélsőérték (Minimum) tétele struktogram](media/programozas_tetelek/szelsoertek_strukto.png)  
### Mondatszerű leírás  
```  
eljárás minimum  
	min := A\[1]  
	ciklus i := 2 -> N  
		ha A\[i] < min:  
			min := A\[i]  
		elágazás vége  
	ciklus vége  
	ki min  
eljárás vége  
```  
## Eldöntés  
- Megállapítjuk, hogy van-e olyan elem, ami megfelel egy feltételnek  
### Folyamatábra  
![Eldöntés tétele folyamatábra](media/programozas_tetelek/eldontes_folyamat.png)  
### Struktogram  
![Eldöntés tétele struktogram](media/programozas_tetelek/eldontes_strukto.png)  
### Mondatszerű leírás  
```  
eljárás eldontes  
	j := hamis  
	ciklus i := 1 -> N  
		ha A\[i] K tulajdonságnak megfelel, akkor  
			j := igaz  
		elágazás vége  
	ciklus vége  
	ki j  
eljárás vége  
```  
## Kiválasztás  
- Megkeressük az első elemet, amely megfelel egy feltételnek  
### Folyamatábra  
![Kiválasztás tétel folyamatábra](media/programozas_tetelek/kivalasztas_folyamat.png)  
### Struktogram  
![Kiválasztás tétel struktogram](media/programozas_tetelek/kivalasztas_strukto.png)  
### Mondatszerű leírás  
```  
eljárás kivalasztas  
	j := -1  
	i := 1  
	ciklus amíg j = -1 és i < N  
		ha A\[i] K tulajdonságnak megfelel, akkor  
			j := A\[i]  
		elágazás vége  
	ciklus vége  
	ki j  
eljárás vége  
```  
## Lineáris keresés  
- Egyesével lépkedünk végig a sorozaton, amíg egy `P` tulajdonságú `A` elemet nem találunk  
	- Ennek megtalálása után abbahagyjuk a keresést, és visszaadjuk az `A` elem indexét  
	- Különben `-1`  
### Folyamatábra  
![Lineáris keresés tétel folyamatábra](media/programozas_tetelek/kereses_folyamat.png)  
### Struktogram  
![Lineáris keresés tétel struktogram](media/programozas_tetelek/kereses_strukto.png)  
### Mondatszerű leírás  
```  
eljárás linearis  
	j := -1  
	ciklus amíg j = -1 és i < N  
		ha A\[i] K tulajdonságnak megfelel, akkor  
			j := i  
		elágazás vége  
	ciklus vége  
	ki j  
eljárás vége  
```  
