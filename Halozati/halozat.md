# Speciális IP címek
## 0.0.0.0/8 (0 kezdetűek)
Érvénytelen IP cím, nem használjuk
Az eszközök, melyek nem kaptak még IP címet, 0.0.0.0-t állítja be
## 127 kezdetűek
Loopback címek, az összes ilyen cím minden eszköz számára saját magát jelenti
Ha egy állomás önmagát el akarja érni, akkor a 127.0.0.1-re küld üzenetet
## 255.255.255.255
Az általános szórási cím (bármely hálózatban az összes eszköznek szól, nem jut ki a hálózatból)
## Privát IP címek
Nem használhatók az interneten, csak belső hálózaton
- 10-el kezdődők
- 172.16...-172.31...
- 192.168...
## APIPA címek
"Automatic Private IP Address"
Akkor használják az eszközök, ha nem tudnak IP címet lekérni
169.254.0.0/16
## Testnet
Példahálózatok
192.0.2.0/24
198.51.100.0/24
203.0.113.0/24
## Hálózatok speciális címei
- Hálózat első címe: Maga a hálózat címe. Otthoni applikációban a WiFi router. Nem használható állomások számára (pl. 192.168.1.0)
- Hálózat utolsó címe: A hálózat szórási címe, más hálózatokból is elérhető, ez sem használható állomáscímként (pl. 192.168.1.255)

# ARP protocol
Ismert IP címhez tartozó MAC címet derít fel
Address Resolution Protocol
[Ethernet][[IP Csomag][Üzenet]]
Korlátozás: Az üzenetek nem mennek ki a hálózatból
Mindenkitől megkérdi, kié az IP cím, és csak az válaszol, akihez tartozik a kérdezett IP cím
Ez jól működik, ha hálózaton belüli eszközt keresünk. Különben nem lehet ARP-vel elérni, a Default Gateway-nek kell küldeni az üzenetet, mely majd továbbítja.
A Default Gateway mindig egy hálózatban van az állomással 
Az állomás kb. 10 percig eltárolja a MAC címet az ARP-táblázatában, minden beérkező üzenetnél frissül, dinamikus táblázat 

# IP csomag felépítése
ipcsomag.docx

# Hálózatok számítása
## Hogyan lehet megtudni, mi van egy hálózatban
- Hálózatcímük megegyezik
## Hálózati cím megállapítása
- IP példa: 192.168.1.157
- Alhálózati maszk: 255.255.255.0
- Hálózatcím: 192.168.1.0 -> Ahol a subnet mask 255 ott másol, ahol 0, ott 0 lesz
- Valóságban a gép bitenként hasonlítja össze az IPket
- 
## Speciális alhálózati cím
Ha a hálózatcím nem oktett határán van
255.255.255.128 -> 25 bit (/25)
Ekkor 7 bit jut az állomásoknak -> 2^7 = 128 cím, 126 eszközcím
Ha pl. /24 hálózatból /25öst csinálunk, akkor 2db hálózat lesz, 
### 192.168.1.0/24 -> 192.168.1.0/25 (0-127) és 192.168.1.128/25 (128-255)
Ha továbbnöveljük a maszk hosszát, minden esetben feleződik a hálózatok mérete és kétszer annyi lesz
255.255.255.192 (/26) -> 64 cím, 62 eszközcím
### 192.168.1.0/24 -> 192.168.1.0/26 (0-63), 192.168.1.64/26 (64-127), 192.168.1.128/26 (128-191) és 192.168.1.192/26 (192-255)
### Egyéb maszkok
255.255.255.192 (/26)  
255.255.255.224 (/27)  
255.255.255.240 (/28)  
255.255.255.248 (/29)  
255.255.255.252 (/30)  
# IPv6  
- Globálisan egyedi címek  
- Link Local Címek  
- Unicast Local Címek  
	- Csak helyi hálózat  
	- FC-FD kezdetű címek  
