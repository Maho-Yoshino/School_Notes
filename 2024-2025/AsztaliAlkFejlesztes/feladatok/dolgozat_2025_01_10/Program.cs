using System;
using System.Linq;

namespace dolgozat_2025_01_10
{
    class Program
    {
        /// <summary>
        /// Generálj 20 véletlen számot, és tárold el egy tömbben. Határozd meg a generált számok összegét, átlagát, döntsd el, hogy van-e benne egymás után 2x hatos, határozd meg, hogy van-e közte olyan, ami 3-al osztva 1et ad maradékul, és hanyadik az első ilyen. A generált számok a kockadobást imitálják
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write("Adja meg, hány elem legyen generálva: ");
            bool success = int.TryParse(Console.ReadLine(), out int N);
            while (!success)
            {
                Console.Write("Nem megfelelő érték lett megadva, próbálja újra:");
                success = int.TryParse(Console.ReadLine(), out N);
            }
            int[] tomb = new int[N];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                tomb[i] = rnd.Next(1, 7);
            }
            tomb = new int[] {6, 3, 1, 6, 6, 3};
            Console.Write($"A tömb tartalma: [{string.Join(", ", tomb)}]");
            int osszeg = tomb.Sum();
            double atlag = Convert.ToDouble(osszeg) / tomb.Length;
            int last_num = tomb[0];
            bool oszt_maradek = tomb[0] % 3 == 1;
            int oszt_maradek_i = oszt_maradek ? 0 : -1;
            bool van_hatos = false;
            for (int i = 1; i < N; i++)
            {
                if (last_num == 6 && tomb[i] == 6)
                {
                    van_hatos = true;
                }
                last_num = tomb[i];
                if (tomb[i] % 3 == 1 && !oszt_maradek)
                {
                    oszt_maradek = true;
                    oszt_maradek_i = i;
                }
            }
            Console.WriteLine($"\nA generált számok listájában\n\tÖsszeg: {osszeg}\n\tÁtlag: {atlag}\n\tVan benne 2x egymás után hatos: {(van_hatos ? "Igen":"Nem")}\n\tVan olyan szám, amit ha 3-al osztok 1-et kapok maradékul?: {(oszt_maradek ? $"Igen\n\tAz első ilyen elem sorszáma: {oszt_maradek_i+1}":"Nem")}");
            Console.ReadKey();
        }
    }
}
