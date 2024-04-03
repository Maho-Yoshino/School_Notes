#Olvass be egy dátumot (év, hónap, nap)! Írj programot, amely kiírja megelőző napot, év.hónap.nap formában!
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
        ev, honap, nap = map(int, input("Adjon meg egy dátumot \"ÉÉÉÉ.HH.NN\" formátumban:").split('.'))
        if honap not in range(1,13) or (honap==2 and szokoev(ev) and nap>29) or (honap==2 and not szokoev(ev) and nap>28) or (honap in days30 and nap>30) or (honap in days31 and nap>31):
            raise Exception
        else:
            numinput = False
    except Exception:
        continue
if honap==1 and nap==1:
    ev-=1
    honap=12
    nap=31
elif nap==1:
    honap-=1
    if honap in days30:
        nap=30
    elif honap in days31:
        nap=31
    elif honap == 2 and not szokoev(ev):
        nap=28
    else:
        nap=29
else:
    nap-=1
print(f"Az előző nap:{ev}.{honap}.{nap}")