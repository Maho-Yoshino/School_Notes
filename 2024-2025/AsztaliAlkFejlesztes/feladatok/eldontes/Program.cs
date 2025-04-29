using System;
using System.Linq;

namespace eldontes
{
	class Program
	{
		static private int[] RandomArray(int N, int min, int max)
		{
			int[] arr = new int[N];
			Random rnd = new Random();
			for (int i = 0; i<N; i++)
			{
				arr[i] = rnd.Next(min, max);
			}
			return arr;
		}
		static private T[] NewArray<T>(int N, string adattipus, bool random = false, int min = 0, int max = 0)
		{
			Random rnd = new Random();
			T[] arr = new T[N];
			for (int i = 0; i < N; i++)
			{
				if (random && typeof(T)==typeof(int))
				{
					arr[i] = (T)Convert.ChangeType(rnd.Next(min, max), typeof(T));
				}
				else if (random && typeof(T) == typeof(double))
				{
					arr[i] = (T)Convert.ChangeType(Math.Floor(rnd.NextDouble()*(max-min+1))+min, typeof(T));
				}
				else
				{
					arr[i] = (T)Convert.ChangeType(Input($"{i + 1}. {adattipus}: "), typeof(T));
				}
			}
			return arr;
		}
		static private T TryInput<T>(string txt, Func<T, bool> predicate = null)
		{
			static bool NoFilter<G>(G item) { return true; }
			predicate = predicate == null ? NoFilter : predicate;
			while (true)
			{
				try
				{
					T N = (T)Convert.ChangeType(Input(txt), typeof(T));
					T[] tmp = new T[1] { N };
					if (tmp.Any(predicate))
					{
						return N;
					}
				}
				catch
				{
					Console.WriteLine("Hibás érték.");
					continue;
				}
			}
		}
		static string Input(string txt)
		{
			Console.Write(txt);
			return Console.ReadLine();
		}
		static void Main(string[] args)
		{
			bool success = int.TryParse(Input("Adja meg a feladat számát: "), out int feladat);
			while (!success || feladat<0 || feladat>6)
			{
				success = int.TryParse(Input("Adjon meg egy megfelelő feladatszámot: "), out feladat);
			}
			typeof(Program).GetMethod($"Fel{feladat}").Invoke(null, null);
			Console.ReadKey();
		}
		/// <summary>
		/// Adott egy n elemű, egész típusú tömb. A tömb méretét a felhasználó adja meg! Töltsük fel véletlen számokkal, majd határozzuk meg, hogy van-e a sorozatban olyan elem, amely öttel osztva kettőt ad maradékul! A számok az[50, 80] zárt intervallumból vehetik fel az értékeiket!
		/// </summary>
		public static void Fel1()
		{
			int N = TryInput<int>("Adja meg a tömb méretét: ", x => x>0);
			int[] tomb = RandomArray(N, 50, 81);
			string result = tomb.Any(x => x % 5 != 2) ? "Van" : "Nincs";
			Console.Write($"{result} olyan szám, amelyik 5-el osztva 2-t ad maradékul. ([{string.Join(", ", tomb)}])");
		}
		/// <summary>
		/// Egy héten keresztül minden nap 14:00 órakor megmértük a levegő hőmérsékletét! A mért adatokat rögzítettük egy ho nevű tömbben.Határozzuk meg, hogy volt-e egy adott (felhasználó által bekért) hőmérsékletnél melegebb?
		/// </summary>
		public static void Fel2()
		{
			double[] ho = NewArray<double>(TryInput<int>("Adja meg, hány napon át mért: ", x => x>0), "mérés");
			double ref_point = TryInput<double>("Adja meg a referencia hőmérsékletet: ");
			string response = ho.Any(x => x > ref_point) ? "Van" : "Nincs";
			Console.WriteLine($"{response} az adott referencia pontnál ({ref_point}) melegebb mérés.\nMérések: [{string.Join(", ", ho)}]");
		}
		/// <summary>
		/// Az M0-s autópályán 20 autó sebességét mérték meg a közlekedési rendőrök. Az adatokat rögzítették.Határozzuk meg, hogy volt-e szabálysértő? Kérjük be, hogy mennyi a maximálisan megengedett sebesség autópálya ezen szakaszán!
		/// </summary>
		public static void Fel3()
		{
			int[] meresek = NewArray<int>(TryInput<int>("Adja meg a mérések mennyiségét: "), "mérés");
			int N = TryInput<int>("Adja meg a maximális sebességet: ");
			string result = meresek.Any(x => x > N) ? "Volt":"Nincs";
			Console.WriteLine($"{result} szabálysértő a mérések között");
		}
		/// <summary>
		/// Adott egy ismeretlen elemszámú, [-10,10] zárt intervallumba tartozó, véletlen egész számokat tartalmazó sorozat! A sorozat elemszámát a felhasználó adja meg! Adjuk meg, hogy van-e a generált számok között negatív páratlan szám!
		/// </summary>
		public static void Fel4()
		{
			int[] rnd_arr = RandomArray(TryInput<int>("Adja meg, hány elemű legyen a lista: ", x => x > 0), -10, 10);
			string result = rnd_arr.Any(x => x < 0 && x % 2 == 1) ? "Van":"Nincs";
			Console.WriteLine($"{result} negatív páratlan szám a listában.\nA lista tartalma: {string.Join(", ", rnd_arr)}");
		}
		/// <summary>
		/// Egy tömb a 10.e osztály programozás dolgozatának osztályzatait tartalmazza! Adjuk meg, hogy van-e ötös dolgozat!
		/// </summary>
		public static void Fel5()
		{
			Console.WriteLine($"{(NewArray<double>(TryInput<int>("Adja meg, hány tanuló van: ", x => x > 0 && x < 6), "osztályzat").Any(x => x > 4.5) ? "Van":"Nincs")} ötös dolgozat"); // Ahogy kiderült, meglehet egy sorban oldani...
		}
		/// <summary>
		/// Kockával dobtunk 30-szor. Adjuk meg dobtunk-e egymásután kétszer hatost!
		/// </summary>
		public static void Fel6()
		{
			int N = TryInput<int>("Adja meg, hányszor dobjunk kockát: ", x => x > 0 && x <= 6);
			int[] dobasok = NewArray<int>(N, "dobás");
			bool dobasok_2x6 = false;
			int i = 1;
			int last_num = dobasok[0];
			while (i < dobasok.Length && !dobasok_2x6)
			{
				if (last_num == 6 && dobasok[i] == 6)
				{
					dobasok_2x6 = true;
				}
				last_num = dobasok[i];
				i++;
			}
			Console.WriteLine($"{(dobasok_2x6 ? "Dobtunk" : "Nem dobtunk")} 2x egymásután hatost.");
		}
	}
}
