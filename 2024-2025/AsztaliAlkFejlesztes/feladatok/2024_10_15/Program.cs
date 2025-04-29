using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_10_15
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
                default:
                    Console.WriteLine("Nincs ilyen feladat.");
                    break;
            }
            Console.ReadKey();
        }
        ///<summary>
        ///Írj programot, amely egy beolvasott szám alapján kiírja szöveggel, hogy melyik hónapról van szó! A program figyeljen arra, ha a felhasználó érvénytelen sorszámú hónapot ad meg!
        ///</summary>
        static void Fel1()
        {
            Console.Write("Adja meg a hónap számát: ");
            byte honap = byte.Parse(Console.ReadLine());
            string[] honap_nevek = new string[] { "Január", "Február", "Március", "Április", "Május", "Június", "Július", "Augusztus", "Szeptember", "Október", "November", "December" };
            Console.WriteLine(honap_nevek[honap-1]);
        }
        /// <summary>
        /// Írj programot, amely bekéri egy hónap sorszámát, és kiírja, melyik évszakban van! A program figyeljen arra, ha a felhasználó érvénytelen sorszámú hónapot ad meg!
        /// </summary>
        static void Fel2()
        {
            Console.Write("Adja meg a hónap számát: ");
            byte honap = byte.Parse(Console.ReadLine());
            switch (honap)
            {
                case 1:
                case 2:
                case 12:
                    Console.WriteLine("Tél");
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("Tavasz");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Nyár");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("Ősz");
                    break;
                default:
                    Console.WriteLine("Ilyen nincs.");
                    break;
            }
        }
        /// <summary>
        /// Írj programot, amely egy legfeljebb kétmilliárd nagyságú bekért számról meghatározza azt, hogy hány jegyű! Jegyeinek számát hatig szöveggel írasd ki, e felett már csak annyit, hogy „a szám hat, vagy annál többjegyű”!
        /// </summary>
        static void Fel3()
        {
            Console.Write("Adja meg a számot: ");
            switch (Console.ReadLine().Length)
            {
                case 1:
                    Console.WriteLine("A szám egyjegyű");
                    break;
                case 2:
                    Console.WriteLine("A szám kétjegyű");
                    break;
                case 3:
                    Console.WriteLine("A szám háromjegyű");
                    break;
                case 4:
                    Console.WriteLine("A szám négyjegyű");
                    break;
                case 5:
                    Console.WriteLine("A szám ötjegyű");
                    break;
                default:
                    Console.WriteLine("A szám hat, vagy több jegyű");
                    break;
            }
        }
        /// <summary>
        /// Készíts programot, mely bekér egy hőmérséklet értéket, majd felajánlja, hogy Celsiusból Kelvinbe, vagy Kelvinből Celsiusba váltja át.
        /// </summary>
        static void Fel4()
        {
            Console.Write("1. Celsius -> Kelvin\n2. Kelvin -> Celsius\n> ");
            byte tipus = byte.Parse(Console.ReadLine());
            if (tipus == 1)
            {
                Console.Write("Hőmérséklet (C): ");
                float homerseklet = float.Parse(Console.ReadLine().Replace('.', ','));
                Console.WriteLine("{0}°C -> {1}°K", homerseklet, (homerseklet + 273.15));
            }
            else if (tipus == 2)
            {
                Console.Write("Hőmérséklet (K): ");
                float homerseklet = float.Parse(Console.ReadLine());
                Console.WriteLine("{0}°K -> {1}°C", homerseklet, (homerseklet - 273.15)); 
            }
            else
            {
                Console.WriteLine("Nem létező lehetőség");
            }
        }
        /// <summary>
        /// Írj programot, amely az osztály egy-egy diákjának jegye alapján megmondja, hogy sikeresen végezte-e el a tanfolyamot, vagy sem! A program küldjön üzenetet a felhasználónak, amennyiben a tanár valakinek tévedésből nem létező osztályzatot adott! Megjegyzés: A program[1, 5] zárt intervallumból fogadjon el érvényes osztályzatokat!
        /// </summary>
        static void Fel5()
        {
            Console.Write("Adjon meg osztályzatot: ");
            int osztalyzat = int.Parse(Console.ReadLine());
            switch (osztalyzat)
            {
                case 1:
                    Console.WriteLine("A diák megbukott");
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("A diák sikeresen elvégezte a tanfolyamot.");
                    break;
                default:
                    Console.WriteLine("Nem megfelelő adatot adott meg!");
                    break;
            }
        }
        /// <summary>
        /// Írj programot, amely beolvas egy érdemjegyet szám alakban, majd kiírja szöveggel, az osztályzat megfelelőjét! (pl.: jeles, jó...)
        /// </summary>
        static void Fel6()
        {
            string[] jegyek = new string[] {"Elégtelen", "Elégséges", "Közepes", "Jó", "Jeles"};
            Console.Write("Adjon meg osztályzatot: ");
            int osztalyzat = int.Parse(Console.ReadLine());
            if (osztalyzat <= 5 && osztalyzat >= 1)
            {
                Console.WriteLine("A diák {0} osztályzatot kapott.", jegyek[osztalyzat - 1]);
            }
            else
            {
                Console.WriteLine("Nem megfelelő jegyet adott");
            }
        }
    }
}