- Loopback cím (Az állomás önmaga) (::1)  
- Érvénytelen (nem definiált) cím (::)  
- Tesztelésre fenntartott címek (2001:db8::/32)  
## Hálózatok IPv6-ban  
Hálózatcím itt is a hálózat első címe, de itt az használható állomáscímként, az IPv6-ban a hálózatcímet hálózati   prefixnek hívják, az alhálózati maszk neve az IPv6 hálózatnál prefixhossz
A prefixhossz alakja: csak perjeles forma használt: a hálózatcím hossza van perjel után bitekben (/64)

# Mit szállít az IP csomag 
- Szállítási réteg üzenetét (Szállítási réteg feladata: 
  - Az alkalmazások üzenetének továbbítása a másik állomás megfelelő alkalmazásának, az alkalmazásokat portszámmal azonosítja)  
  - Az üzenetek darabolása, hogy beleférjen egy IP csomagba (Ethernet keret)  
-  Protokollok a szállításban: TCP, UDP, (RTP)  
# TCP (Transmission Control Protocol)  
- Hibamentes, sorrendhelyes továbbítás  
- Kapcsolat két végpont között (P2P)  
Hibamentesség: Pozitív nyugtázás (mindent nyugtáz)  

# UDP (User Datagram Protocol)  
- Nincs kapcsolat a végpontok között  
- Legjobb szándékú továbbítás -> Nincs garancia a hibamentes működésre  
- A beérkező szegmenseket érkezési sorrendben állítja össze  
Akkor használják:  
- ha rövid kérdésre rövid választ várunk a szervertől  
- Valós idejű alkalmazások (videó, hang átvitele hívások és közvetítés esetén)  
- Hálózati bootolás, konfigurációk mentése  
Előnyei:  
- Egyszerű  
- gyors  
- nem körülményes  
- kisebb fejléc  
A fejléc: "C:\Users\user\Documents\Iskola\2023-2024\Halozati\UDPcsomag.docx"  

# Alkalmazási réteg  
A felhasználónak nyújt szolgáltatásokat  
Ebben található az összes felhasználó által használt program  
HTTP: HyperText Transfer Protocol  
	Weboldalak adatainak átvitele  
	Sima szövegként visz át az adatot, nem titkosít, nem hitelesít  
	TCP-t használ átvitelre és a szerver mindig a 80as portot használja  
HTTPS: HyperText Transfer Protocol Secure  
	Weboldalak átvitele  
	Titkosít, hitelesít (tanusítvánnyal)  
	TCP-t használ, 433  
DHCP: Dynamic Host Configuration Protocol  
	ez IP címet biztosít  
	Van címkészlete, abból felajánl egyet (IPv4)  
	Ha elfogadja, akkor egy bérleti viszony jön létre, megadott időtartamra van a cím  
	IP-n kívül küldhet egyéb opciókat hálózati confighoz  
	UDP 67(szerver) és UDP 68(kliens) portot használja  
DNS: Domain Name Service  
	Állomás nevéből IP címet megkeresi  
	google.com -> 142.251.39.14  
	Lekéréshez: UDP 53  
	Információ csere: TCP 53  
  
# DHCP folyamata  
Problem: Nincs IP ->   
	Nem címezhető az állomás -> Solution: Szórásos üzenet  
	Nem tud mit beírni feladó IPnek -> 0.0.0.0  
	Az állomás nem tudja a DHCP szerver címét se -> Csak szórással tudja megkeresni  
	Erre használja a 255.255.255.255ös általános szórási címet. Ez mindenhol szórási cím  
DHCP Discover:   
	Célja felfedezni a DHCP szervert  
	Kliens -> Szerver  
	0.0.0.0-> 255.255.255.255  
	Saját  -> FF:FF:FF:FF:FF:FF  
DHCP Offer:  
	A szerver válasza. elküld a kliensnek egy ajánlatot az IP címre (IP, maszk, opciók, bérleti idő)  
		Kliens -> Szerver  
	IP  Saját  -> 255.255.255.255  
	MAC Saját  -> FF:FF:FF:FF:FF:FF  
DHCP Request:  
	Kliens megigényli az Offert  
		Kliens -> Szerver  
	IP  0.0.0.0-> 255.255.255.255  
	MAC Saját  -> FF:FF:FF:FF:FF:FF  
