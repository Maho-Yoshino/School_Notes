using System;
using System.Linq;

namespace linearis_kereses
{
	class Program
	{
		private static bool NoFilter<G>(G item) => true;
		static private string Input(string txt)
		{
			Console.Write(txt);
			return Console.ReadLine();
		}
		static private T TryInput<T>(string txt, Func<T, bool> predicate = null)
		{
			predicate ??= NoFilter;
			while (true)
			{
				try
				{
					T[] N = new T[1] { (T)Convert.ChangeType(Input(txt), typeof(T)) };
					if (N.Any(predicate))
					{
						return N[0];
					}
				}
				catch
				{
					Console.WriteLine("Hibás érték.");
					continue;
				}
			}
		}
		static private T[] NewArray<T>(int N, string adattipus = null, Func<T, bool> predicate = null, bool random = false, int min = 0, int max = 0)
		{
			predicate ??= NoFilter;
			Random rnd = new Random();
			T[] arr = new T[N];
			for (int i = 0; i < N; i++)
			{
				if (random && typeof(T) == typeof(int))
				{
					arr[i] = (T)Convert.ChangeType(rnd.Next(min, max), typeof(T));
				}
				else if (random && typeof(T) == typeof(double))
				{
					arr[i] = (T)Convert.ChangeType(Math.Floor(rnd.NextDouble() * (max - min + 1)) + min, typeof(T));
				}
				else
				{
					if (adattipus != null)
					{
						T[] tmp = new T[1] { TryInput<T>($"{i + 1}. {adattipus}: ") };
						while (!tmp.All(predicate))
						{
							tmp = new T[1] { TryInput<T>($"{i + 1}. {adattipus}: ") };
						}
						arr[i] = tmp[0];
					}
					else
					{
						throw new MissingFieldException("Adattípus nem lett megadva.");
					}
				}
			}
			if (arr.All(predicate))
			{
				return arr;
			}
			return null;
		}
		static void Main(string[] args)
		{
			int feladat = TryInput<int>("Adja meg a feladat számát: ", x => x > 0 && x <= 6);
			typeof(Program).GetMethod($"Fel{feladat}").Invoke(null, null);
			Console.ReadKey();
		}
		/// <summary>
		/// Adott egy N elemű, egész típusú tömb. A tömb méretét a felhasználó adja meg! Töltsük fel véletlen számokkal, majd határozzuk meg, hogy van-e a sorozatban olyan elem, amely öttel osztva kettőt ad maradékul, és ha igen, adjuk meg az első ilyen sorszámát! A számok az [50, 80] zárt intervallumból vehetik fel az értékeiket!
		/// </summary>
		public static void Fel1()
		{
			int N = TryInput<int>("N = ");
			int[] rnd = NewArray<int>(N, random:true, min:50, max:81);
			Console.WriteLine($"[{string.Join(", ", rnd)}]");
			bool van = rnd.Any(x => x % 5 == 2);
			int query = -1;
			int i = 0;
			while (i < rnd.Length && query == -1)
			{
				if (rnd[i]%5==2)
				{
					query = i+1;
				}
				i++;
			}
			Console.WriteLine($"{(van ? "Van" : "Nincs")} olyan szám, mely 5-el osztva 2-t ad maradékul. {(van ? $"\nAz első olyan sorszáma: {(query)}":"")}");
		}
		/// <summary>
		/// Egy héten keresztül minden nap 14:00 órakor megmértük a levegő hőmérsékletét! A mért adatokat rögzítettük egy ho nevű tömbben. Határozzuk meg, hogy volt-e egy adott, (felhasználó által bekért) hőmérsékletnél melegebb, és ha igen, adjuk meg az első ilyen nap sorszámát
		/// </summary>
		public static void Fel2()
		{ 
			double[] ho = NewArray<double>(TryInput<int>("Mérések mennyisége: ", x => x > 0), adattipus:"mérés");
			double ref_point = TryInput<double>("Adja meg a referencia hőmérsékletet: ");
			int i = 0, index = -1;
			while (i < ho.Length && index == -1)
			{
				if (ho[i] > ref_point)
				{
					index = i + 1;
				}
				i++;
			}
			Console.WriteLine($"{(index == -1 ? "Van" : "Nincs")} az adott pontnál melegebb mérés. {(index != -1 ? $"\nAz első ilyen sorszáma: {index}.":"")}");
		}
		/// <summary>
		/// Az M0-s autópályán 20 autó sebességét mérték meg a közlekedési rendőrök. Az adatokat rögzítették. Határozzuk meg, hogy volt-e szabálysértő, és ha igen, adjuk meg az első ilyen szabálysértő sorszámát. Kérjük be, hogy mennyi a maximálisan megengedett sebesség autópálya ezen szakaszán!
		/// </summary>
		public static void Fel3()
		{
			uint[] meres = NewArray<uint>(TryInput<int>("Mérések: ", x => x > 0), "mérés", x => x > 0);
			int ref_point = TryInput<int>("Megengedett legnagyobb sebesség: ", x => x > 0);
			int i = 0, index = -1;
			while (i < meres.Length && index == -1)
			{
				if (meres[i] > ref_point)
				{
					index = i + 1;
				}
				i++;
			}
			Console.WriteLine($"{(index == -1 ? "Van" : "Nincs")} az adott pontnál nagyobb mérés. {(index != -1 ? $"\nAz első ilyen sorszáma: {index}" : "")}");
		}
		/// <summary>
		/// Adott egy ismeretlen elemszámú, [-10,10] zárt intervallumba tartozó, véletlen egész számokat tartalmazó sorozat! A sorozat elemszámát a felhasználó adja meg! Adjuk meg, hogy van-e a generált számok között negatív páratlan szám, és ha igen, adjuk meg az első ilyen sorszámát!
		/// </summary>
		public static void Fel4()
		{
			int N = TryInput<int>("Elemszám: ", x => x > 0);
			int[] tomb = NewArray<int>(N, random: true, min: -10, max:11);
			Console.WriteLine($"Generált tömb: [{string.Join(", ", tomb)}]");
			int i = 0, index = -1;
			while (i < tomb.Length && index == -1)
			{
				if (tomb[i] % 2 == -1 && tomb[i] < 0)
				{
					index = i + 1;
				}
				i++;
			}
			Console.WriteLine($"{(index == -1 ? "Nincs":"Van")} negatív páratlan szám {(index == -1 ? "":$"\nAz első ilyen sorszáma: {index}")}");
		}
		/// <summary>
		/// Egy tömb a 10.e osztály programozás dolgozatának osztályzatait tartalmazza! Adjuk meg, hogy van-e ötös dolgozat, és ha igen, adjuk meg az első 5-ös sorszámát!
		/// </summary>
		public static void Fel5()
		{
			int N = TryInput<int>("Tanulók száma: ", x => x > 0);
			int[] jegyek = NewArray<int>(N, "jegy", x => x > 0 && x < 6);
			int i = 0, index = -1;
			while (i < jegyek.Length && index == -1)
			{
				if (i == 5)
				{
					index = i + 1;
				}
				i++;
			}
			Console.WriteLine($"{(index == -1 ? "Van" : "Nincs")} ötös dolgozat. {(index != -1 ? $"\nAz első sorszáma: {index}" : "")}");
		}
		/// <summary>
		/// Kockával dobtunk 30-szor. Adjuk meg dobtunk-e egymásután kétszer hatost, és ha igen, adjuk meg az első ilyen dupla hatos dobás sorszámát!
		/// </summary>
		public static void Fel6()
		{
			int N = TryInput<int>("Dobások: ");
			int[] dobasok = NewArray<int>(N, random: true, min: 1, max: 7);
			int i = 0, index = -1;
			while (index == -1 && i < dobasok.Length-1)
			{
				if (dobasok[i] == 6 && dobasok[i+1] == 6)
				{
					index = i + 1;
				}
				i++;
			}
			Console.WriteLine($"{(index == -1 ? "Nincs" : "Van")} egymásután 2x hatos dobás {(index != -1 ? $"\nElső ilyen sorszáma: {index}" : "")}");
		}
	}
}
