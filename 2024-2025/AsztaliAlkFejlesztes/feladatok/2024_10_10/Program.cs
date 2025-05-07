using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Titanic
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = "C:\\Users\\user\\source\\repos\\Titanic2\\titanic.txt";
            if (!File.Exists(Path))
            {
                Console.WriteLine("A fájl nem található");
                Console.ReadKey();
                return;
            }
            List<Adatszerk> adatok = new List<Adatszerk>();
            using (StreamReader reader = File.OpenText(Path))
            {
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                    string[] adat = s.Split(';');
                    if (adat.Length < 3)
                    {
                        Console.WriteLine(adat.ToString());
                        continue;
                    }
                    if (uint.TryParse(adat[1].Trim(), out uint tulelok) && uint.TryParse(adat[2].Trim(), out uint adat_eltunt))
                    {
                        adatok.Add(new Adatszerk
                        {
                            Categ = adat[0],
                            Tulelok = tulelok,
                            Elveszett = adat_eltunt
                        });
                    }
                    else
                    {
                        Console.WriteLine(adat.ToString());
                    }
                }
            }
            foreach (Adatszerk adat in adatok)
            {
                Console.WriteLine("{0}, {1}, {2}\n", adat.Categ, adat.Tulelok, adat.Elveszett);
            }
            Console.ReadKey();
        }
    }
    public class Adatszerk
    {
        public string Categ { get; set; }
        public uint Tulelok { get; set; }
        public uint Elveszett { get; set; }
    }
}
