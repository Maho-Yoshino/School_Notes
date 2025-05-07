using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fel4
{
    class Program
    {
        /// <summary>
        /// 4. Írj programot, amely egy beolvasott intervalumhatáron belül kiírja az összes olyan számot, amely hárommal osztva 2-t ad maradékul
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write("Adjon meg egy intervalumot (x, y formátumban, [x, y[ intervalumként fog működni): ");
            string[] intervalum = Console.ReadLine().Split(',');
            if (intervalum.Length == 2 && int.TryParse(intervalum[0].Trim(), out int inter1) && int.TryParse(intervalum[1].Trim(), out int inter2))
            {
                for (int i = Math.Min(inter1, inter2); i < Math.Max(inter1, inter2); i++)
                {
                    if (i % 3 == 2)
                    {
                        Console.Write("{0} ", i);
                    }
                }
            }
            else
            {
                Console.WriteLine("A megadott adat nem megfelelő formátumú");
            }
            Console.ReadKey();
        }
    }
}
