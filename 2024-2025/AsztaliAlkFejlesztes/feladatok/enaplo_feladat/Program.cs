using System;
using System.IO;
using System.Linq;

namespace enaplo_feladat
{
    struct Tanulo
    {
        public string veznev;
        public string kernev;
        public byte elegtelen;
        public byte elegseges;
        public byte kozepes;
        public byte jo;
        public byte peldas;
        public int pontszam;
    }
    class Program
    {
        static Tanulo[] MaxKivalasztas(Tanulo[] arr)
        {
            for (int i = 0; i < arr.Length ; i++)
            {
                int max_ind = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j].pontszam > arr[max_ind].pontszam)
                    {
                        max_ind = j;
                    }
                }
                Tanulo tmp = arr[i];
                arr[i] = arr[max_ind];
                arr[max_ind] = tmp;
            }
            return arr;
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("enaplo.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            Tanulo[] osztaly = new Tanulo[11];
            int i = 0;
            do
            {
                string line = sr.ReadLine();
                string[] lineparts = line.Split(' ');
                osztaly[i] = new Tanulo { 
                    kernev = lineparts[0], 
                    veznev = lineparts[1], 
                    peldas = byte.Parse(lineparts[2]), 
                    jo = byte.Parse(lineparts[3]), 
                    kozepes = byte.Parse(lineparts[4]),
                    elegseges = byte.Parse(lineparts[5]), 
                    elegtelen = byte.Parse(lineparts[6]) };
                osztaly[i].pontszam = (osztaly[i].peldas * 3) + (osztaly[i].jo * 2) + (osztaly[i].elegseges * (-1)) + (osztaly[i].elegtelen * (-2));
                // Console.WriteLine($"{osztaly[i].kernev}, {osztaly[i].veznev}, {osztaly[i].peldas}, {osztaly[i].jo}, {osztaly[i].kozepes}, {osztaly[i].elegseges}, {osztaly[i].elegtelen}, {osztaly[i].pontszam}");
                i++;
            }
            while (!sr.EndOfStream);
            sr.Close();
            fs.Close();
            double atlag_pontszam = Convert.ToDouble(osztaly.Sum(x => x.pontszam)) / osztaly.Length;
            Tanulo[] atlag_felett = osztaly.Where(x => x.pontszam > atlag_pontszam).ToArray();
            Console.WriteLine($"3. Feladat:\n\tA pontszámok: {string.Join(", ", osztaly.Select(x => x.pontszam))}");
            Console.WriteLine($"4. Feladat:\n\tA pontszámok átlaga: {atlag_pontszam}");
            Console.WriteLine($"5. Feladat:");
            for (i = 0; i < 5 ; i++)
            {
                Console.WriteLine($"\t{atlag_felett[i].kernev} {atlag_felett[i].veznev}\tPontszám: {atlag_felett[i].pontszam}");
            }
            Console.WriteLine("6. Feladat:");
            foreach (Tanulo tanulo in atlag_felett.Where(x => x.pontszam == atlag_felett.Max(j => j.pontszam)).ToArray())
            {
                Console.WriteLine($"\t{tanulo.kernev} {tanulo.veznev}");
            }
            Console.ReadKey();
        }
    }
}
