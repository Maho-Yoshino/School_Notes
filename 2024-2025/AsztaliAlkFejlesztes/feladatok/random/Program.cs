using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Adja meg a feladat számot: ");
            bool success = int.TryParse(Console.ReadLine(), out int feladat);
            if (!success)
            {
                Console.WriteLine("Az adott adat nem átalakítható számmá.");
                Console.ReadKey();
                return;
            }
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
            }
            Console.ReadKey();
        }
        static void Fel1()
        {
            Random rnd = new Random();
            Console.WriteLine("Az előállított véletlenszám: {0}", rnd.Next());
            Console.WriteLine("Az előállított véletlenszám: {0}", rnd.Next(101));
            Console.WriteLine("Az előállított véletlenszám: {0}", rnd.Next(10, 20));
        }
        static void Fel2()
        {
            Console.Write("Adjon meg egy számot: ");
            Console.WriteLine("Az előállított véletlenszám: {0}", new Random().Next(int.Parse(Console.ReadLine())));
        }
        static void Fel3()
        {
            Console.Write("Adja meg a felső korlátot: ");
            int limit1 = int.Parse(Console.ReadLine());
            Console.Write("Adja meg az alsó korlátot: ");
            int limit2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Az előállított véletlenszám: {0}", new Random().Next(Math.Min(limit1, limit2), Math.Max(limit1, limit2)+1));
        }
        static void Fel4()
        {
            Random rnd = new Random();
            for (int i = 0; i<20; i++)
            {
                Console.WriteLine("A(z) {0}. eloallitott szam: {1}", i + 1, rnd.Next());
            }
        }
        static void Fel5()
        {
            int[] num_array = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                num_array[i] = rnd.Next();
            }
            foreach (int num in num_array)
            {
                Console.WriteLine("Az előállított véletlenszám: {0}", num);
            }
        }
    }
}
