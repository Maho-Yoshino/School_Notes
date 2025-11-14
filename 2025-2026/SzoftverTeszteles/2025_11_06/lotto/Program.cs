using System;
using System.Linq;

namespace lotto
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"-========= Lottó program ==========-\r\n-= Készítette: Molek Tamás Sándor =-\r\n-==================================-");
            Console.WriteLine();
            Random rnd = new Random();
            byte[] usedNumbers = new byte[5];
            byte[] winningNumbers = new byte[5];
            byte i = 0;
            Console.WriteLine("Kérem a tippjeit!");
            do
            {
                byte num = 91;
                Console.Write($"Adja meg a {i + 1}. számot: ");
                try
                {
                    num = byte.Parse(Console.ReadLine() ?? "");
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("A megadott adat nem felel meg a feltételeknek ([1..90] intervallum)");
                    continue;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("A megadott adat nem egész szám (vagy nem szám).");
                    continue;
                }
                if (num < 1 || num > 90)
                {
                    Console.WriteLine("A megadott szám nem felel meg a feltételeknek ([1..90] intervallum).");
                }
                else if (usedNumbers.Contains(num))
                {
                    Console.WriteLine("A megadott szám nem felel meg a feltételeknek (Különböző számok).");
                }
                else
                {
                    usedNumbers[i] = num;
                    i++;
                }
            }
            while (i < 5);
            i = 0;
            do
            {
                byte rnd_num = Convert.ToByte(rnd.Next(1, 91));
                if (winningNumbers.Contains(rnd_num)) {continue;}
                winningNumbers[i] = rnd_num;
                i++;
            }
            while (i < 5);
            Console.WriteLine($"|{new string('-', 20 + 5 * 5)}|");
            Console.WriteLine($"|{CenterText(winningNumbers.Intersect(usedNumbers).Count() == 0 ? "Sajnálom, nem talált el egyet sem!" : $"Gratulálok önnek {winningNumbers.Intersect(usedNumbers).Count()} találata van!", 20+5*5)}|");
            Console.WriteLine($"|{new string('-', 20 + 5 * 5)}|");
            Console.WriteLine($"|{CenterText("Az ön számai", 20)}|{string.Join('|', usedNumbers.ToList().ConvertAll(x => Convert.ToString(x).PadLeft(3, ' ').PadRight(4, ' ')))}|");
            Console.WriteLine($"|{CenterText("A nyertes számok", 20)}|{string.Join('|', winningNumbers.ToList().ConvertAll(x => Convert.ToString(x).PadLeft(3, ' ').PadRight(4, ' ')))}|");
            Console.WriteLine($"|{new string('-', 20 + 5 * 5)}|");
            Console.WriteLine("Nyomja meg akármelyik gombot a kilépéshez...");
            Console.ReadKey();
        }
        static string CenterText(string text, int width)
        {
            if (string.IsNullOrEmpty(text) || text.Length >= width)
                return text;

            int leftPadding = (width - text.Length) / 2;
            int rightPadding = width - text.Length - leftPadding;
            return new string(' ', leftPadding) + text + new string(' ', rightPadding);

        }
    }
}