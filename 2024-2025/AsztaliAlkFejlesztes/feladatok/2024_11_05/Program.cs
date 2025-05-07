using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241105
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
                case 4:
                    Fel4();
                    break;
                case 5:
                    Fel5();
                    break;
                case 6:
                    Fel6();
                    break;
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Írasd ki az első 10 természetes számot
        /// </summary>
        static void Fel1()
        {
            for (int i = 1; i<= 10; i++)
            {
                if (i != 10) Console.Write("{0}, ", i);
                else Console.Write("{0}", i);
            }
        }
        /// <summary>
        /// írj programot, mely bekéri hány számot írasson ki 0-tól
        /// </summary>
        static void Fel2()
        {
            Console.WriteLine("Adja meg hány számot írjak ki 0-tól.");
            uint num = uint.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.Write("{0} ", i);
            }
        }
        /// <summary>
        /// írasd ki 1 és 100 között a páros számokat
        /// </summary>
        static void Fel3()
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % 2 == 0) Console.Write("{0} ", i);
            }
        }
        /// <summary>
        /// írasd ki a kis magánhangzókat
        /// </summary>
        static void Fel4()
        {
            char[] mgh = new char[] {'a', 'á', 'e', 'é', 'i', 'í', 'o', 'ó', 'ö', 'ő', 'u', 'ú', 'ü', 'ű'};
            foreach (char betu in mgh)
            {
                Console.Write("{0} ", betu);
            }
        }
        /// <summary>
        /// írasd ki azokat a számokat tetszőleges intervalumban, melyek 3-al osztva 2-t adnak maradékul
        /// </summary>
        static void Fel5()
        {
            Console.Write("Adja meg az intervalum elejét és végét (pl. \"1, 2\" ( avagy [1; 2[ )): ");
            string[] num = Console.ReadLine().Split(',');
            int x = int.Parse(num[0].Trim());
            int y = int.Parse(num[1].Trim());
            for (int i = x; i<y; i++)
            {
                if (i % 3 == 2) Console.Write("{0} ", i);
            }
        }
        /// <summary>
        /// írj ki tetszőleges intervalumban 1-100 között a kétjegyű prímszámokat
        /// </summary>
        static bool prime(int num)
        {
            throw new NotImplementedException();
        }
        static void Fel6()
        {
            Console.Write("Adja meg az intervalum elejét és végét, legyen 1-100 között (pl. \"1, 2\" ( avagy [1; 2[ )): ");
            string[] num = Console.ReadLine().Split(',');
            int[] num_arr = new int[] {int.Parse(num[0].Trim()), int.Parse(num[1].Trim()) };
            int x = num_arr.Min();
            int y = num_arr.Max();
            if (x>=100||y<1)
            {
                Console.WriteLine("Az adott intervalum nem 1-100 között van.");
                return;
            }
            for (int i = x; i<y; i++)
            {
                
            }
        }
    }
}
