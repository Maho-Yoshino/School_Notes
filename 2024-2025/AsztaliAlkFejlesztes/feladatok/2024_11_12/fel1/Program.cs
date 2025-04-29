using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fel1
{
    class Program
    {
        /// <summary>
        /// 1. Írj programot, amely kiszámolja a kör kerületét, területét
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write("Adja meg a kör sugarát: ");
            double r = double.Parse(Console.ReadLine());
            double K = 2*r*Math.PI;
            double T = Math.Pow(r, 2)*Math.PI;
            Console.WriteLine("Az adott kör kerülete {0}, területe {1}", K, T);
            Console.ReadKey();
        }
    }
}
