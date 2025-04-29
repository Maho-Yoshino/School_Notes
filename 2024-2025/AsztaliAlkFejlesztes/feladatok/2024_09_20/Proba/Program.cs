using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a =");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("b =");
            float b = float.Parse(Console.ReadLine());
            float ker = (a+b)*2;
            float ter = a*b;
            Console.WriteLine("A megadott téglalap kerülete {0}, területe pedig {1}", ker, ter);
            Console.ReadKey();
        }
    }
}
