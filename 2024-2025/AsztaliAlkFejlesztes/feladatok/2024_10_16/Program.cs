using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_10_16
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
        /// Adott egy kétjegyű szám. Írj programot, amely meghatározza a számjegyek összegét, kiírja a számot fordítva és megadja a nagyobb számjegyet!
        /// </summary>
        static void Fel1()
        {
            Console.WriteLine("Adjon meg egy kétjegyű számot");
            byte num = byte.Parse(Console.ReadLine());
            if (num > 99 || num < 10)
            {
                Console.WriteLine("Az adott szám nem kétjegyű");
                return;
            }
            byte egyes = Convert.ToByte(num % 10);
            byte tizes = Convert.ToByte(num / 10 % 10);
            Console.WriteLine("\tÖsszeg: {0}\n\tFordítva: {1}\n\tLegnagyobb számjegy: {2}", egyes + tizes, egyes * 10 + tizes, Math.Max(egyes, tizes));
        }
        /// <summary>
        /// Adott egy háromjegyű szám. Írj programot, amely meghatározza a számjegyek összegét, kiírja a számot fordítva és megadja a legnagyobb számjegyet!
        /// </summary>
        static void Fel2()
        {
            Console.WriteLine("Adjon egy háromjegyű számot");
            int num = int.Parse(Console.ReadLine());
            if (num >= 1000 || num < 100)
            {
                Console.WriteLine("Az adott szám nem háromjegyű.");
                return;
            }
            byte egyes = Convert.ToByte(num%10);
            byte tizes = Convert.ToByte(num/10%10);
            byte szazas = Convert.ToByte(num/10/10);
            Console.WriteLine("\tÖsszeg: {0}\n\tFordítva: {1}\n\tLegnagyobb számjegy: {2}", egyes+tizes+szazas, egyes*100+tizes*10+szazas, Math.Max(egyes, Math.Max(tizes, szazas)));
        }
        /// <summary>
        /// Adott egy négyjegyű szám. Írj programot, amely meghatározza a számjegyek összegét, kiírja a számot fordítva és megadja a legkisebb számjegyet!
        /// </summary>
        static void Fel3()
        {
            Console.WriteLine("Adjon egy négyjegyű számot");
            int num = int.Parse(Console.ReadLine());
            if (num >= 10000 || num < 1000)
            {
                Console.WriteLine("Az adott szám nem négyjegyű.");
                return;
            }
            byte egyes = Convert.ToByte(num % 10);
            byte tizes = Convert.ToByte(num / 10 % 10);
            byte szazas = Convert.ToByte(num / 10 / 10 % 10);
            byte ezres = Convert.ToByte(num/10/10/10);
            Console.WriteLine("\tÖsszeg: {0}\n\tFordítva: {1}\n\tLegkisebb számjegy: {2}", egyes + tizes + szazas + ezres, egyes * 1000 + tizes * 100 + szazas *10 + ezres, Math.Min(Math.Min(egyes, ezres), Math.Min(tizes, szazas)));
        }
        /// <summary>
        /// Írasd ki azt a számot, amelyet egy egész számból úgy kapunk, hogy kihagyjuk a tízesek helyén állót!
        /// </summary>
        static void Fel4()
        {
            int input = int.Parse(Console.ReadLine());
            byte egyes = Convert.ToByte(input%10);
            byte szazasok = Convert.ToByte(input / 100 * 10);
            Console.WriteLine("Tizesek nélkül: {0}", szazasok+egyes);
        }
        /// <summary>
        /// Adott egy háromjegyű egész szám! Írj programot, amely megadja azt a legnagyobb számot, amely az adott szám számjegyeiből képezhető!
        /// </summary>
        static void Fel5()
        {
            Console.WriteLine("Adjon egy háromjegyű számot");
            int num = int.Parse(Console.ReadLine());
            if (num >= 1000 || num < 100)
            {
                Console.WriteLine("Az adott szám nem háromjegyű.");
                return;
            }
            byte egyes = Convert.ToByte(num % 10);
            byte tizes = Convert.ToByte(num / 10 % 10);
            byte szazas = Convert.ToByte(num / 10 / 10);
            List<byte> lehetoseg = new List<byte> { egyes, tizes, szazas};
            byte legnagyobb = Math.Max(lehetoseg[0], Math.Max(lehetoseg[1], lehetoseg[2]));
            lehetoseg.Remove(legnagyobb);
            byte legkisebb = Math.Min(lehetoseg[0], lehetoseg[1]);
            lehetoseg.Remove(legkisebb);
            Console.WriteLine("Legnagyobb lehetséges szám: {0}", legnagyobb*100+lehetoseg[0]*10+legkisebb);
        }
        /// <summary>
        /// Írjunk programot, amely felcseréli egy adott egész számban az egyesek és százasok helyén álló számjegyeket!
        /// </summary>
        static void Fel6()
        {
            Console.Write("Adja meg a számot:");
            int input = int.Parse(Console.ReadLine());
            byte egyes = Convert.ToByte(input % 10);
            byte tizesek = Convert.ToByte(input / 10 % 10);
            int rest = input / 100;
            Console.WriteLine("Felcserélve: {0}", rest*100+egyes*10+tizesek);
        }
        /// <summary>
        /// Alakítsuk át a másodpercekben megadott időt, órára, percre, másodpercre. A kiírás formátuma legyen óra:perc:másodperc!
        /// </summary>
        static void Fel7()
        {
            Console.Write("Idő másodpercben: ");
            int ido_mp = int.Parse(Console.ReadLine());
            byte mp = Convert.ToByte(ido_mp%60);
            byte perc = Convert.ToByte(ido_mp/60%60);
            int ora = Convert.ToByte(ido_mp/60/60);
            Console.WriteLine("Az idő {0}:{1}:{2}", ora, perc, mp);
        }
        /// <summary>
        /// A vonat adott óra:perc-kor indult el a célállomásra. Az út adott percig tartott. Írjunk programot, amely megadja a vonat érkezésének időpontját! Ez lehet a rákövetkező napon is!
        /// </summary>
        static void Fel8()
        {
            Console.WriteLine("Adja meg az indulási időt óra:perc formátumban");
            string[] tmp = Console.ReadLine().Split(':');
            if (tmp.Length < 2)
            {
                Console.WriteLine("Incorrect format");
                return;
            }
            int ora = int.Parse(tmp[0]);
            int perc = int.Parse(tmp[1]);
            Console.Write("Hány perc volt az adott út?: ");
            int ut_ido = int.Parse(Console.ReadLine());
            perc += ut_ido;
            while (perc > 60)
            {
                perc -= 60;
                ora += 1;
            }
            Console.WriteLine("Érkezési időpont: {0}:{1}", ora, perc);
        }
        /// <summary>
        /// Adott egy egész szám, N. Írj programot, amely megadja az első olyan N-nél nagyobb számot, amely osztható 7-tel!
        /// </summary>
        static void Fel9()
        {
            Console.WriteLine("Adjon meg egy egész számot: ");
            int N = int.Parse(Console.ReadLine());
            int N7 = N + 7;
            while (N <= N7)
            {
                N += 1;
                if (N % 7 == 0)
                {
                    Console.WriteLine("{0} az első szám, mely osztható 7-el, és nagyobb.", N);
                    return;
                }
            }
        }
        /// <summary>
        /// Adott egy egész szám, N. Írj programot, amely megadja az N-hez legközelebb eső olyan számot, amely osztható 7-tel!
        /// </summary>
        static void Fel10()
        {
            Console.WriteLine("Adjon meg egy egész számot: ");
            int N_up = int.Parse(Console.ReadLine());
            int N_dwn = N_up;
            int N7 = N_up + 7;
            while (N_up <= N7)
            {
                if (N_up % 7 == 0)
                {
                    Console.WriteLine("{0} az első szám, mely osztható 7-el.", N_up);
                    return;
                }
                N_up += 1;
                if (N_dwn % 7 == 0)
                {
                    Console.WriteLine("{0} az első szám, mely osztható 7-el.", N_dwn);
                    return;
                }
                N_dwn -= 1;
            }
        }
    }
}