DHCP Acknowledgement  
	A szerver elfogadja az igénylést, bejegyzi a bérletet   
	Címzés ugyanúgy mint az Offer	↓  
	↓  
	Amikor a Kliens megkapja ezt akkor kezdi el használni a címet -> Ellenőrzés  
# DNS (Domain Name Service)  
- Állomás nevéből IP címet megkeresi  
- google.com -> 142.251.39.14  
- Lekéréshez: UDP 53  
- Szerverek között: TCP 53  
- Internetes tartományokba osztjuk és minden tartományban üzemelhetnek egy szervert, amely az összes, a tartományban lévő eszköznek tudja a nevét, IP címét  
- Típusai:  
  - Primary Name Server (elsődleges név és IP adatbázis; itt lehet új bejegyzést készíteni, meglevőket módosítani; minden tartományban van 1; ha több van egy tartományban, szinkronizálnak egymással)
  - Secondary Name Server (másodlagos névkiszolgáló; itt csak lekérdezés van; Szinkronizált)  
  - Stub (Nem szinkronizált másolat; csak olvasható)  
- Hogyan lehet megtalálni egy másik tartomány név szerverét?  
	A DNS tartományok egy hierarchikus rendszert alkotnak, a rendszer tetején 13db RNS (Root name server) áll, és ezek csak a fő tartomány nevét tudják (pl. .com, .hu, .eu, .net, .org, ect.)  
	Az RNS szerverek A-M vannak betűzve (MO. a K,M-hez tartozik)  
 DNS feloldás:  
Input: google.com  
1. .hosts fájl -> DNS előtti világ maradéka (Priority) ("C:\Windows\System32\drivers\etc\hosts")  
2. Helyi DNS cache -> Szerepel-e korábban eltárolva ez a név a cacheben (Számítógép tárolja) -> Kb. 1 napig tárolja  
3. DNS szervertől lekérdezi, ha be van állítva: a DNS szerver minden esetben válaszol  
Steps 1-3: számítógép tevékenysége
Szerver oldal:
1. Helyi tartományba tartozik-e a kérés -> Igen:megválaszolja
2. Saját Cache
3. Feloldás RNS-en keresztül, megkérdezi az egyik rootname szervert, hogy mi a .com tartomány névkiszolgálója IP címe
4. A .com névkiszolgálójától lekéri a keresett IP címet
5. Megkérdezi a google.com névkiszolgálójától a keresett IP címet
Output: 142.251.39.14

# További alkalmazási réteg-beli protokollok
## Email
1. Levélküldés protokollja: SMTP (Simple Mail Transfer Protocol)
Feladata: Levél -> címzett postaládája
TCP 25
2. Levél letöltés/fogadás: Postaláda -> Címzett 
   - PoP3
	TCP 110
	Csak letölt és töröl a postaládából
   - IMAP
	TCP 143
	Rendezési lehetőségek és letöltés
## Fájlátviteli protokolok
### FTP (File Transfer Protocol)
- Bejelentkezés másik számítógépbe és onnan fájlok le/feltöltése
- TCP 21 (Parancsok), TCP 20 (Adatátvitel)
### TFTP (Trivial FTP)
- Egyszerűsített FTP
- Nincs bejelentkezés
- Csak letölt, feltölt
- Közeli helyekre fájlátvitel
- Hálózati Boot konfig fájlok átvitele (UDP 69)
## Távoli bejelentkezés
- Egy másik számítógépre bejelentkezés, és ott parancsok végrehajtása
  - Telnet (Nem titkosított, TCP 23)
  - SSH (Titkosított, TCP 22)
  - Távoli asztal (Windows, TCP 3389)
- SMB (Server message block)
  - Windows fájlelérési protokolja
  - TCP 139, 445
## Hálózat felügyeleti protokolok
### SNMP (Simple Network Management Protocol)
- UDP 161, 162
### Syslog
- UDP 512

# Alapvizsga fogalmak
## Elektronikai fogalmak (1 kérdés)
P=UI
U=RI
P = W
I = A
U = V
R = Ω

- Soros kapcsolás (Re=P1+P2)
- Párhuzamos kapcsolás (Re=(R1 * R2)/(R2 + R1))
(ellenállások)

1 kérdés lesz ezekből
## Operációs rendszer telepítése, frissítése (3 kérdés)
