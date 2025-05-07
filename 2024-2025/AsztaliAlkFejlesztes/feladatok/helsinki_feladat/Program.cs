using System;
using System.IO;
using System.Linq;
using System.Text;

namespace helsinki_feladat
{
    class Program
    {
        struct Olimpia
        {
            public int helyezes;
            public int sportolok_szama;
            public string sportag;
            public string versenyszam_nev;
        }
        static void Main(string[] args)
        {
            string[] file_content = File.ReadAllLines("helsinki.txt", Encoding.Default);
            Olimpia[] csapatok = new Olimpia[file_content.Length];
            for (byte i = 0; i < file_content.Length; i++)
            {
                string[] split_line = file_content[i].Split(' ');
                csapatok[i] = new Olimpia {
                    helyezes = int.Parse(split_line[0]),
                    sportolok_szama = int.Parse(split_line[1]),
                    sportag = split_line[2],
                    versenyszam_nev = split_line[3]
                };
            }
            int arany_erme = csapatok.Count(x => x.helyezes == 1);
            int ezust_erme = csapatok.Count(x => x.helyezes == 2);
            int bronz_erme = csapatok.Count(x => x.helyezes == 3);
            Console.WriteLine($"3. Feladat:\nPontszerző helyezések száma: {file_content.Length}");
            Console.WriteLine(
                $"4. Feladat:\n" +
                $"Arany: {arany_erme}\n" +
                $"Ezüst: {ezust_erme}\n" +
                $"Bronz: {bronz_erme}\n" +
                $"Összesen: {arany_erme + ezust_erme + bronz_erme}"
            );
            Console.WriteLine($"5. Feladat:\nOlimpiai pontok száma: {arany_erme*7+ezust_erme*5+bronz_erme*4+csapatok.Count(x => x.helyezes == 4)*3+csapatok.Count(x => x.helyezes == 5)*2+ csapatok.Count(x => x.helyezes == 6)}");
            Console.WriteLine($"6. Feladat:\n{(csapatok.Count(x => x.helyezes >= 3 && x.sportag == "uszas") > csapatok.Count(x => x.helyezes >= 3 && x.sportag == "torna") ? "Úszás":"Torna")} sportágban szereztek több érmet");
            FileStream fs = new FileStream("helsinki2.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Olimpia csapat in csapatok)
            {
                int pontok = 7 - csapat.helyezes + (csapat.helyezes == 1 ? 1:0);
                sw.WriteLine($"{csapat.helyezes} {csapat.sportolok_szama} {pontok} {csapat.sportag.Replace("kajakkenu", "kajak-kenu")} {csapat.versenyszam_nev}");
            }
            sw.Close();
            fs.Close();
            Olimpia legtobb_sportolo = csapatok.OrderByDescending(x => x.sportolok_szama).First();
            Console.WriteLine(
                $"8. Feladat:\n" +
                $"Helyezés: {legtobb_sportolo.helyezes}\n" +
                $"Sportág: {legtobb_sportolo.sportag}\n" +
                $"Versenyszám: {legtobb_sportolo.versenyszam_nev}\n" +
                $"Sportolók száma: {legtobb_sportolo.sportolok_szama}"
            );
            Console.ReadKey();
        }
    }
}
