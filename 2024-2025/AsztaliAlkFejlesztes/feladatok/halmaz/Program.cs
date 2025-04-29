using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace halmaz
{
    struct Diak
    {
        public string nev;
    }
    class Program
    {
        public const string irodalmas_nevek = @"C:\Users\molek.tamas\Documents\irodalmas_nevek.txt";
        public const string matekos_nevek = @"C:\Users\molek.tamas\Documents\matekos_nevek.txt";
        public const string metszet = @"C:\Users\molek.tamas\Documents\metszet.txt";
        static void Main(string[] args)
        {
            string[] irodalmasok = File.ReadAllLines(irodalmas_nevek);
            string[] matekosok = File.ReadAllLines(matekos_nevek);
            using (StreamWriter sw = new StreamWriter(new FileStream(metszet, FileMode.Create))) {
                foreach (string _nev in irodalmasok.ToList().Union(matekosok))
                {
                    Diak diak = new Diak { nev = _nev };
                    if (irodalmasok.Contains(_nev) && matekosok.Contains(_nev))
                    {
                        sw.WriteLine(diak.nev);
                    }
                }
            }
        }
    }
}
