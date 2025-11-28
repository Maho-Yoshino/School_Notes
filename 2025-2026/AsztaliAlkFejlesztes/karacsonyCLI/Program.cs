using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace karacsonyCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NapiMunka[] munka = File.ReadAllLines("diszek.txt").Select(sor => new NapiMunka(sor)).ToArray();
            // 4. feladat
            Console.WriteLine($"4. feladat: Összesen {NapiMunka.KeszultDb} dísz készült.\n");
            // 5. feladat
            Console.WriteLine($"5. feladat: {(munka.Any(x => x.FenyofaKesz == 0 && x.HarangKesz == 0 && x.AngyalkaKesz == 0) ? "Volt" : "Nem volt")} olyan nap, amikor egyetlen dísz sem készült.\n");
            // 6. feladat
            Console.WriteLine("6. feladat:");
            byte nap;
            do
            {
                Console.Write("Adja meg a keresett napot [1 ... 40]: ");
                nap = byte.Parse(Console.ReadLine());
            }
            while (nap < 1 || nap > 40);
            Dictionary<string, int> raktar = new Dictionary<string, int>()
            {
                { "Harang", 0 },
                { "Angyalka", 0 },
                { "Fenyőfa", 0 }
            };
            for (int i = 0; i < nap; i++)
            {
                NapiMunka napMunka = munka.Where(x => x.Nap == i + 1).First();
                raktar["Harang"] += napMunka.HarangKesz - Math.Abs(napMunka.HarangEladott);
                raktar["Angyalka"] += napMunka.AngyalkaKesz - Math.Abs(napMunka.AngyalkaEladott);
                raktar["Fenyőfa"] += napMunka.FenyofaKesz - Math.Abs(napMunka.FenyofaEladott);
            }
            Console.WriteLine($"\tA(z) {nap}. nap végén {raktar["Harang"]} harang, {raktar["Angyalka"]} angyalka és {raktar["Fenyőfa"]} fenyőfa maradt készleten.\n");
            // 7. feladat
            int maxVal = Math.Abs(Math.Min(Math.Min(munka.Sum(x => x.HarangEladott), munka.Sum(x => x.AngyalkaEladott)), munka.Sum(x => x.FenyofaEladott)));
            List<string> highestTypes = new List<string>();
            if (munka.Sum(x => Math.Abs(x.HarangEladott)) == maxVal) highestTypes.Add("Harang");
            if (munka.Sum(x => Math.Abs(x.AngyalkaEladott)) == maxVal) highestTypes.Add("Angyalka");
            if (munka.Sum(x => Math.Abs(x.FenyofaEladott)) == maxVal) highestTypes.Add("Fenyőfa");
            Console.WriteLine($"7. feladat: Legtöbbet eladott dísz: {maxVal} darab\n\t{string.Join("\n\t", highestTypes)}");
            Console.ReadKey();
        }
    }
}
