using System;
using System.Linq;

namespace dolgozat_2024_12_03
{
	class Program
	{
		/// <summary>
		/// egy héten keresztül Rudi minden nap elment autózni, minden nap rögzítette, hogy hány km-t tett meg. átlagosan hány km-t tett meg a héten, hányszor ment 30km-nél többet, hány km volt a leghosszabb, legrövidebb útja?
		/// </summary>
		static void Main(string[] args)
		{
			Console.Write("Adja meg, hány napos volt a mérés: ");
			int[] nap_km = new int[int.Parse(Console.ReadLine())];
			for (int i = 0; i < nap_km.Length; i++)
			{
				Console.Write($"{i + 1}. mérés: ");
				nap_km[i] = int.Parse(Console.ReadLine());
			}
			Console.WriteLine($"\nA mérések alapján\n\t{nap_km.Max()}km volt a leghosszabb út\n\t{nap_km.Min()}km volt a legrövidebb út\n\tÁtlagosan {Math.Round(Convert.ToDouble(nap_km.Sum()) / nap_km.Length, 2)}km-t ment\n\t{nap_km.Where(x => x>30).Count()}x ment több, mint 30 km-t");
			Console.ReadKey();
		}
	}
}
