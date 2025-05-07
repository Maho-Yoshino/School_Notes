using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _2025_04_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fajl1 = File.ReadAllLines("A_halmaz.txt");
            string[] fajl2 = File.ReadAllLines("B_halmaz.txt");
            int[] A_halmaz = new int[fajl1.Length];
            int[] B_halmaz = new int[fajl2.Length];
            for (int i = 0; i < fajl1.Length; i++)
            {
                A_halmaz[i] = int.Parse(fajl1[i]);
            }
            for (int i = 0; i < fajl2.Length; i++)
            {
                B_halmaz[i] = int.Parse(fajl2[i]);
            }
            // Metszet
            List<int> metszet = new List<int>();
            foreach (int num in A_halmaz)
            {
                if (B_halmaz.Contains(num))
                {
                    metszet.Add(num);
                }
            }
            Console.WriteLine(string.Join(", ", metszet));
        }
    }
}
