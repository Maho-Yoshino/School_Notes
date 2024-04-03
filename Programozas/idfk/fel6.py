#Olvassunk be két dátumot ponttal elválasztva! Határozzuk meg, melyik a korábbi!
from datetime import datetime 
numinput = True
days31 = [1,3,5,7,8,10,12]
days30 = [4,6,9,11]
def szokoev(ev:int):
    if ev%4==0 and (ev%100!=0 or ev%400==0):
        return True
    else:
        return False
while numinput:
    try:
        datum1, datum2 = map(str, input("Adjon meg két dátumot \"ÉÉÉÉ,HH,NN.ÉÉÉÉ,HH,NN\" formátumban:").split('.'))
        datum1 = datetime.strptime(datum1,"%Y,%m,%d")
        datum2 = datetime.strptime(datum2,"%Y,%m,%d")
        numinput=False
    except Exception as e:
        print(e)
        continue
if datum1 > datum2:
    print(f"A korábbi dátum: {datum2}")
else:
    print(f"A korábbi dátum: {datum1}")