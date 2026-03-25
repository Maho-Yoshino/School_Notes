using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace cliapp
{
    class Barlang
    {
        private int melyseg = 0;
        private int hossz = 0;

        public int Azon { get; private set; }
        public string Nev { get; private set; }

        public int Hossz
        {
            get
            {
                return hossz;
            }
            set
            {
                if (value >= hossz)
                {
                    hossz = value;
                }
            }
        }

        public int Melyseg
        {
            get
            {
                return melyseg;
            }
            set
            {
                if (value >= melyseg)
                {
                    melyseg = value;
                }
            }
        }

        public string Telepules { get; private set; }
        public string Vedettseg { get; private set; }

        public Barlang(string sor)
        {
            string[] m = sor.Split(';');
            Azon = int.Parse(m[0]);
            Nev = m[1];
            Hossz = int.Parse(m[2]);
            Melyseg = int.Parse(m[3]);
            Telepules = m[4];
            Vedettseg = m[5];
        }

        public override string ToString()
        {
            return $"\tAzon: {Azon}\n\tNév: {Nev}\n\tHossz: {Hossz} m\n\tMélység: {Melyseg} m\n\tTelepülés: {Telepules}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Barlang[] barlangok = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "barlangok.txt")).Skip(1).ToList().ConvertAll(x => new Barlang(x)).ToArray();
            // 4. Feladat
            Console.WriteLine($"4. feladat: Barlangok száma: {barlangok.Length}");
            // 5. Feladat
            Console.WriteLine($"5. feladat: Az átlagos mélység: {Math.Round(barlangok.Where(x => x.Telepules.ToLower().StartsWith("miskolc")).Average(x => x.Melyseg), 3)} m");
            // 6. Feladat
            Console.Write($"6. feladat: Kérem a védettségi szintet: ");
            string vedettseg = Console.ReadLine().ToLower();
            if (barlangok.Any(x => x.Vedettseg.ToLower() == vedettseg))
            {
                Barlang _ = barlangok.Where(x => vedettseg == x.Vedettseg.ToLower()).OrderByDescending(x => x.Hossz).ToArray().First();
                Console.WriteLine($"\tAzon: {_.Azon}\n\tNév: {_.Nev}\n\tHossz: {_.Hossz} m\n\tMélység: {_.Melyseg} m\n\tTelepülés: {_.Telepules}");
            }
            else
            {
                Console.WriteLine("\tNincs ilyen védettségi szinttel rendelkező barlang az adatok között!");
            }
            Console.WriteLine("7. feladat: Statisztika");
            int maxKeyLength = barlangok.Select(x => x.Vedettseg).Distinct().Max(x => x.Length)+3;
            foreach (string _2 in barlangok.Select(x => x.Vedettseg).Distinct())
            {
                Console.WriteLine($"\t{_2}:{"".PadLeft(maxKeyLength-_2.Length, '-')}> {barlangok.Count(x => x.Vedettseg == _2)} db");
            }
        }
    }
}
