using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erettsegi_fel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a feladat sorszámát");
            switch (int.Parse(Console.ReadLine()))
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
            }
            Console.ReadKey();
        }
        static void Fel1()
        {
            bool V;
            int I, J;
            V = true;
            for (I = 1; I <= 8; I++)
            {
                if (I % 2 == 1) V = true;
                else V = false;
                for (J = 1; J <= 8; J++)
                {
                    if (V) Console.Write("A");
                    else Console.Write("B");
                    V = !V;
                }
                Console.WriteLine();
            }
        }
        static void Fel2()
        {
            string[] tmp1 = new string[] { };
            while (tmp.Length != 3) 
            {
                Console.WriteLine("Adja meg egy körlemez adatait x_k1, y_k1, r_k1 formátumban.");
                string[] tmp1 = Console.ReadLine().Split(',');
            }
            int[] k1 = new int[] {int.Parse(tmp1[0]), int.Parse(tmp1[1]), int.Parse(tmp1[2])};

            string[] tmp2 = new string[] { };
            while (tmp2.Length != 3)
            {
                Console.WriteLine("Adja meg egy körlemez adatait x_k1, y_k1, r_k1 formátumban.");
                string[] tmp2 = Console.ReadLine().Split(',');
            }
            int[] k2 = new int[] {int.Parse(tmp2[0]), int.Parse(tmp2[1]), int.Parse(tmp2[2]) };
            Console.WriteLine("Adja meg egy tetszőleges pontot x, y formátumban.");
            string[] tmp = Console.ReadLine().Split(',');
            while (tmp.Length != 2)
            {
                Console.WriteLine("Adja meg egy tetszőleges pontot x, y formátumban.");
                string[] tmp = Console.ReadLine().Split(',');
            }
            int[] coord = new int[] {int.Parse(tmp[0]), int.Parse(tmp[1])};
            Console.WriteLine("k1: {0},{1},{2}\nk2: {3}{4}{5}\ncoord: {6},{7}", k1[0], k1[1], k1[2], k2[0], k2[1], k2[2], coord[0], coord[1]);
        }
        static void Fel3()
        {

        }
    }
}
