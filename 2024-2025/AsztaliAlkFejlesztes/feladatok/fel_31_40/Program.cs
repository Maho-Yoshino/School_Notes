using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fel_31_40
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Adja meg a feladat számát: ");
            int feladat = int.Parse(Console.ReadLine());
            switch (feladat)
            {
                case 1:
                    Fel1();
                    break;
                case 2:
                    Fel2();
                    break;
                case 3:
                    Fel3();
                    break;
                case 4:
                    Fel4();
                    break;
                case 5:
                    Fel5();
                    break;
                case 6:
                    Fel6();
                    break;
                case 7:
                    Fel7();
                    break;
                case 8:
                    Fel8();
                    break;
                case 9:
                    Fel9();
                    break;
                case 10:
                    Fel10();
                    break;
                default:
                    Console.WriteLine("Nincs ilyen feladat.");
                    break;
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Írj programot, amely egy beolvasott tanulmányi átlag alapján eldönti, hogy tanuló jeles, jó közepes vagy elégséges rendű átlaggal rendelkezik!
        /// </summary>
        static void Fel1()
        {
            Console.Write("Adjon meg egy tanulmányi átlagot: ");
            float atlag = float.Parse(Console.ReadLine().Replace('.', ','));
            string[] jegyek = new string[] { "Elégtelen", "Elégséges", "Közepes", "Jó", "Jeles" };
            if (atlag < 1.60)
            {
                Console.WriteLine("A diák {0} osztályzatot kapott.", jegyek[0]);
            }
            else
            {
                Console.WriteLine("A diák {0} osztályzatot kapott.", jegyek[Convert.ToByte(Math.Round(atlag - 1))]);
            }
        }
        /// <summary>
        /// Olvassuk be egy tanuló osztályzatait, a szakmai tantárgyakból (webszerkesztés, programozás, hálózat, IKT projekt). Határozzuk meg az átlagát a tanulónak és írjuk ki, szöveggel, hogy milyen rendű!
        /// </summary>
        static void Fel2()
        {
            Console.WriteLine("Adja meg az osztályzatokat a következő tantárgyakból: ");
            Console.Write("Webszerkesztés: ");
            int websz = int.Parse(Console.ReadLine());
            if (websz > 5 || websz < 1)
            {
                Console.WriteLine("Az adott átlag nem létezik");
                return;
            }
            Console.Write("Programozás: ");
            int prog = int.Parse(Console.ReadLine());
            if (prog > 5 || prog < 1)
            {
                Console.WriteLine("Az adott átlag nem létezik");
                return;
            }
            Console.Write("Hálózati: ");
            int halo = int.Parse(Console.ReadLine());
            if (halo > 5 || halo < 1)
            {
                Console.WriteLine("Az adott átlag nem létezik");
                return;
            }
            Console.Write("IKT Projekt: ");
            int ikt = int.Parse(Console.ReadLine());
            if (ikt > 5 || ikt < 1)
            {
                Console.WriteLine("Az adott átlag nem létezik");
                return;
            }
            string[] jegyek = new string[] { "Elégtelen", "Elégséges", "Közepes", "Jó", "Jeles" };
            if (websz == 1 || prog == 1 || ikt == 1 || halo == 1)
            {
                Console.WriteLine("A tanuló megbukott");
            }
            else
            {
                Console.WriteLine("A tanuló átlaga: {0}\n\n\tWebszerkesztés: {1}\n\tProgramozás: {2}\n\tHálózati: {3}\n\tIKT Projekt: {4}", (websz + prog + halo + ikt) / 4, jegyek[websz - 1], jegyek[prog - 1], jegyek[halo - 1], jegyek[ikt - 1]);
            }
        }
        /// <summary>
        /// Adott két különböző kétjegyű szám. Írassuk ki azt a kétjegyűt, amelynek számjegyeinek összege nagyobb!
        /// </summary>
        static void Fel3()
        {
            Console.Write("Adja meg az első kétjegyű egész számot: ");
            int num1 = int.Parse(Console.ReadLine());
            if (num1 > 99 || num1 < 10)
            {
                Console.WriteLine("Az adott szám nem kétjegyű.");
                return;
            }
            Console.Write("Adja meg a második kétjegyű egész számot: ");
            int num2 = int.Parse(Console.ReadLine());
            if (num2 > 99 || num2 < 10)
            {
                Console.WriteLine("Az adott szám nem kétjegyű.");
                return;
            }
            int num1_o = num1 % 10 + num1 / 10;
            int num2_o = num2 % 10 + num2 / 10;
            if (num1_o > num2_o)
            {
                Console.WriteLine("Az első szám számjegyeinek összege a nagyobb. ({0}>{1})", num1_o, num2_o);
            }
            else {
                Console.WriteLine("A második szám számjegyeinek összege a nagyobb. ({0}>{1})", num2_o, num1_o);
            }
        }
        /// <summary>
        /// Adott négy db egész szám, adjuk meg, a párosak összegét!
        /// </summary>
        static void Fel4()
        {
            List<int> paros = new List<int>();
            Console.Write("1. Szám:");
            int num1 = int.Parse(Console.ReadLine());
            if (num1 % 2 == 0)
            {
                paros.Add(num1);
            }
            Console.Write("2. Szám:");
            int num2 = int.Parse(Console.ReadLine());
            if (num2 % 2 == 0)
            {
                paros.Add(num2);
            }
            Console.Write("3. Szám:");
            int num3 = int.Parse(Console.ReadLine());
            if (num3 % 2 == 0)
            {
                paros.Add(num3);
            }
            Console.Write("4. Szám:");
            int num4 = int.Parse(Console.ReadLine());
            if (num4 % 2 == 0)
            {
                paros.Add(num4);
            }
            int osszeg = 0;
            foreach (int num in paros)
            {
                osszeg += num;
            }
            Console.WriteLine("Az adott számok közül a párosak összege {0}", osszeg);
        }
        /// <summary>
        /// Adott négy db egész szám, határozzuk meg a 3-mal osztható számok számtani közepét!
        /// </summary>
        static void Fel5()
        {
            List<int> oszt_3 = new List<int>();
            Console.Write("1. Szám:");
            int num1 = int.Parse(Console.ReadLine());
            if (num1 % 3 == 0)
            {
                oszt_3.Add(num1);
            }
            Console.Write("2. Szám:");
            int num2 = int.Parse(Console.ReadLine());
            if (num2 % 3 == 0)
            {
                oszt_3.Add(num2);
            }
            Console.Write("3. Szám:");
            int num3 = int.Parse(Console.ReadLine());
            if (num3 % 3 == 0)
            {
                oszt_3.Add(num3);
            }
            Console.Write("4. Szám:");
            int num4 = int.Parse(Console.ReadLine());
            if (num4 % 3 == 0)
            {
                oszt_3.Add(num4);
            }
            int atlag_felso = 0;
            int atlag_also = 0;
            foreach (int num in oszt_3)
            {
                atlag_felso += num;
                atlag_also += 1;
            }
            int atlag = atlag_felso / atlag_also;
            Console.WriteLine("A hárommal osztható számok számtani közepe (átlaga): {0}", atlag);
        }
        /// <summary>
        /// Adott 3 db egész szám, adjuk össze a kétjegyűeket!
        /// </summary>
        static void Fel6()
        {
            List<int> ketjegyu = new List<int>();
            Console.Write("1. Szám:");
            int num1 = int.Parse(Console.ReadLine());
            if (num1>=10&&num1<100)
            {
                ketjegyu.Add(num1);
            }
            Console.Write("1. Szám:");
            int num2 = int.Parse(Console.ReadLine());
            if (num2 >= 10 && num2 < 100)
            {
                ketjegyu.Add(num2);
            }
            Console.Write("1. Szám:");
            int num3 = int.Parse(Console.ReadLine());
            if (num3 >= 10 && num3 < 100)
            {
                ketjegyu.Add(num3);
            }
            Console.Write("1. Szám:");
            int num4 = int.Parse(Console.ReadLine());
            if (num4 >= 10 && num4 < 100)
            {
                ketjegyu.Add(num4);
            }
            int osszeg = 0;
            foreach (int num in ketjegyu)
            {
                osszeg += num;
            }
            Console.WriteLine("A kétjegyűek összege: {0}", osszeg);
        }
        /// <summary>
        /// Adott egy négyjegyű szám! Határozzuk meg a legnagyobb számjegyének és a másik 3 összegének hányadosát!
        /// </summary>
        static void Fel7()
        {
            Console.Write("Adjon meg egy négyjegyű számot: ");
            int num = int.Parse(Console.ReadLine());
            if (num > 1000|| num < 9999)
            {
                Console.WriteLine("Az adott szám nem négyjegyű");
                return;
            }
            List<int> szamjegyek = new List<int> { num/1000, num /100%10, num / 10 % 10, num % 10 };
            int legnagyobb = Math.Max(Math.Max(szamjegyek[0], szamjegyek[1]), Math.Max(szamjegyek[2], szamjegyek[3]));
            szamjegyek.Remove(legnagyobb); 
            Console.WriteLine("{0}, {1}, {2}, legnagyobb: {3}", szamjegyek[0], szamjegyek[1], szamjegyek[2], legnagyobb);
            double hanyados = Convert.ToDouble(legnagyobb) / szamjegyek.Sum();
            Console.WriteLine("A legnagyobb számjegy és a másik 3 összegének hányadosa: {0} ({1}/{2})", hanyados, legnagyobb, szamjegyek.Sum());
        }
        /// <summary>
        /// Írj programot, amely generál egy véletlen háromjegyű számot, majd képezd ennek a számnak a számjegyei segítségével a legnagyobb háromjegyűt!
        /// </summary>
        static void Fel8()
        {
            Random rnd = new Random();
            int num = rnd.Next(100, 1000);
            List<int> szamjegyek = new List<int> {num / 100 % 10, num / 10 % 10, num % 10 };
            int legnagyobb = Math.Max(Math.Max(szamjegyek[0], szamjegyek[1]), szamjegyek[2]);
            szamjegyek.Remove(legnagyobb);
            int legkisebb = Math.Min(szamjegyek[0], szamjegyek[1]);
            szamjegyek.Remove(legkisebb);
            int legn_haromjegy = legnagyobb*100+szamjegyek[0]*10+legkisebb;
            Console.WriteLine("Legnagyobb képezhető számjegy {0}-ből: {1}", num, legn_haromjegy);
        }
        /// <summary>
        /// Írj programot, amely beolvas egy hónap sorszámát és megadja ezek alapján, hogy az adott hónap hány napos! Tekintsük úgy, hogy csak[1..12] intervallumból adhatunk meg adatokat!
        /// </summary>
        static void Fel9()
        {
            Console.Write("Adja meg a hónap sorszámát: ");
            int ho = int.Parse(Console.ReadLine());
            if (ho > 12 || ho < 1)
            {
                Console.WriteLine("Az a hónap nem létezik");
                return;
            }
            switch (ho)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("A hónap 31 napos");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("A hónap 30 napos");
                    break;
                case 2:
                    Console.WriteLine("A hónap 28 vagy 29 napos");
                    break;
            }
        }
        /// <summary>
        /// Írj programot, amely beolvas egy évszámot és egy hónap sorszámát és megadja ezek alapján, hogy az adott hónap hány napos! Tekintsük úgy, hogy csak[1..12] intervallumból adhatunk meg adatokat! (Figyelj a szökőévre!)
        /// </summary>
        static void Fel10()
        {
            Console.WriteLine("Adja meg az évet és hónapot év.hó formátumban: ");
            string[] datum = Console.ReadLine().Split('.');
            if (datum.Length < 2)
            {
                Console.WriteLine("Nem megfelelő formátum.");
            }
            int ho = int.Parse(datum[1]);
            int ev = int.Parse(datum[0]);
            switch (ho)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("A hónap 31 napos");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("A hónap 30 napos");
                    break;
                case 2:
                    if (ev%4==0&&(ev%100==0&&ev%400==0))
                    {
                        Console.WriteLine("A hónap 29 napos");
                    }
                    else
                    {
                        Console.WriteLine("A hónap 28 napos");
                    }
                    break;
            }
        }
    }
}
