#Írj programot, amely beolvas egy hónap sorszámát és megadja ezek alapján, hogy az adott hónap hány napos! Tekintsük úgy, hogy csak [1..12] intervallumból adhatunk meg adatokat!
numinput = True
while numinput:
    try:
        honap = int(input("Adjon meg egy hónapot: "))
        if honap not in range(1,13):
            raise Exception
        else:
            numinput = False
    except Exception:
        continue
days31 = [1,3,5,7,8,10,12]
days30 = [4,6,9,11]
if honap == 2:
    print("A hónap 28/29 napos")
elif honap in days31:
    print("A hónap 31 napos")
elif honap in days30:
    print("A hónap 30 napos")
else:
    raise Exception("Hibás hónap szám megadva")