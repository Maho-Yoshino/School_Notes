using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom_feladatok
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
            predicate = predicate == null ? NoFilter:predicate;
            while (true)
            {
                try
                {
                    T[] N = new T[1] { (T)Convert.ChangeType(Input(txt).Replace('.', ','), typeof(T)) };
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
            predicate = predicate == null ? NoFilter : predicate;
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
            int feladat = TryInput<int>("Adja meg a feladat számát: ", x => x <= 60);
            typeof(Program).GetMethod($"Fel{feladat}").Invoke(null, null);
            Console.ReadKey();
        }
        /// <summary>
		/// Írj programot, amely elvégzi a négy alapműveletet két egész számon (összeadás, kivonás, szorzás, osztás)!
		/// </summary>
		public static void Fel2()
        {
            int a = TryInput<int>("a = ");
            int b = TryInput<int>("b = ");
            Console.WriteLine("a+b={0}\na-b={1}\na*b={2}\na/b={3}", a + b, a - b, a * b, a / b);
        }
        /// <summary>
        /// Írj programot, amely elvégzi a négy alapműveletet két valós számon (összeadás, kivonás, szorzás, osztás)!
        /// </summary>
        public static void Fel3()
        {
            double a = TryInput<double>("a = ");
            double b = TryInput<double>("b = ");
            Console.WriteLine("a+b={0}\na-b={1}\na*b={2}\na/b={3}", a + b, a - b, a * b, a / b);
        }
        /// <summary>
        /// Megadja két egész szám hányadosának egész részét, illetve a maradékot(div, mod)!
        /// </summary>
        public static void Fel4()
        {
            int a = TryInput<int>("a = ");
            int b = TryInput<int>("b = ");
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
        public static void Fel5()
        {
            double a = TryInput<double>("a = ");
            double b = TryInput<double>("b = ");
            double K = (a + b) * 2;
            double T = a * b;
            double atlo = Pitagoras(a, b);
            Console.WriteLine("\tKerület: {0}\n\tTerület: {1}\n\tÁtlója: {2}", K, T, atlo);
        }
        ///<summary>
        ///Írj programot, amely megadja egy „a” oldalú négyzet kerületét, területét és a négyzet átlójának a hosszát!
        ///</summary>
        public static void Fel6()
        {
            double a = TryInput<double>("a = ");
            double K = a * 4;
            double T = a * a;
            double atlo = Pitagoras(a);
            Console.WriteLine("Az adott négyzetnek\n\tKerülete: {0}\n\tTerülete: {1}\n\tÁtlójának hossza: {2}", K, T, atlo);
        }
        ///<summary>
        ///Határozd meg egy adott sugarú kör („r”) kerületét és területét!
        ///</summary>
        public static void Fel7()
        {
            double r = TryInput<double>("r = ");
            double K = 2 * r * Math.PI;
            double T = Math.Pow(r, 2) * Math.PI;
            Console.WriteLine("Az adott körnek\n\tKerülete: {0}\n\tTerülete: {1}", K, T);
        }
        ///<summary>
        ///Határozd meg egy derékszögű háromszög kerületét és területét, a két befogó ismeretének segítségével!
        ///</summary>
        public static void Fel8()
        {
            double a = TryInput<double>("a = ");
            double b = TryInput<double>("b = ");
            double c = Pitagoras(a, b);
            Console.WriteLine("Az adott háromszög ({0}, {1}) befogója {2} hosszú", a, b, c);
        }
        ///<summary>
        ///Adott 3 egész szám! Ellenőrizd, hogy alkothatják-e egy háromszög oldalait és amennyiben igen, határozd meg a kerületét és területét!
        ///</summary>
        public static void Fel9()
        {
            double a = TryInput<double>("a = ");
            double b = TryInput<double>("b = ");
            double c = TryInput<double>("c = ");
            Console.WriteLine($"Az adott oldalakból {(a + b > c || a + c > b || b + c > a ? "nem":"")} lehet háromszög");
        }
        ///<summary>
        ///Írj programot, amely megadja a kocka felszínét, térfogatát és kocka átlójának hosszát! A kocka éle adott: „a”!
        ///</summary>
        public static void Fel10()
        {
            double a = TryInput<double>("a = ");
            double F = 6 * Math.Pow(a, 2);
            double T = Math.Pow(a, 3);
            double atlo = Math.Sqrt(Math.Pow(Pitagoras(a), 2) + Math.Pow(a, 2));
            Console.WriteLine("Az adott élhosszal a létrehozható kocka\n\tFelszíne: {0}\n\tTérfogata: {1}\n\tÁtlója: {2}", F, T, Math.Round(atlo, 2));
        }
        /// <summary>
        /// Adott egy kétjegyű szám. Írj programot, amely meghatározza a számjegyek összegét, kiírja a számot fordítva és megadja a nagyobb számjegyet!
        /// </summary>
        public static void Fel11()
        {
            byte num = TryInput<byte>("Adjon meg egy kétjegyű számot: ", x => x < 100 && x >= 10);
            byte[] szamjegyek = new byte[] {Convert.ToByte(num/10), Convert.ToByte(num % 10)};
            Console.WriteLine("A szám\n\tSzámjegyeinek összege: {0}\n\tFordítva: {1}\n\tA nagyobb számjegye: {2}", szamjegyek[0]+szamjegyek[1], szamjegyek[1]*10+szamjegyek[0], Math.Max(szamjegyek[0], szamjegyek[1]));
        }
        /// <summary>
        /// Adott egy háromjegyű szám. Írj programot, amely meghatározza a számjegyek összegét, kiírja a számot fordítva és megadja a legnagyobb számjegyet!
        /// </summary>
        public static void Fel12()
        {
            int num = TryInput<int>("Adjon meg egy háromjegyű számot: ", x => x >= 100 && x < 1000);
            byte[] szamjegyek = new byte[] { Convert.ToByte(num/100), Convert.ToByte(num / 10 % 10), Convert.ToByte(num % 10) };
            Console.WriteLine("A szám\n\tSzámjegyeinek összege: {0}\n\tFordítva: {1}\n\tA nagyobb számjegye: {2}", szamjegyek[0] + szamjegyek[1] + szamjegyek[2], szamjegyek[2]*100+szamjegyek[1] * 10 + szamjegyek[0], Math.Max(szamjegyek[0], Math.Max(szamjegyek[1], szamjegyek[2])));
        }
        /// <summary>
        /// Adott egy négyjegyű szám. Írj programot, amely meghatározza a számjegyek összegét, kiírja a számot fordítva és megadja a legkisebb számjegyet!
        /// </summary>
        public static void Fel13()
        {
            int num = TryInput<int>("Adjon meg egy négyjegyű számot: ", x => x >= 1000 && x <= 9999);
            byte[] szamjegyek = new byte[] {Convert.ToByte(num/1000), Convert.ToByte(num/100%10), Convert.ToByte(num/10%10), Convert.ToByte(num%10)};
            Console.WriteLine("A szám\n\tSzámjegyeinek összege: {0}\n\tFordítva: {1}\n\tA nagyobb számjegye: {2}", szamjegyek[0] + szamjegyek[1] + szamjegyek[2] + szamjegyek[3], szamjegyek[3]*1000 + szamjegyek[2]*100 + szamjegyek[1]*10 + szamjegyek[0], Math.Max(Math.Max(szamjegyek[0], szamjegyek[3]), Math.Max(szamjegyek[1], szamjegyek[2])));
        }
        /// <summary>
        /// Írasd ki azt a számot, amelyet egy egész számból úgy kapunk, hogy kihagyjuk a tízesek helyén állót!
        /// </summary>
        public static void Fel14()
        {
            int num = TryInput<int>("Adjon meg egy egész számot: ");
            Console.WriteLine("A szám: {0}", num/100*10+num%10);
        }
        /// <summary>
        /// Adott egy háromjegyű egész szám! Írj programot, amely megadja azt a legnagyobb számot, amely az adott szám számjegyeiből képezhető!
        /// </summary>
        public static void Fel15()
        {
            int num = TryInput<int>("Adjon meg egy háromjegyű számot: ", x => x >= 100 && x < 1000);
            List<byte> szamjegyek = new List<byte> { Convert.ToByte(num / 100), Convert.ToByte(num / 10 % 10), Convert.ToByte(num % 10) };
            byte legnagyobb, legkisebb;
            legnagyobb = Math.Max(szamjegyek[0], Math.Max(szamjegyek[1], szamjegyek[2]));
            szamjegyek.Remove(legnagyobb);
            legkisebb = Math.Min(szamjegyek[0], Math.Min(szamjegyek[1], szamjegyek[2]));
            szamjegyek.Remove(legkisebb);
            Console.WriteLine("A legnagyobb képezhető szám a számjegyekből: {0}", legnagyobb*100+szamjegyek[0]*10+legkisebb);
        }
        /// <summary>
        /// Írjunk programot, amely felcseréli egy adott egész számban az egyesek és százasok helyén álló számjegyeket!
        /// </summary>
        public static void Fel16()
        {
            int num = TryInput<int>("Adjon meg egy egész számot: ");
            Console.WriteLine("A szám: {0}", num / 100 * 100 + num % 10*10+num/10%10);
        }
        /// <summary>
        /// Alakítsuk át a másodpercekben megadott időt, órára, percre, másodpercre. A kiírás formátuma legyen óra:perc:másodperc!
        /// </summary>
        public static void Fel17()
        {
            Console.WriteLine();
            int mp = TryInput<int>("Adja meg az időt másodpercben: ");
            int perc = 0, ora = 0;
            while (mp>=60)
            {
                perc += 1;
                mp -= 60;
            }
            while (perc >= 60)
            {
                ora += 1;
                perc -= 60;
            }
            Console.WriteLine("Az idő átalakítva: {0}:{1,2}:{2,2}", ora, perc.ToString("D2"), mp.ToString("D2"));
        }
        /// <summary>
        /// A vonat adott óra:perc-kor indult el a célállomásra. Az út adott percig tartott. Írjunk programot, amely megadja a vonat érkezésének időpontját! Ez lehet a rákövetkező napon is!
        /// </summary>
        public static void Fel18()
        {
            string[] ido_array = Input("Adja meg a vonat indulási idejét óra:perc formátumban: ").Split(':');
            int ora = int.Parse(ido_array[0]);
            int perc = int.Parse(ido_array[1]);
            Console.WriteLine("Adja meg az út időhosszát percben:");
            int idohossz = int.Parse(Console.ReadLine());
            perc += idohossz;
            while(perc >= 60)
            {
                perc -= 60;
                ora += 1;
            }
            while (ora>=24)
            {
                ora -= 24;
            }
            Console.WriteLine("Érkezés: {0}:{1}", ora, perc);
        }
        /// <summary>
        /// Adott egy egész szám, N. Írj programot, amely megadja az első olyan N-nél nagyobb számot, amely osztható 7-tel!
        /// </summary>
        public static void Fel19()
        {
            int N = TryInput<int>("N = ");
            int N_nagyobb = N+1;
            while (N_nagyobb % 7 != 0)
            {
                N_nagyobb += 1;
            }
            Console.WriteLine("{0}-nál/nél legközelebbi, nagyobb, 7-el osztható szám: {1}", N, N_nagyobb);
        }
        /// <summary>
        /// Adott egy egész szám, N. Írj programot, amely megadja az N-hez legközelebb eső olyan számot, amely osztható 7-tel!
        /// </summary>
        public static void Fel20()
        {
            int N = TryInput<int>("N = ");
            if (N%7==0)
            {
                Console.WriteLine("{0} osztható 7-el.", N);
                return;
            }
            int N_nagyobb = N + 1;
            int N_kisebb = N - 1;
            while (N_nagyobb % 7 != 0 && N_kisebb % 7 != 0)
            {
                N_nagyobb += 1;
                N_kisebb -= 1;
            }
            Console.WriteLine($"{N}-nál/nél legközelebbi, 7-el osztható szám: {(N_nagyobb % 7 == 0 ? N_nagyobb : N_kisebb)}");
        }
        /// <summary>
        /// Adott egy egész szám, N. Írj programot, amely kiírja az N-nél kisebb, de legközelebb eső olyan számot, amelynek gyöke egész szám! (az első négyzetszámot)
        /// </summary>
        public static void Fel21()
        {
            int N = TryInput<int>("N = ");
            int N_kisebb = N - 1;
            while (Math.Sqrt(N_kisebb) % 1 != 0)
            {
                N_kisebb -= 1;
            }
            Console.WriteLine($"{N}-hez/hoz legközelebb eső, kisebb szám, melynek gyöke egész szám: {N_kisebb}");
        }
        /// <summary>
        /// Adott egy egész szám, N. Írj programot, amely megadja az N-hez legközelebb eső négyzetszámot!
        /// </summary>
        public static void Fel22()
        {
            int N = TryInput<int>(("N = "));
            int N_kisebb = N - 1;
            int N_nagyobb = N + 1;
            while (Math.Sqrt(N_kisebb)%1!=0 && Math.Sqrt(N_nagyobb)%1!=0)
            {
                N_kisebb -= 1;
                N_nagyobb += 1;
            }
            Console.WriteLine($"{N}-hez/hoz legközelebb eső négyzetszám: {(Math.Sqrt(N_kisebb) % 1 == 0 ? N_nagyobb:N_kisebb)} ({Math.Sqrt(N_kisebb)}^2)");
        }
        /// <summary>
        /// Írj programot, amely egy beolvasott számról eldönti, hogy páros vagy páratlan!
        /// </summary>
        public static void Fel23()
        {
            int num = TryInput<int>("Adjon meg egy egész számot: ");
            Console.WriteLine($"A szám {(num % 2 == 0 ? "páros" : "páratlan")}");
        }
        /// <summary>
        /// Adott két szög, (fokkal, szögperccel és szögmásodperccel megadva). Írj programot, amely megadja a két szög összegét!
        /// </summary>
        public static void Fel24()
        {
            
        }
        /// <summary>
        /// Írjunk programot, amely az elágazás nélkül kiírja, hogy két szám közül, melyik a nagyobb.Ha egyenlőek, azt is kiírja!
        /// </summary>
        public static void Fel25()
        {
            int num1 = TryInput<int>("Adja meg az első számot: ");
            int num2 = TryInput<int>("Adja meg a második számot: ");
            Console.WriteLine("{0} nagyobb, a két szám egyenlő-e?: {1}", Math.Max(num1, num2), num1==num2);
        }
        /// <summary>
        /// Adott két szám. Írj, programot, amely eldönti, hogy egyenlőek vagy különböznek!
        /// </summary>
        public static void Fel27()
        {
            double num1 = TryInput<double>("Adja meg az első számot: ");
            double num2 = TryInput<int>("Adja meg a második számot: ");
            Console.WriteLine($"A két szám {(num1 == num2 ? "" : "nem")} egyenlő");
        }
        /// <summary>
        /// Írj programot, amely kiírja a két különböző szám közül a nagyobbat!
        /// </summary>
        public static void Fel28()
        {
            double num1 = TryInput<int>("Adja meg az első számot: ");
            double num2 = TryInput<int>("Adja meg a második számot: ");
            Console.WriteLine($"A nagyobb a két szám közül a(z) {Math.Max(num1, num2)}");
        }
        /// <summary>
        /// Írj programot, amely meghatározza a két szám viszonyát!
        /// </summary>
        public static void Fel29()
        {
            double num1 = TryInput<double>("Adja meg az első számot: ");
            double num2 = TryInput<double>("Adja meg az első számot: ");
            Console.WriteLine($"A két szám viszonya: {(num1 == num2 ? "A két szám egyenlő." : (num1 > num2 ? $"{num1} nagyobb" : $"{num1} kisebb"))}{(num1 != num2 ? $", mint {num2}" : "")}");
        }
        /// <summary>
        /// Olvassunk be 4 db számot! Adjuk meg a legnagyobbat! (Ne használj beépített függvényt!)
        /// </summary>
        public static void Fel30()
        {
            double num1 = TryInput<double>("Adja meg az első számot: ");
            double num2 = TryInput<double>("Adja meg a második számot: ");
            double num3 = TryInput<double>("Adja meg a harmadik számot: ");
            double num4 = TryInput<double>("Adja meg a negyedik számot: ");
            double biggest = num1;
            if (biggest < num2) biggest = num2;
            if (biggest < num3) biggest = num3;
            if (biggest < num4) biggest = num4;
            Console.WriteLine($"{biggest} a legnagyobb szám");
        }
        /// <summary>
        /// Írj programot, amely egy beolvasott tanulmányi átlag alapján eldönti, hogy tanuló jeles, jó közepes vagy elégséges rendű átlaggal rendelkezik!
        /// </summary>
        public static void Fel31()
        {
            float atlag = TryInput<float>("Adjon meg egy tanulmányi átlagot: ");
            string[] jegyek = new string[] { "Elégtelen", "Elégséges", "Közepes", "Jó", "Jeles" };
            if (atlag < 1.60)
            {
                Console.WriteLine("A diák {0} osztályzatot kapott.", jegyek[0]);
            }
            else
            {
                Console.WriteLine("A diák {0} osztályzatot kapott.", jegyek[Convert.ToByte(Math.Round(atlag - 1))]);
            }
        }
        /// <summary>
        /// Olvassuk be egy tanuló osztályzatait, a szakmai tantárgyakból (webszerkesztés, programozás, hálózat, IKT projekt). Határozzuk meg az átlagát a tanulónak és írjuk ki, szöveggel, hogy milyen rendű!
        /// </summary>
        public static void Fel32()
        {
            Console.WriteLine("Adja meg az osztályzatokat a következő tantárgyakból: ");
            int websz = TryInput<int>("Webszerkesztés: ", x => x >= 1 && x <= 5);
            int prog = TryInput<int>("Programozás: ", x => x >= 1 && x <= 5);
            int halo = TryInput<int>("Hálózati: ", x => x >= 1 && x <= 5);
            int ikt = TryInput<int>("IKT Projekt: ", x => x >= 1 && x <= 5);
            string[] jegyek = new string[] { "Elégtelen", "Elégséges", "Közepes", "Jó", "Jeles" };
            Console.WriteLine((websz == 1 || prog == 1 || ikt == 1 || halo == 1) ? "A tanuló megbukott" : $"A tanuló átlaga: {(websz + prog + halo + ikt) / 4}\n\n\tWebszerkesztés: {jegyek[websz - 1]}\n\tProgramozás: {jegyek[prog - 1]}\n\tHálózati: {jegyek[halo - 1]}\n\tIKT Projekt: {jegyek[ikt - 1]}");
        }
        /// <summary>
        /// Adott két különböző kétjegyű szám. Írassuk ki azt a kétjegyűt, amelynek számjegyeinek összege nagyobb!
        /// </summary>
        public static void Fel33()
        {
            int num1 = TryInput<int>("Adja meg az első kétjegyű egész számot: ", x => x < 100 && x >= 10);
            int num2 = TryInput<int>("Adja meg a második kétjegyű egész számot: ", x => x < 100 && x >= 10);
            int num1_o = num1 % 10 + num1 / 10;
            int num2_o = num2 % 10 + num2 / 10;
            Console.WriteLine($"A{(num1_o > num2_o ? "z első":" második")} szám számjegyeinek összege a nagyobb. ({num1_o} {(num1_o > num2_o ? ">":"<")} {num2_o})");
        }
        /// <summary>
        /// Adott négy db egész szám, adjuk meg, a párosak összegét!
        /// </summary>
        public static void Fel34()
        {
            List<int> paros = new List<int> { TryInput<int>("1. Szám:"), TryInput<int>("2. Szám:"), TryInput<int>("3. Szám:"), TryInput<int>("4. Szám:") };
            Console.WriteLine("Az adott számok közül a párosak összege {0}", paros.FindAll(x => x % 2 == 0).Sum());
        }
        /// <summary>
        /// Adott négy db egész szám, határozzuk meg a 3-mal osztható számok számtani közepét!
        /// </summary>
        public static void Fel35()
        {
            List<int> oszt_3 = new List<int> { TryInput<int>("1. Szám:"), TryInput<int>("2. Szám:"), TryInput<int>("3. Szám:"), TryInput<int>("4. Szám:") };
            oszt_3 = oszt_3.FindAll(x => x % 3 == 0);
            Console.WriteLine("A hárommal osztható számok számtani közepe (átlaga): {0}", oszt_3.Sum() / Convert.ToDouble(oszt_3.Count()));
        }
        /// <summary>
        /// Adott 3 db egész szám, adjuk össze a kétjegyűeket!
        /// </summary>
        public static void Fel36()
        {
            int[] ketjegyu = new int[] { TryInput<int>("1. Szám:"), TryInput<int>("2. Szám:"), TryInput<int>("3. Szám:"), TryInput<int>("4. Szám:") };
            Console.WriteLine("A kétjegyűek összege: {0}", ketjegyu.ToList().FindAll(x => x < 100 && x >= 10).Sum());
        }
        /// <summary>
        /// Adott egy négyjegyű szám! Határozzuk meg a legnagyobb számjegyének és a másik 3 összegének hányadosát!
        /// </summary>
        public static void Fel37()
        {
            int num = TryInput<int>("Adjon meg egy négyjegyű számot: ", x => x >= 1000 && x < 10000);
            List<int> szamjegyek = new List<int> { num / 1000, num / 100 % 10, num / 10 % 10, num % 10 };
            int legnagyobb = szamjegyek.Max();
            szamjegyek.Remove(legnagyobb);
            Console.WriteLine("{0}, {1}, {2}, legnagyobb: {3}", szamjegyek[0], szamjegyek[1], szamjegyek[2], legnagyobb);
            double hanyados = Convert.ToDouble(legnagyobb) / szamjegyek.Sum();
            Console.WriteLine("A legnagyobb számjegy és a másik 3 összegének hányadosa: {0} ({1}/{2})", hanyados, legnagyobb, szamjegyek.Sum());
        }
        /// <summary>
        /// Írj programot, amely generál egy véletlen háromjegyű számot, majd képezd ennek a számnak a számjegyei segítségével a legnagyobb háromjegyűt!
        /// </summary>
        public static void Fel38()
        {
            Random rnd = new Random();
            int num = rnd.Next(100, 1000);
            List<int> szamjegyek = new List<int> { num / 100 % 10, num / 10 % 10, num % 10 };
            int legnagyobb = szamjegyek.Max();
            szamjegyek.Remove(legnagyobb);
            int legkisebb = szamjegyek.Min();
            szamjegyek.Remove(legkisebb);
            int legn_haromjegy = legnagyobb * 100 + szamjegyek[0] * 10 + legkisebb;
            Console.WriteLine("Legnagyobb képezhető számjegy {0}-ből: {1}", num, legn_haromjegy);
        }
        /// <summary>
        /// Írj programot, amely beolvas egy hónap sorszámát és megadja ezek alapján, hogy az adott hónap hány napos! Tekintsük úgy, hogy csak[1..12] intervallumból adhatunk meg adatokat!
        /// </summary>
        public static void Fel39()
        {
            byte ho = TryInput<byte>("Adja meg a hónap sorszámát: ", x => x > 0 && x <= 12);
            byte[] honap_31 = new byte[] { 1, 3, 5, 7, 8, 10, 12 };
            Console.WriteLine($"A hónap {(honap_31.Where(x => x == ho).Count() != 0 ? "31":(ho == 2 ? "28 vagy 29":"30"))} napos");
        }
        /// <summary>
        /// Írj programot, amely beolvas egy évszámot és egy hónap sorszámát és megadja ezek alapján, hogy az adott hónap hány napos! Tekintsük úgy, hogy csak[1..12] intervallumból adhatunk meg adatokat! (Figyelj a szökőévre!)
        /// </summary>
        public static void Fel40()
        {
            DateTime date = TryInput<DateTime>("Adja meg az évet és hónapot év.hó formátumban: ");
            byte[] honap_31 = new byte[] { 1, 3, 5, 7, 8, 10, 12 };
            Console.WriteLine($"A hónap {(honap_31.Where(x => x == Convert.ToByte(date.Month)).Count() != 0 ? "31" : (date.Month == 2 ? ((date.Year % 4 == 0 && (date.Year % 100 == 0 && date.Year % 400 == 0)) ? "29" : "28") : "30"))} napos");
        }
        /// <summary>
        /// Olvass be egy dátumot (év, hónap, nap)! Írj programot, amely kiírja a rákövetkező napot, év.hónap.nap formában!
        /// </summary>
        public static void Fel41()
        {
            DateTime date = TryInput<DateTime>("Adjon meg egy dátumot év.hó.nap formátumban: ").AddDays(1);
            Console.WriteLine($"A rákövetkező nap: {date.Date}");
        }
        /// <summary>
        /// Olvass be egy dátumot (év, hónap, nap)! Írj programot, amely kiírja megelőző napot, év.hónap.nap formában!
        /// </summary>
        public static void Fel42()
        {
            DateTime date = TryInput<DateTime>("Adjon meg egy dátumot év.hó.nap formátumban: ").Subtract();

            Console.Write("Adjon meg egy dátumot év.hó.nap formátumban: ");
            string[] datum = Console.ReadLine().Trim().Split('.');
            int ev = int.Parse(datum[0]);
            int ho = int.Parse(datum[1]);
            int nap = int.Parse(datum[2]) - 1;
            int[] honap31 = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            if (nap == 0)
            {
                ho -= 1;
                if (ho == 0)
                {
                    ho = 12;
                    ev -= 1;
                }
                if (honap31.Contains(ho)) nap = 31;
                else if (ho == 2) nap = 28;
                else nap = 30;
            }
            Console.WriteLine("A megelőző nap: {0}.{1}.{2}", ev, ho, nap);
        }
        /// <summary>
        /// Olvassunk be két dátumot ponttal elválasztva! Határozzuk meg, melyik a korábbi!
        /// </summary>
        public static void Fel43()
        {
            Console.Write("Adjon meg két dátumot, év,hó,nap.év,hó,nap formátumban: ");
            string[] datum = Console.ReadLine().Split('.');
            if (datum.Length != 2)
            {
                Console.WriteLine("Nem kettő dátum.");
                return;
            }
            var tmp = datum[0].Split(',');
            if (tmp.Length != 3)
            {
                Console.WriteLine("Nem megfelelő hosszúságú a dátum.");
            }
            List<int> datum1 = new List<int> {int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2])};
            tmp = datum[1].Split(',');
            if (tmp.Length != 3)
            {
                Console.WriteLine("Nem megfelelő hosszúságú a dátum.");
            }
            List<int> datum2 = new List<int> { int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2]) };
            if (datum1[0] == datum2[0] && datum1[1] == datum2[1] && datum1[2] == datum2[2])
            {
                Console.WriteLine("A kettő dátum ugyanaz.");
            }
            else if (datum1[0]==datum2[0])
            {
                if (datum1[1] == datum2[1])
                {
                    if (datum1[2] > datum2[2])
                    {
                        Console.WriteLine("{0}.{1,2}.{2} a korábbi dátum.", datum2[0], datum2[1], datum2[2]);
                    }
                    else
                    {
                        Console.WriteLine("{0}.{1,2}.{2} a korábbi dátum.", datum1[0], datum1[1], datum1[2]);
                    }
                }
                else if (datum1[1] > datum2[1])
                {
                    Console.WriteLine("{0}.{1,2}.{2} a korábbi dátum.", datum2[0], datum2[1], datum2[2]);
                }
                else
                {
                    Console.WriteLine("{0}.{1,2}.{2} a korábbi dátum.", datum1[0], datum1[1], datum1[2]);
                }
            }
            else if (datum1[0] > datum2[0])
            {
                Console.WriteLine("{0}.{1,2}.{2} a korábbi dátum.", datum2[0], datum2[1], datum2[2]);
            }
            else
            {
                Console.WriteLine("{0}.{1,2}.{2} a korábbi dátum.", datum1[0], datum1[1], datum1[2]);
            }
        }
        /// <summary>
        /// Olvassunk be egy dátumot és határozzuk meg a helyességét!
        /// </summary>
        public static void Fel44()
        {
            Console.Write("Adjon meg egy dátumot: ");
            string datum = Console.ReadLine();
            if (DateTime.TryParse(datum, out DateTime result))
            {
                Console.WriteLine("A dátum helyes.");
            }
            else
            {
                Console.WriteLine("A dátum nem helyes.");
            }
        }
        /// <summary>
        /// Írj függvényt, amely kiszámolja egy adott „a” oldalú négyzet kerületét és területét!
        /// </summary>
        public static void Fel47()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel48()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel49()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel50()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel51()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel52()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel53()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel54()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel55()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel56()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel57()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel58()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel59()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Fel60()
        {
            throw new NotImplementedException();
        }
    }
}
