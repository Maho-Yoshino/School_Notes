using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace egyszamjatek
{
    class Program
    {
        static void Main()
        {
            string[] content = File.ReadAllLines("egyszamjatek.txt", encoding: Encoding.UTF8);
            List<Egyszamjatek> jatekosok = new List<Egyszamjatek>();
            foreach (string sor in content)
            {
                string[] tmp = sor.Split(' ');
                jatekosok.Add(new Egyszamjatek
                {
                    ford1 = int.Parse(tmp[0]),
                    ford2 = int.Parse(tmp[1]),
                    ford3 = int.Parse(tmp[2]),
                    ford4 = int.Parse(tmp[3]),
                    ford5 = int.Parse(tmp[4]),
                    ford6 = int.Parse(tmp[5]),
                    ford7 = int.Parse(tmp[6]),
                    ford8 = int.Parse(tmp[7]),
                    ford9 = int.Parse(tmp[8]),
                    ford10 = int.Parse(tmp[9]),
                    nev = tmp[10]
                });
            }
            Console.WriteLine($"3. Feladat: {jatekosok.Count} játékos vett részt.");
            Console.ReadKey();
        }
        struct Egyszamjatek
        {
            public int ford1;
            public int ford2;
            public int ford3;
            public int ford4;
            public int ford5;
            public int ford6;
            public int ford7;
            public int ford8;
            public int ford9;
            public int ford10;
            public string nev;
        }
    }
}
