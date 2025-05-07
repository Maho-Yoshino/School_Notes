using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_10_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Adja meg a feladat számot: ");
            int fel_szam = int.Parse(Console.ReadLine());
            Console.Write("Adjon meg egy számot: ");
            int szam = int.Parse(Console.ReadLine());
            switch (fel_szam)
            {
                case 1:
                {
                    Fel1(szam);
                    break;
                }
                case 2:
                {
                    Fel2(szam);
                    break;
                }
            }
            Console.ReadKey();
        }
        static void Fel1(int a)
        {
            if (a > 0)
            {
                Console.WriteLine("A szám pozitív");
            }
            else if (a < 0)
            {
                Console.WriteLine("A szám negatív");
            }
            else
            {
                Console.WriteLine("A szám nulla");
            }
            if (a == 18)
            {
                Console.WriteLine("A szám 18.");
            }
        }
        static void Fel2(int a)
        {
            // egész Szám, páros vagy páratlan
            if (a%2==0)
            {
                Console.WriteLine("A szám páros");
            }
            else
            {
                Console.WriteLine("A szám páratlan");
            }
        }

    }
}
