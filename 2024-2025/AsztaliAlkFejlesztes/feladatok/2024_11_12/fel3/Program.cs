using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fel3
{
    class Program
    {
        /// <summary>
        /// 3. Írj programot, amely egy beolvasott egész szám függvényében írja, hogy melyik évszakhoz tartozik
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write("Adjon meg egy egész számot: ");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                case 2:
                case 12:
                    Console.WriteLine("A szám Télhez tartozik");
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("A szám Tavaszhoz tartozik");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("A szám Nyárhoz tartozik");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("A szám Őszhöz tartozik");
                    break;
                default:
                    Console.WriteLine("A szám nem tartozik sehová");
                    break;
            }
            Console.ReadKey();
        }
    }
}
