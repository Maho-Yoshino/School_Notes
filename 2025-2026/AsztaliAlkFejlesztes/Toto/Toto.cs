using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Toto
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
        public int Év { get; private set; }
        public int Hét { get; private set; }
        public int Forduló { get; private set; }
        public int TelitalálatDarab { get; private set; }
        public int TelitalálatNyereméy { get; private set; }
        public string Eredmények { get; private set; }

        public int NyereményÖsszeg => TelitalálatDarab * TelitalálatNyereméy;

        public FogadasiFordulo(string sor)
        {
            string[] m = sor.Split(';');
            Év = int.Parse(m[0]);
            Hét = int.Parse(m[1]);
            Forduló = int.Parse(m[2]);
            TelitalálatDarab = int.Parse(m[3]);
            TelitalálatNyereméy = int.Parse(m[4]);
            Eredmények = m[5];
        }

        public void EredménytKiír()
        {
            Console.WriteLine($"\tÉv: {Év}");
            Console.WriteLine($"\tHét: {Hét}.");
            Console.WriteLine($"\tForduló: {Forduló}.");
            Console.WriteLine($"\tTelitalálat: {TelitalálatDarab} db");
            Console.WriteLine($"\tNyeremény: {TelitalálatNyereméy} Ft");
            Console.WriteLine($"\tEredmények: {Eredmények}");
        }
    }
    class Toto
    {
        static void Main()
        {
            List<FogadasiFordulo> fordulók = new List<FogadasiFordulo>();
            foreach (var i in File.ReadAllLines("toto.txt").Skip(1))
            {
                fordulók.Add(new FogadasiFordulo(i));
            }

            Console.WriteLine($"3. feladat: Fordulók száma: {fordulók.Count}");

            // 4. feladat:
            int szelvény13p1Db = 0;
            foreach (var i in fordulók)
            {
                szelvény13p1Db += i.TelitalálatDarab;
            }
            Console.WriteLine($"4. feladat: Telitalálatos szelvények száma: {szelvény13p1Db} db");

            // 5. feladat:
            double nyereményekÖsszege = 0;
            int telitalálatosFordulóDb = 0;
            foreach (var i in fordulók)
            {
                checked
                {
                    nyereményekÖsszege += i.NyereményÖsszeg;
                    telitalálatosFordulóDb++;
                }
            }
            Console.WriteLine($"5. feladat: Átlag: {nyereményekÖsszege / telitalálatosFordulóDb:F0} Ft");

            Console.WriteLine("6. feladat:");
            int maxi = -1;
            int mini = -1;
            for (int i = 1; i < fordulók.Count; i++)
            {
                if (fordulók[i].TelitalálatDarab > 0)
                {
                    if (maxi == -1) maxi = i;
                    if (mini == -1) mini = i;
                    if (fordulók[i].TelitalálatNyereméy > fordulók[maxi].TelitalálatNyereméy)
                    {
                        maxi = i;
                    }
                    if (fordulók[i].TelitalálatNyereméy < fordulók[mini].TelitalálatNyereméy)
                    {
                        mini = i;
                    }
                }
            }
            Console.WriteLine("\tLegnagyobb:");
            fordulók[maxi].EredménytKiír();
            Console.WriteLine("\n\tLegkisebb:");
            fordulók[mini].EredménytKiír();

            // 8. feladat:
            bool voltDöntetlenNélküliForduló = false;
            foreach (var i in fordulók)
            {
                EredmenyElemzo ee = new EredmenyElemzo(i.Eredmények);
                if (ee.NemvoltDontetlenMerkozes)
                {
                    voltDöntetlenNélküliForduló = true;
                    break;
                }
            }
            Console.WriteLine($"8. feladat: {(voltDöntetlenNélküliForduló ? "Volt" : "Nem volt")} döntetlen nélküli forduló!");

            Console.ReadKey();
        }
    }
}
