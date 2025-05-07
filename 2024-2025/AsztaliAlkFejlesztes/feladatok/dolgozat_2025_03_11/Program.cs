using System;
using System.Linq;

namespace dolgozat_2025_03_11
{  
    struct tanulo_adat
    {
        public string nev;
        public int kor;
        public double atlag;
    }
    class Program
    {
        private static bool NoFilter<G>(G item) => true;
        private static T TryInput<T>(string text, Func<T, bool> predicate = null)
        {
            predicate ??= NoFilter;
            while (true)
            {
                try
                {
                    Console.Write(text);
                    T[] tmp = new T[1] { (T)Convert.ChangeType(Console.ReadLine().Replace('.',','), typeof(T)) };
                    if (tmp.All(predicate))
                    {
                        return tmp[0];
                    }
                    else
                        Console.WriteLine("Nem felel meg a követelményeknek az adat");
                }
                catch
                {
                    Console.WriteLine("Hibás érték");
                }
            }
        }
        /// <summary>
        /// Egy tömb egy osztály tanulóinak következő adatait tárolja: név, életkor, tanulmányi átlag.
	    ///     1. Mennyi az osztályátlag?  
	    ///     2. Hány tanuló fiatalabb, mint 16?  
	    ///     3. Van-e olyan tanuló, akinek az átlaga >4.7?  
        /// </summary>
        static void Main(string[] args)
        {
            tanulo_adat[] osztaly = new tanulo_adat[TryInput<int>("N = ", x => x > 0)];
            for (int i = 0; i < osztaly.Length; i++)
            {
                Console.WriteLine($"{i + 1}. tanuló:\n");
                osztaly[i].nev = TryInput<string>("\tTanuló neve:");
                osztaly[i].kor = TryInput<int>("\tTanuló életkora: ", x => x > 0);
                osztaly[i].atlag = TryInput<double>("\tTanuló átlaga: ", x => x >= 1.0 && x <= 5.0);
            }
            /*double atl_osszeg = 0;
            int tanulo_16_felett = 0;
            bool van_4_7_felett = false;
            foreach (tanulo_adat tanulo in osztaly)
            {
                if (tanulo.kor > 16)
                {
                    tanulo_16_felett++;
                }
                if (tanulo.atlag > 4.7 && !(van_4_7_felett))
                    van_4_7_felett = true;
                atl_osszeg += tanulo.atlag;
            }
            Console.WriteLine($"Az osztályátlag: {Math.Round((atl_osszeg / osztaly.Length), 2)}\n{tanulo_16_felett}db 16 év feletti tanuló van\n{(van_4_7_felett ? "Van":"Nincs")} olyan tanuló, akinek 4.7 feletti átlaga van");*/
            Console.WriteLine($"Az osztályátlag: {Math.Round(osztaly.Sum(x => x.atlag) / osztaly.Length, 2)}\n{osztaly.Select(x => x.kor > 16).Count(x => x == true)}db 16 év feletti tanuló van\n{(osztaly.Any(x => x.atlag > 4.7) ? "Van" : "Nincs")} olyan tanuló, akinek 4.7 feletti átlaga van");
            Console.ReadKey();
        }
    }
}
