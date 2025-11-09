using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SudokuCLI
{
    class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }
        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }
        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    };
    internal class Program
    {
        public static T TryInput<T>(string text, Func<T, bool> predicate = null)
        {
            static bool NoFilter<G>(G item) => true;
            predicate = predicate == null ? NoFilter : predicate;
            while (true)
            {
                try
                {
                    Console.Write(text);
                    T[] tmp = new T[1] { (T)Convert.ChangeType(Console.ReadLine().Replace('.',','), typeof(T)) };
                    if (tmp.Any(predicate))
                    {
                        return tmp[0];
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
        public static string Input(string text, string EoL = "\n")
        {
            Console.Write(text + EoL);
            return Console.ReadLine() ?? "";
        }
        public static void Main(string[] args)
        {
            Feladvany[] feladvanyok = File.ReadAllLines("feladvany_sudoku.txt").ToList().ConvertAll(x => new Feladvany(x)).ToArray();
            // 3. Feladat
            Console.WriteLine($"3. feladat: Beolvasva {feladvanyok.Length} feladvány");
            // 4. Feladat
            int meret = TryInput<int>("\n4. feladat: Kérem a feladvány méretét [4..9]: ", x => x <= 9 && x >= 4);
            Console.WriteLine($"{meret}x{meret} méretű feladványból {feladvanyok.Count(x => x.Meret == meret)} darab van tárolva");
            // 5. Feladat
            Random rnd = new Random();
            Feladvany[] tmp = feladvanyok.Where(x => x.Meret == meret).ToArray();
            Feladvany rnd_fel = tmp[rnd.Next(0, tmp.Length)-1];
            Console.WriteLine($"\n5. feladat: A kiválasztott feladvány:\n{rnd_fel.Kezdo}");
            // 6. Feladat
            Console.WriteLine($"\n6. feladat: A feladvány kitöltöttsége: {Math.Round(((rnd_fel.Kezdo.Length-rnd_fel.Kezdo.Count(x=>x=='0'))/Convert.ToDouble(rnd_fel.Kezdo.Length))*100)}%");
            // 7. Feladat
            Console.WriteLine("\n7. feladat: A feladvány kirajzolva:");
            rnd_fel.Kirajzol();
            // 8. Feladat
            File.WriteAllLines($"sudoku{meret}.txt", feladvanyok.Where(x=> x.Meret == meret).ToList().ConvertAll(x=>x.Kezdo));
            Console.WriteLine($"\n8. feladat: sudoku{meret}.txt állomány {feladvanyok.Count(x => x.Meret == meret)} darab feladvánnyal létrehozva");
            Console.ReadKey();
        }
    }
}