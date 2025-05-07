using System;
using System.Collections.Generic;

namespace osszegzes_megszamlalas_tetele
{
    class Program
    {
        public static string Input(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.Write("Adja meg a feladat típusát (1 = Összegzés, 2 = Megszámlálás): ");
            bool success = int.TryParse(Console.ReadLine(), out int tipus);
            if (!success || (tipus < 1 || tipus > 2))
            {
                Console.WriteLine("Nem megfelelő számot adott meg");
                Console.ReadKey();
                return;
            }
            Console.Write("Adja meg a feladat számát: ");
            success = int.TryParse(Console.ReadLine(), out int feladat);
            if (!success)
            {
                Console.WriteLine("Nem megfelelő számot adott meg");
                Console.ReadKey();
                return;
            }
            if (tipus == 1 && !(feladat < 0||feladat > 5))
            {
                typeof(Osszegzes).GetMethod($"Fel{feladat}").Invoke(null, null);
            }
            else if (tipus == 2 && !(feladat < 0 || feladat > 5))
            {
                typeof(Megszamlalas).GetMethod($"Fel{feladat}").Invoke(null, null);
            }
            else
            {
                Console.WriteLine("Nem megfelelően lett megadva a feladatszám.");
            }
            Console.ReadKey();
        }
    }
    class Osszegzes : Program
    {
        /// <summary>
        /// Adott egy ismeretlen elemszámú, egész típusú tömb. Töltsük Fel véletlen számokkal, majd határozzuk meg a számok összegét.A számok az [50,80] zárt intervallumból vehetik Fel az értékeiket!
        /// </summary>
        public static void Fel1()
        {
            int N = int.Parse(Input("Adja meg, hány elemet szeretne összeadni: "));
            int[] elemek = new int[N];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                elemek[i] = rnd.Next(50, 81);
                Console.WriteLine($"{i}-dik elem: {elemek[i]}");
            }
            int osszeg = 0;
            foreach (int num in elemek)
            {
                osszeg += num;
            }
            Console.WriteLine($"A számok összege {osszeg}");
        }
        /// <summary>
        /// Egy héten keresztül minden nap 14:00 órakor megmértük a levegő hőmérsékletét! A mért adatokat rögzítettük egy hom tömbben.Határozzuk meg, hány fok volt átlagosan az adott héten!
        /// </summary>
        public static void Fel2()
        {
            int napok = int.Parse(Input("Adja meg, hány napon át futott a mérés: "));
            double[] hom = new double[napok];
            for (int i = 0; i < napok; i++)
            {
                hom[i] = double.Parse(Input($"Hány fok volt a {i + 1}. napon? :").Replace('.', ','));
            }
            double ossz = 0;
            foreach (double fok in hom)
            {
                ossz += fok;
            }
            Console.WriteLine($"A mérés alatt {Math.Round(ossz/hom.Length, 2)} fok volt az átlag");
        }
        /// <summary>
        /// Az M0-s autópályán 20 autó sebességét mérték meg a közlekedési rendőrök. Az adatokat rögzítették.Határozd meg, hogy átlagosan hány km/h-val közlekedtek az autók a pálya ezen szakaszán?
        /// </summary>
        public static void Fel3()
        {
            int meres_count = int.Parse(Input("Adja meg, hány autó sebességét mérték meg: "));
            float[] sebessegek = new float[meres_count];
            for (int i = 0; i < meres_count; i++)
            {
                sebessegek[i] = float.Parse(Input($"Adja meg, a {i+1}. autó sebességét: ").Replace('.', ','));
            }
            float osszeg = 0;
            foreach (float sebesseg in sebessegek)
            {
                osszeg += sebesseg;
            }
            Console.WriteLine($"Az autópályán mért átlag sebesség {Math.Round(osszeg / sebessegek.Length, 2)} km/h");
        }
        /// <summary>
        /// Adott egy ismeretlen elemszámú, egész számokat tartalmazó sorozat! Határozd meg, külön-külön a pozitívak és a negatívok átlagát!
        /// </summary>
        public static void Fel4()
        {
            int N = int.Parse(Input("Adja meg, hány elemű legyen a sorozat: "));
            int[] sorozat = new int[N];
            for (int i = 0; i < N; i++)
            {
                sorozat[i] = int.Parse(Input($"{i+1}. elem: "));
            }
            int poz_sum = 0, poz_l = 0, neg_sum = 0, neg_l = 0;
            foreach (int num in sorozat)
            {
                if (num<0)
                {
                    neg_l += 1;
                    neg_sum += num;
                }
                else
                {
                    poz_l += 1;
                    poz_sum += num;
                }
            }
            double poz_atlag = Convert.ToDouble(poz_sum) / poz_l;
            double neg_atlag = Convert.ToDouble(neg_sum) / neg_l;
            Console.WriteLine($"Pozitív átlag: {poz_atlag}\nNegatív átlag: {neg_atlag}");
        }
        /// <summary>
        /// Egy tömb a 10.e osztály programozás dolgozatának osztályzatait tartalmazza! Határozzuk meg mennyi lett az osztályátlag! Adjuk meg, hány tanulónak sikerült a dolgozat legalább 4-re.
        /// </summary>
        public static void Fel5()
        {
            int N = int.Parse(Input("Adja meg, hány tanuló van az osztályban: "));
            int[] sorozat = new int[N];
            for (int i = 0; i < N; i++)
            {
                sorozat[i] = int.Parse(Input($"{i+1}. tanuló osztályzata: "));
            }
            int leg_negyes = 0;
            int osztaly_sum = 0;
            int o_sum_num = 0;
            foreach (int osztalyzat in sorozat)
            {
                if (osztalyzat >= 4)
                {
                    leg_negyes += 1;
                }
                osztaly_sum += osztalyzat;
                o_sum_num += 1;
            }
            Console.WriteLine($"Az osztály átlaga {Math.Round(Convert.ToDouble(osztaly_sum) / o_sum_num, 2)}\nAz osztályból {leg_negyes} tanulónak sikerült legalább 4-esre");
        }
    }
    class Megszamlalas : Program
    {
        /// <summary>
        /// Határozzuk meg egy szám osztóinak számát!
        /// A számot kérjük be billentyűzetről!
        /// </summary>
        public static void Fel1()
        {
            int num = int.Parse(Input("Adjon meg egy számot: "));
            List<int> osztok = new List<int> { };
            for (int i = num; i >= 1; i--)
            {
                if (num%i==0)
                {
                    osztok.Add(i);
                }
            }
            Console.WriteLine($"{num} osztói: ");
            foreach (int oszto in osztok)
            {
                Console.Write($"{oszto} ");
            }
        }
        /// <summary>
        /// Egy héten keresztül minden nap 14:00 órakor megmértük a levegő hőmérsékletét! A mért adatokat rögzítettük egy tömbben.Határozzuk meg, hány napon volt melegebb 15°C foknál. Fogalmazd meg a feladatot általánosan is!
        /// </summary>
        public static void Fel2()
        {
            int N = int.Parse(Input("Adja meg a mérések mennyiségét: "));
            double[] homersekletek = new double[N];
            int melegebb_15fok = 0;
            for (int i = 0; i<N; i++)
            {
                homersekletek[i] = double.Parse(Input($"{i+1}. mérés: "));
                if (homersekletek[i] > 15)
                {
                    melegebb_15fok += 1;
                }
            }
            Console.WriteLine($"{melegebb_15fok} napon volt melegebb 15 foknál.");
        }
        /// <summary>
        /// Az M0-s autópályán 20 autó sebességét mérték meg a közlekedési rendőrök. Az adatokat rögzítették.Határozd meg, hogy hány szabálysértő volt, ha tudjuk, hogy az autópálya ezen szakaszán, a maximálisan megengedett sebesség 100 km/h. Oldd meg a feladatot általánosan is! (Kérd be, a maximálisan megengedett sebességet és az autók számát is!)
        /// </summary>
        public static void Fel3()
        {
            int N = int.Parse(Input("Adja meg a mérések mennyiségét: "));
            int[] meresek = new int[N];
            for (int i = 0; i<N; i++)
            {
                meresek[i] = int.Parse(Input($"{i + 1}. mérés: "));
            }
            int max_speed = int.Parse(Input("Adja meg az útszakaszon lévő maximális sebességet: "));
            int overspeeding_counter = 0;
            foreach (int meres in meresek)
            {
                if (meres > max_speed)
                {
                    overspeeding_counter += 1;
                }
            }
            Console.WriteLine($"{overspeeding_counter} szabálysértő volt, aki {max_speed} km/h felett ment.");
        }
        /// <summary>
        /// Adott egy ismeretlen elemszámú, egész számokat tartalmazó sorozat! Határozd meg, hogy hány pozitív és hány negatív szám van közötte!
        /// </summary>
        public static void Fel4()
        {
            List<int> numbers = new List<int> { };
            string num = Input("Adja meg az első elemet: ");
            numbers.Add(int.Parse(num));
            while (num.Length != 0)
            {
                num = Input("Adja meg a következő elemet: ");
                if (num.Length != 0)
                {
                    numbers.Add(int.Parse(num));
                }
            }
            int positive_numbers = 0;
            int negative_numbers = 0;
            foreach (int number in numbers)
            {
                if (number < 0)
                {
                    negative_numbers += 1;
                }
                else
                {
                    positive_numbers += 1;
                }
            }
            Console.WriteLine($"Az adott elemek közül {positive_numbers} db pozitív szám, és {negative_numbers} db negatív szám");
        }
        /// <summary>
        /// Adott egy keresztneveket tartalmazó lista. Rögzítsd az adatokat, majd add meg, hogy hányszor szerepel benne egy általad bekért név!
        /// </summary>
        public static void Fel5()
        {
            List<string> ker_nevek = new List<string> { };
            string nev_input = Input("Adja meg az első nevet: ");
            ker_nevek.Add(nev_input);
            while (nev_input.Length != 0)
            {
                nev_input = Input("Adja meg a következő nevet: ");
                ker_nevek.Add(nev_input);
            }
            string bekert_nev = Input("Adjon meg egy keresendő nevet: ");
            if (ker_nevek.Contains(bekert_nev))
            {
                int nev_count = 0;
                foreach (string nev in ker_nevek)
                {
                    if (nev == bekert_nev)
                    {
                        nev_count += 1;
                    }
                }
                Console.WriteLine($"A név \"{bekert_nev}\" az {nev_count}x szerepel az adott nevek között");
            }
            else
            {
                Console.WriteLine("Az adott név nem szerepel a listán.");
            }
        }
    }
}
