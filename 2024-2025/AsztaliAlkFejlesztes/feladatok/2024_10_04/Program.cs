using System;

namespace _2024_10_04
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Feladat szám: ");
			int fel_szam = int.Parse(Console.ReadLine());
			switch (fel_szam)
			{
				case 1:
					Fel1();
					break;
				case 2:
					Fel2();
					break;
				case 3:
					Fel3();
					break;
				case 4:
					Fel4();
					break;
				case 5:
					Fel5();
					break;
				case 6:
					Fel6();
					break;
				case 7:
					Fel7();
					break;
				case 8:
					Fel8();
					break;
				case 9:
					Fel9();
					break;
			}
			Console.ReadKey();
		}
		static private double Input_double(string valtozo_nev)
		{
			Console.Write("{0} = ", valtozo_nev);
			return double.Parse(Console.ReadLine().Replace('.', ','));
		}
		static private int Input_Int(string valtozo_nev)
		{
			Console.Write("{0} = ", valtozo_nev);
			return int.Parse(Console.ReadLine());
		}
		/// <summary>
		/// Írj programot, amely elvégzi a négy alapműveletet két egész számon (összeadás, kivonás, szorzás, osztás)!
		/// </summary>
		static void Fel1()
		{
			int a = Input_Int("a");
			int b = Input_Int("b");
			Console.WriteLine("a+b={0}\na-b={1}\na*b={2}\na/b={3}", a + b, a - b, a * b, a / b);
		}
		/// <summary>
		/// Írj programot, amely elvégzi a négy alapműveletet két valós számon (összeadás, kivonás, szorzás, osztás)!
		/// </summary>
		static void Fel2() 
		{
			double a = Input_double("a");
			double b = Input_double("b");
			Console.WriteLine("a+b={0}\na-b={1}\na*b={2}\na/b={3}", a + b, a - b, a * b, a / b);
		}
		/// <summary>
		/// Megadja két egész szám hányadosának egész részét, illetve a maradékot(div, mod)!
		/// </summary>
		static void Fel3()
		{
			int a = Input_Int("a");
			int b = Input_Int("b");
			Console.WriteLine("div = {0}\nmod = {1}", a / b - (a % b / 10), a % b);
		}
		static private double Pitagoras(double a, double b)
		{
			return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
		}
		static private double Pitagoras(double a)
		{
			return Math.Sqrt(Math.Pow(a, 2) * 2);
		}
		/// <summary>
		/// Adottak egy téglalap oldalai: „a” és „b”. Írj programot, amely meghatározza a téglalap kerületét, területét és átmérőjének hosszát!
		/// </summary>
		static void Fel4()
		{
			double a = Input_double("a");
			double b = Input_double("b");
			double K = (a+b)*2;
			double T = a*b;
			double atlo = Pitagoras(a, b);
			Console.WriteLine("\tKerület: {0}\n\tTerület: {1}\n\tÁtlója: {2}", K, T, atlo);
		}
		///<summary>
		///Írj programot, amely megadja egy „a” oldalú négyzet kerületét, területét és a négyzet átlójának a hosszát!
		///</summary>
		static void Fel5()
		{
			double a = Input_double("a");
			double K = a*4;
			double T = a*a;
			double atlo = Pitagoras(a);
			Console.WriteLine("Az adott négyzetnek\n\tKerülete: {0}\n\tTerülete: {1}\n\tÁtlójának hossza: {2}", K,T,atlo);
		}
		///<summary>
		///Határozd meg egy adott sugarú kör („r”) kerületét és területét!
		///</summary>
		static void Fel6()
		{
			double r = Input_double("r");
			double K = 2*r*Math.PI;
			double T = Math.Pow(r, 2)*Math.PI;
			Console.WriteLine("Az adott körnek\n\tKerülete: {0}\n\tTerülete: {1}", K, T);
		}
		///<summary>
		///Határozd meg egy derékszögű háromszög kerületét és területét, a két befogó ismeretének segítségével!
		///</summary>
		static void Fel7()
		{
			double a = Input_double("a");
			double b = Input_double("b");
			double c = Pitagoras(a,b);
			Console.WriteLine("Az adott háromszög ({0}, {1}) befogója {2} hosszú", a, b ,c);
		}
		///<summary>
		///Adott 3 egész szám! Ellenőrizd, hogy alkothatják-e egy háromszög oldalait és amennyiben igen, határozd meg a kerületét és területét!
		///</summary>
		static void Fel8()
		{
			double a = Input_double("a");
			double b = Input_double("b");
			double c = Input_double("c");
			if (a+b>c||a+c>b||b+c>a)
			{
				Console.WriteLine("Az adott oldalakból nem lehet háromszög");
			}
			else
			{
				Console.WriteLine("Az adott oldalakból lehet háromszög");
			}
		}
		///<summary>
		///Írj programot, amely megadja a kocka felszínét, térfogatát és kocka átlójának hosszát! A kocka éle adott: „a”!
		///</summary>
		static void Fel9()
		{
			double a = Input_double("a");
			double F = 6*Math.Pow(a,2);
			double T = Math.Pow(a, 3);
			double atlo = Math.Sqrt(Math.Pow(Pitagoras(a), 2)+Math.Pow(a, 2));
			Console.WriteLine("Az adott élhosszal a létrehozható kocka\n\tFelszíne: {0}\n\tTérfogata: {1}\n\tÁtlója: {2}",F,T,Math.Round(atlo, 2));
		}
	}
}
