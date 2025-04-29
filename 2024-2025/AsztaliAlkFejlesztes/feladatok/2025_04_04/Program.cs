using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _2025_04_04
{
    class Program
    {
        static void Main()
        {
            string[] magyarosok = File.ReadAllLines("magyarosok.txt");
            string[] matekosok = File.ReadAllLines("matekosok.txt");
            List<string> metszet = new List<string>();
            foreach (string nev in magyarosok)
            {
                if (matekosok.Contains(nev))
                {
                    metszet.Add(nev);
                }
            }
            Console.WriteLine($"Mindkettő szakra járnak:\n\t{string.Join("\n\t", metszet)}");
            Console.ReadKey();
        }
    }
}
