#Olvassunk be egy dátumot és határozzuk meg a helyességét!
from datetime import datetime
hibas = False
try:
    datum1 = datetime.strptime(input("Adjon meg egy dátumot \"ÉÉÉÉ.HH.NN\" formátumban:"), "%Y.%m.%d")
except Exception:
    print("A dátum hibás")
    hibas=True
if not hibas:
    print("A dátum helyes")