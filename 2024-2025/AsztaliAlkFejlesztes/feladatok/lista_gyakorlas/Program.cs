using System;
using System.Linq;
using System.Collections.Generic;

namespace lista_gyakorlas
{
    class Program
    {
        private static string Input(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        private static bool NoFilter<G>(G item) => true;
        private static T TryInput<T>(string text, Func<T, bool> predicate = null)
        {
            predicate ??= NoFilter;
            while (true)
            {
                try
                {
                    T[] N = new T[1] { (T)Convert.ChangeType(Input(text).Replace('.', ','), typeof(T)) };
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
            int feladat = TryInput<int>("Adja meg a feladat számát: ", x => x <= 2);
            typeof(Program).GetMethod($"Fel{feladat}").Invoke(null, null);
            Console.ReadKey();
        }
        /// <summary>
        /// Írjunk programot, amely egy véletlen számokkal feltöltött tömbből listába kiválogatja a páros számokat!
        /// </summary>
        public static void Fel1()
        {
            int[] numbers = NewArray<int>(TryInput<int>("Hány számot generáljak? ", x => x > 0), random: true, min: 1, max: 101);
            Console.WriteLine($"A generált számok az alábbiak: {string.Join(", ", numbers)}");
            List<int> kivalogatott = numbers.Where(x => x % 2 == 0).ToList();
            Console.WriteLine($"\nA kiválogatott elemek listája: {string.Join(", ", kivalogatott)}");
        }
        /// <summary>
        /// Menükezelés listával
        /// </summary>
        public static void Fel2()
        {
            int muvelet = 1;
            List<string> nevsor = new List<string>() {"Horváth Elek", "Fehér Zoltán", "Jánosi Tibor", "Szekeres Róbert", "Major András"};
            do
            {
                Console.WriteLine();
                muvelet = TryInput<int>("Az osztálynévsorral végezhető műveletek\n"
                                        + "\t0    Kilépés\n"
                                        + "\t1    Névsor kiiratása\n"
                                        + "\t2    Új tanuló felvétele\n"
                                        + "\t3    Diák törlése a névsorból\n>", x => x <= 3 && x >= 0);
                Console.Clear();
                switch (muvelet)
                {
                    case 0: //Kilépés
                        break;
                    case 1: //Névsor kiiratása
                        Console.WriteLine(string.Join("\n", nevsor));
                        Input("A folytatáshoz üss Enter-t.");
                        break;
                    case 2: //Új tanuló felvétele
                        nevsor.Add(Input("Kérem az új tanuló nevét\n"));
                        nevsor.Sort();
                        Console.Clear();
                        break;
                    case 3: //Diák törlése a névsorból
                        nevsor.Remove(Input("Kit kell törölni?\n"));
                        nevsor.Sort();
                        Console.Clear();
                        break;
                }
                Console.Clear();
            }
            while (muvelet != 0);
            Console.ReadKey();
        }
    }
}
