using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fel2
{
    class Program
    {
        /// <summary>
        /// 2. Írj programot, amely megadja, hogy egy szám páros, vagy páratlan
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write("Adjon meg egy számot: ");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine("A szám páros");
            }
            else
            {
                Console.WriteLine("A szám páratlan");
            }
            Console.ReadKey();
        }
    }
}
