using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;
namespace kozepszintu_gyakorlo
{
    class Program
    {
        private static To[] TryConvertArray<To, From>(From[] arr)
        {
            try
            {
                return arr.Select(item => (To)Convert.ChangeType(item, typeof(To))).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Array.Empty<To>();
            }
        }
        private static string Input(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        private static bool NoFilter<G>(G item) => true;
        private static T TryInput<T>(string text, Func<T, bool> predicate = null)
        {
            predicate ??= NoFilter;
            while (true)
            {
                try
                {
                    T[] tmp = new T[] { TryConvert<T>(Input(text).Replace('.',',')) };
                    if (tmp.All(predicate))
                    {
                        return tmp[0];
                    }
                }
                catch
                {
                    Console.WriteLine("Hibás érték.");
                    continue;
                }
            }
        }
        private static T[] NewArray<T>(int N, string adattipus = null, Func<T, bool> predicate = null, string EOI = null)
        {
            adattipus ??= "elem";
            predicate ??= NoFilter;
            T[] arr = new T[N];
            for (int i = 0; i < N; i++)
            {
                string tmp_str = Input($"{i + 1}. {adattipus}: ");
                if (tmp_str == EOI)
                {
                    return arr;
                }
                T[] tmp = new T[1] { TryConvert<T>(tmp_str) };
                while (!tmp.All(predicate))
                {
                    tmp_str = Input($"{i + 1}. {adattipus}: ");
                    if (tmp_str == EOI)
                    {
                        return arr;
                    }
                    tmp = new T[1] { TryConvert<T>(tmp_str) };
                }
                arr[i] = tmp[0];
            }
            return arr;
        }
        private static T TryConvert<T>(object val)
        {
            return (T)Convert.ChangeType(val, typeof(T));
        }
        private static List<T> FillList<T>(string adattipus = null, Func<T, bool> predicate = null, object EOI = null, bool Include_EOI = false, int max_inputs = -1)
        {
            adattipus ??= "elem";
            predicate ??= NoFilter;
            int i = 0;
            string tmp_str;
            List<T> list = new List<T>();
            do
            {
                tmp_str = Input($"{i + 1}. {adattipus}: ");
                if (tmp_str == TryConvert<string>(EOI) && Include_EOI)
                {
                    list.Add(TryConvert<T>(tmp_str));
                    continue;
                }
                list.Add(TryConvert<T>(tmp_str));
                i++;
            }
            while (i != max_inputs && tmp_str != TryConvert<string>(EOI));
            return list;
        }
        private static void DebugPrint<T>(T[] list)
        {
            Console.WriteLine(string.Join(", ", list));
        }
        static void Main(string[] args)
        {
            typeof(Program).GetMethod($"Fel{TryInput<int>("Adja meg a feladat számát: ", x => x > 0 && x <= 43)}").Invoke(null, null);
            Console.WriteLine("Feladat vége.");
            Console.ReadKey();
        }
        /// <summary>
        /// Egy K körlemezt a következő adatokkal adunk meg: K(xk ,yk ,rk ), ahol xk és yk a körlemez középpontjának koordinátái, rk pedig a körlemez sugara.<br></br>
        /// Egy tetszőleges P(x, y) pont – ahol x és y a pont koordinátái – rajta van a K körlemezen, ha(xk -x)^2 +(yk -y)^2 <=rk^2 . Készítsen programot, amely billentyűzetről beolvassa két körlemez és egy pont adatait, majd az adatok alapján kiírja a képernyőre az alábbiak közül a megfelelő állítást:<br></br>
        /// - "A pont egyik körlemezen sincs rajta."<br></br>
        /// - "A pont csak az elsőként megadott körlemezen van rajta."<br></br>
        /// - "A pont csak a másodikként megadott körlemezen van rajta."<br></br>
        /// - "A pont a megadott körlemezek közös részén található."
        /// </summary>
        public static void Fel1()
        {
            double[] K1 = TryConvertArray<double, string>(Input("Adja meg a K1 körlemez koordinátáit (x, y, r): ").Split(",").ToArray());
            double[] K2 = TryConvertArray<double, string>(Input("Adja meg a K2 körlemez koordinátáit (x, y, r): ").Split(",").ToArray());
            double[] P = TryConvertArray<double, string>(Input("Adja meg a P pont koordinátáit (x, y): ").Split(",").ToArray());
            if (K1.Length < 3 || K2.Length < 3 || P.Length < 2)
            {
                Console.WriteLine("Nem megfelelő koordinátát adott meg.");
                return;
            }
            bool on_K1 = Math.Pow((K1[0] - P[0]), 2) + Math.Pow((K1[1] - P[1]), 2) <= Math.Pow(K1[2], 2);
            bool on_K2 = Math.Pow((K2[0] - P[0]), 2) + Math.Pow((K2[1] - P[1]), 2) <= Math.Pow(K2[2], 2);
            if (on_K1 && on_K2) {
                Console.WriteLine("A pont a megadott körlemezek közös részén található.");
            }
            else if (on_K1 && !on_K2)
            {
                Console.WriteLine("A pont csak az elsőként megadott körlemezen van rajta.");
            }
            else if (!on_K1 && on_K2)
            {
                Console.WriteLine("A pont csak a másodikként megadott körlemezen van rajta.");
            }
            else
            {
                Console.WriteLine("A pont egyik körlemezen sincs rajta.");
            }
        }
        /// <summary>
        /// Egy héten keresztül minden nap délben megmértük a hőmérsékletet az udvaron.<br></br>
        /// Készítsen programot, ami a mért értékeket beolvassa és tárolja a hom tömbben!<br></br>
        /// A hom tömbben tárolt értékek alapján határozza meg, és írassa ki a képernyőre heti hőingadozás mértékét! (A hőingadozás a mért legnagyobb és legkisebb érték különbsége.)
        /// </summary>
        public static void Fel2()
        {
            float[] hom = NewArray<float>(TryInput<int>("Adja meg, hány napon át mérte meg a hőmérsékletet: "), "mérés", x=>x>0);
            Console.WriteLine($"A mérések hőingadozás mértéke: {hom.Max() - hom.Min()}°");
        }
        /// <summary>
        /// Egy autó üzemanyag-fogyasztását olyan módon adjuk meg, hogy 100 kilométer távolságú út megtételéhez hány liter benzinre van szüksége.<br></br>
        /// Készítsen programot, amely billentyűzetről beolvassa egy autó fogyasztását, üzemanyagtartályának űrtartalmát, valamint a jármű által megteendő út hosszát, és a fenti adatok alapján megállapítja, hogy kell-e tankolnia az autónak az adott hosszúságú út során amennyiben tele tankkal indult útnak!<br></br>
        /// A program megállapításának megfelelően írja képernyőre az alábbi mondatok közül a megfelelőt!<br></br>
        /// - "Az út megtehető tankolás nélkül."<br></br>
        /// - "Az út során tankolni kell!"<br></br>
        /// Megjegyzés: Ha a fogyasztás F és az üzemanyagtartály térfogata V, akkor az autó egy tank benzinnel V*100/F kilométert tesz meg.
        /// </summary>
        public static void Fel3()
        {
            float F = TryInput<float>("Adja meg, mennyi a jelenlegi átlagfogyasztása a gépjárműnek: ");
            int V = TryInput<int>("Adja meg az üzemanyagtartály űrtartalmát: ");
            float trip_length = TryInput<float>("Adja meg, mekkora utat kíván megtenni: ");
            bool needs_refuel = (V * 100 / F) < trip_length;
            Console.WriteLine(needs_refuel ? "Az út során tankolni kell!" : "Az út megtehető tankolás nélkül.");
        }
        /// <summary>
        /// Egy sebességmérő műszer regisztrálja minden mellette elhaladó jármű sebességét km/h-ban.
        /// Az egyik irányba haladó járművek sebességét pozitív a másik irányba(szembe) haladókét negatív értékként tárolja a műszer.<br></br>
        /// Készítsen programot amely lehetővé teszi, hogy a műszer által regisztrált adatokat billentyűzeten keresztül számítógépre vigyük!<br></br>
        /// A sebességadatokat (max. 100 db) a seb nevű tömbben(nah, i'd list) tároljuk. Az adatok megadásának végét a 0 értékkel jelöljük. A program az adatsor végére tárolja el ezt a „0” értéket is. Az adatok eltárolása után a program határozza meg, hogy volt-e szabálysértő (szabálysértésen azt értjük, hogy valaki 100 km/h abszolút értékű sebességnél gyorsabban haladt), és ha igen, akkor az első szabálysértő hányadik rögzített elem volt a rögzített méréssorozatban és mennyivel lépte túl a sebességhatárt!<br></br>
        /// A meghatározott eredményt írja ki a képernyőre!
        /// </summary>
        public static void Fel4()
        {
            List<double> seb = FillList<double>(adattipus: "mérés", EOI: 0, Include_EOI:true, max_inputs:100);
            int max_seb = TryInput<int>("Adja meg a maximum sebességet: ", x => x > 0);
            if (seb.Any(x=> Math.Abs(x) > max_seb))
            {
                int index = seb.FindIndex(x=> Math.Abs(x) > max_seb);
                Console.WriteLine($"Volt Szabálysértő\nElsőnek a sorszáma:{index+1}\n{seb[index]-max_seb} kph-val ment gyorsabban");
            }
            else
            {
                Console.WriteLine("Nem volt szabálysértő.");
            }
        }
        /// <summary>
        /// Készítsen programot az alábbi feladat megoldására! Adott egy névsor egy 14 elemű vektorban.Kérje be a neveket, majd írassa ki a képernyőre ABC sorrendben, külön-külön sorba, úgy, hogy minden 5. név után várakozik egy gombnyomásra! Ezután tiszta képernyőn listázza a következő sorozatot. Minden név elé írjon egy listázási sorszámot!
        /// </summary>
        public static void Fel5()
        {
            List<string> nevsor = new List<string>(FillList<string>("név", max_inputs:TryInput<int>("Adja meg, hány elemű a névsor: ", x => x > 0)));
            nevsor.Sort();
            int i = 0;
            foreach (string nev in nevsor)
            {
                if (i%5==0)
                {
                    Console.WriteLine("Nyomjon meg egy gombot a folytatáshoz");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine($"{i+1}. {nev}");
                i++;
            }
        }
        /// <summary>
        /// Egy vektorban különböző cégek napi tőzsdei záró árfolyama szerepel. Készítsen programot az ön által ismert nyelven, mely megadja azt a céget, amelyik az adott időszak folyamán a legnagyobb nyereséget érte el! Tekintse legnagyobb nyereségnek azt, ahol az utolsó nap záróegyenlege és az első nap záróegyenlegének különbsége a legnagyobb.A feladat megoldásához alkalmazzon programozási tételt!
        /// </summary>
        public static void Fel6()
        {
            List<Tozsde> adat = new List<Tozsde>
            {
                new Tozsde { Ceg_nev = "Alfa Bt.", Nap1 = 1500, Nap2 = 1709, Nap3 = 1839 },
                new Tozsde { Ceg_nev = "Beta Kft.", Nap1 = 3000, Nap2 = 3291, Nap3 = 3255 },
                new Tozsde { Ceg_nev = "Gamma Rt.", Nap1 = 1000, Nap2 = 1279, Nap3 = 1285 },
                new Tozsde { Ceg_nev = "Delta Bt.", Nap1 = 14000, Nap2 = 14208, Nap3 = 14263 }
            };
            Tozsde most_profit = adat[0];
            for (int i = 1; i < adat.Count; i++)
            {
                Tozsde ceg = adat[i];
                if (ceg.Nap3-ceg.Nap1 > most_profit.Nap3-most_profit.Nap1)
                {
                    most_profit = ceg;
                }
            }
            Console.WriteLine($"A legnagyobb nyereséggel {most_profit.Ceg_nev} rendelkezik, nyereségük {most_profit.Nap3 - most_profit.Nap1}");
        }
        /// <summary>
        /// Készítsen programot, amely bekér billentyűzetről egy 3 jegyű pozitív egész számot és eldönti róla, hogy Armstrong-szám-e! A háromjegyű Armstrong-számokra igaz, hogy a számjegyei köbének összege megegyezik az eredeti számmal, pl. 371 = 3^3+7^3+1^3. (3^3=27, 7^3=343, 1^3=1) Az eredményt a képernyőre írassa ki!
        /// </summary>
        public static void Fel7()
        {
            string szam = TryInput<uint>("Adjon meg egy 3 jegyű pozitív egész számot: ", x => x >= 100 && x < 1000).ToString();
            Console.WriteLine(szam);
            DebugPrint(szam.ToArray());
            uint armstrong_num = Convert.ToUInt32(Math.Pow(Convert.ToUInt32(szam[0]), 3) + Math.Pow(Convert.ToUInt32(szam[1]), 3) + Math.Pow(Convert.ToUInt32(szam[2]), 3));
            if (armstrong_num == uint.Parse(szam))
            {
                Console.WriteLine("A szám Armstrong szám.");
            }
            else
            {
                Console.WriteLine($"A szám nem Armstrong szám. ({armstrong_num})");
            }
        }
        /// <summary>
        /// Adott egy maximum 100 karaktert tartalmazó szöveg. Állapítsa meg, hány szót tartalmaz, ha feltételezzük, hogy a szöveg elején, ill.végén található betűsorokat leszámítva minden szóközzel határolt karaktersorozat egy-egy szó! A kezdő szó előtt és a befejező szó mögött értelemszerűen nem feltétlenül van szóköz.
        /// </summary>
        public static void Fel8()
        {
            Console.WriteLine($"{Input("Adja meg a szöveget: ").Trim().Split(" ").Length} db szó található az adott szövegben.");
        }
        /// <summary>
        /// Készítsen programot, mely beolvas egy időpontot (óra, perc, másodperc) a billentyűzetről, majd beolvas egy másik, az előzőnél későbbi időpontot! (A két időpont egy napra esik.) A program határozza meg és írja képernyőre a két időpont között eltelt időt óra:perc:másodperc formátumban! (Az időpontokat 24 órás formátumban adjuk meg, tehát 12:59:59 után 13:00:00 következik.)
        /// </summary>
        public static void Fel9()
        {
            string[] idopont1 = TryInput<string>("Adjon meg egy időpontot: ", x => x.Split(':').Length == 3).Split(':');
            string[] idopont2 = TryInput<string>("Adjon meg egy másik, későbbi időpontot: ", x => x.Split(':').Length == 3).Split(':');
            Idopont ido1 = new Idopont {
                ora = byte.Parse(idopont1[0]),
                perc = byte.Parse(idopont1[1]),
                mp = byte.Parse(idopont1[2])
            };
            Idopont ido2 = new Idopont
            {
                ora = byte.Parse(idopont2[0]),
                perc = byte.Parse(idopont2[1]),
                mp = byte.Parse(idopont2[2])
            };
            if (
                ido1.ora > ido2.ora || 
                (ido1.ora == ido2.ora && ido1.perc > ido2.perc) || 
                (ido1.ora == ido2.ora && ido1.perc == ido2.perc && ido1.mp > ido2.mp))
            {
                Idopont tmp = ido1;
                ido1 = ido2;
                ido2 = tmp;
            }
            sbyte ora = Convert.ToSByte(ido2.ora - ido1.ora);
            sbyte perc = Convert.ToSByte(ido2.perc - ido1.perc);
            sbyte mp = Convert.ToSByte(ido2.mp - ido1.mp);
            while (!(ora >= 0 && perc >= 0 && perc < 60 && mp >= 0 && mp < 60))
            {
                if (!(ora >= 0))
                {
                    throw new Exception("wtf");
                }
                if (perc > 60)
                {
                    perc -= 60;
                    ora += 1;
                }
                else if (perc < 0)
                {
                    perc += 60;
                    ora -= 1;
                }
                if (mp > 60)
                {
                    mp -= 60;
                    perc += 1;
                }
                else if (mp < 0)
                {
                    mp += 60;
                    perc -= 1;
                }
            }
            Console.WriteLine($"A két időpont között eltelt idő: {ora}:{(perc).ToString("D2")}:{(ido2.mp - ido1.mp).ToString("D2")}");
        }
        /// <summary>
        /// Egy osztályba csupa különböző nevű ember jár. Az osztály létszáma 32 fő. Készítsen programot, amely beolvassa és tárolja egy tömbben a matematika szakkörre jelentkezők nevét! Egy másik tömbbe hasonló módon a magyar szakkörre jelentkezők neve kerüljön! A program határozza meg és gyűjtse ki egy harmadik tömbbe azok nevét, akik mindkét szakkörre jelentkeztek, majd a tömbbe kigyűjtött névsort jelenítse meg a képernyőn!
        /// </summary>
        public static void Fel10()
        {
            string[] matekosok = new string[TryInput<int>("Hányan járnak az osztályba? ")];
            string[] magyarosok = new string[matekosok.Length];
            List<string> metszet = new List<string>();
            for (int i = 0; i < matekosok.Length; i++)
            {
                matekosok[i] = Input($"{i+1}. matekos diák neve: ");
            }
            for (int i = 0; i < magyarosok.Length; i++)
            {
                magyarosok[i] = Input($"{i+1}. magyaros diák neve: ");
            }
            foreach (string nev in magyarosok.Union(matekosok))
            {
                if (magyarosok.Contains(nev) && matekosok.Contains(nev))
                {
                    metszet.Add(nev);
                }
            }
            Console.WriteLine($"Mindkettő szakkörre jár{(metszet.Count > 1 ? "nak":"")}: {string.Join(", ", metszet)}");
        }
        private static async System.Threading.Tasks.Task<double> GetHUF_EUR_price()
        {
            string url = "https://www.portfolio.hu/arfolyam/EURHUF/EUR-HUF%20Spot";
            HttpClient client = new HttpClient();
            string html = await client.GetStringAsync(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return double.Parse(doc.DocumentNode.SelectSingleNode("//*[@id=\"stat-open\"]").InnerText.Replace('.', ','));
        }
        /// <summary>
        /// Készítsen programot, amely billentyűzetről beolvassa az € (euro) aktuális árfolyamát, vagyis hogy egy € (euro) hány forintot(huf) ér, majd szintén billentyűzetről beolvassa az átváltandó € (euro) összeget, és kiírja, hogy az hány forintot(huf) ér!
        /// </summary>
        public static void Fel11()
        {
            double huf_ar = GetHUF_EUR_price().Result;
            double eur = TryInput<double>("Adja meg, mennyi euro-t szeretne átváltani: ");
            Console.WriteLine($"{eur} euro = {Math.Round(eur*huf_ar)} Ft (1 eur = {huf_ar} Ft)");
        }
        /// <summary>
        /// Egy autó 100 km megtételéhez 8 liter benzint fogyaszt el. Hétfőn reggel teli tankkal adjuk át az autót a sofőrnek.A sofőr minden este teletankolja az autót és feljegyzi, hogy hány litert kellett az üzemanyagtartályba töltenie, hogy megteljen. Az autót vasárnap este tankolás után adja le a sofőr. (Feltehetjük, hogy az üzemanyag napközben egyszer sem fogyott ki.) Készítsen programot, amely billentyűzetről beolvassa és egy tömbben tárolja a naponként tankolt üzemanyag mennyiségeket! A beolvasás után a program határozza meg a héten elfogyasztott üzemanyag mennyiségét, majd írja képernyőre, hogy ezzel az üzemanyagmennyiséggel hány km-t tehetett meg a jármű!
        /// </summary>
        public static void Fel12()
        {
            double[] elfogyott = new double[TryInput<int>("Hány napra adta át az autót? ")];
            double l_100km = 8;
            for (int i = 0; i < elfogyott.Length; i++)
            {
                elfogyott[i] = TryInput<double>($"{i + 1}. nap:", x => x > 0.0);
            }
            Console.WriteLine($"A héten elfogyasztott üzemanyag: {elfogyott.Sum()} l\n" +
                              $"Ennyi üzemanyaggal megtehetett {} km-t");
        }
        public static void Fel13()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel14()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel15()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel16()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel17()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel18()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel19()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel20()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel21()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel22()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel23()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel24()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel25()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel26()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel27()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel28()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel29()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel30()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel31()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel32()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel33()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel34()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel35()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel36()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel37()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel38()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel39()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel40()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel41()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel42()
        {
            throw new NotImplementedException("Nincs kész");
        }
        public static void Fel43()
        {
            throw new NotImplementedException("Nincs kész");
        }

    }
    class Tozsde
    {
        public string Ceg_nev { get; set; }
        public int Nap1 { get; set; }
        public int Nap2 { get; set; }
        public int Nap3 { get; set; }
    }
    class Idopont
    {
        public byte ora { get; set; }
        public byte perc { get; set; }
        public byte mp { get; set; }
    }
}
