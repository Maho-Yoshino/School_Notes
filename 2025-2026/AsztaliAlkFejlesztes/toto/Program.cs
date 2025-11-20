using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Toto
{
    internal class Program
    {
        class EredmenyElemzo
        {
            private string Eredmenyek;

            private int DontetlenekSzama
            {
                get
                {
                    return Megszamol('X');
                }
            }

            private int Megszamol(char kimenet)
            {
                int darab = 0;
                foreach (var i in Eredmenyek)
                {
                    if (i == kimenet) darab++;
                }
                return darab;
            }

            public bool NemvoltDontetlenMerkozes
            {
                get
                {
                    return DontetlenekSzama == 0;
                }
            }

            public EredmenyElemzo(string eredmenyek) // konstruktor
            {
                Eredmenyek = eredmenyek;
            }
        }
        class FogadasiFordulo
        {
            public int Ev { get; private set; }
            public int Het { get; private set; }
            public int Fordulo { get; private set; }
            public int TelitalalatDarab { get; private set; }
            public int TelitalalatNyeremeny { get; private set; }
            public string Eredmenyek { get; private set; }

            public int NyeremenyOsszeg => TelitalalatDarab * TelitalalatNyeremeny;

            public FogadasiFordulo(string sor)
            {
                string[] m = sor.Split(';');
                Ev = int.Parse(m[0]);
                Het = int.Parse(m[1]);
                Fordulo = int.Parse(m[2]);
                TelitalalatDarab = int.Parse(m[3]);
                TelitalalatNyeremeny = int.Parse(m[4]);
                Eredmenyek = m[5];
            }

            public void EredmenytKiir()
            {
                Console.WriteLine($"\tÉv: {Ev}");
                Console.WriteLine($"\tHét: {Het}.");
                Console.WriteLine($"\tForduló: {Fordulo}.");
                Console.WriteLine($"\tTelitalálat: {TelitalalatDarab} db");
                Console.WriteLine($"\tNyeremény: {TelitalalatNyeremeny} Ft");
                Console.WriteLine($"\tEredmények: {Eredmenyek}");
            }
        }
        static void Main(string[] args)
        {
            FogadasiFordulo[] fordulok = File.ReadAllLines("toto.txt")
                .Skip(1)
                .ToList()
                .ConvertAll(x => new FogadasiFordulo(x))
                .ToArray();
            // 3. Feladat
            Console.WriteLine($"3. feladat: Fordulók száma: {fordulok.Length}");
            // 4. Feladat
            Console.WriteLine($"4. feladat: Telitalálatos szelvények száma: {fordulok.Sum(x => x.TelitalalatDarab)} db");
            // 5. Feladat
            Console.WriteLine($"5. feladat: Átlag: {Math.Round(fordulok.Average(x => x.NyeremenyOsszeg))} Ft");
            // 6. Feladat
            FogadasiFordulo legnagyobb = fordulok.Where(x => x.TelitalalatDarab > 0).OrderBy(x => x.TelitalalatNyeremeny).Last();
            FogadasiFordulo legkisebb = fordulok.Where(x => x.TelitalalatDarab > 0).OrderBy(x => x.TelitalalatNyeremeny).First();
            Console.WriteLine($"6. feladat: ");
            Console.WriteLine("\tLegnagyobb:");
            legnagyobb.EredmenytKiir();
            Console.WriteLine("\n\tLegkisebb:");
            legkisebb.EredmenytKiir();
            // 8. Feladat
            Console.WriteLine($"8. feladat: {(fordulok.ToList().ConvertAll(x => new EredmenyElemzo(x.Eredmenyek)).Any(x => x.NemvoltDontetlenMerkozes) ? "Volt":"Nem volt")} döntetlen nélküli forduló");
            Console.ReadKey();
        }
    }
}
