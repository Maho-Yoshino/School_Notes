using System;
using System.Linq;

namespace lotto
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            byte[] usedNumbers = new byte[5];
            byte[] winningNumbers = new byte[5];
            byte i;
            for (i=0; i < 5; i++)
            {
                byte num = 91;
                do
                {
                    Console.Write($"Adja meg a {i + 1}. számot: ");
                    try
                    {
                        num = byte.Parse(Console.ReadLine() ?? "");
                    }
                    catch
                    {
                        Console.WriteLine("A megadott adat nem egész szám (vagy túl nagy)");
                    }
                    if (num < 1 || num > 90)
                    {
                        Console.WriteLine("A megadott szám nem felel meg a feltételeknek ([1..90] intervallum)");
                    }
                    else if (usedNumbers.Contains(num))
                    {
                        Console.WriteLine("A megadott szám nem felel meg a feltételeknek (Különböző számok)");
                    }
                    else
                    {
                        usedNumbers[i] = num;
                    }
                }
                while (num < 1 && num > 90 && !usedNumbers.Contains(num));
            }
            for (i=0; i<5;i++)
            {
                do
                {
                    byte rnd_num = Convert.ToByte(rnd.Next(1, 91));
                    if (winningNumbers.Contains(rnd_num)) {continue;}
                    winningNumbers[i] = rnd_num;
                    i++;
                }
                while (winningNumbers[4] == 0);
            }
            if (winningNumbers.Intersect(usedNumbers).Count() == 0)
            {
                Console.WriteLine("Sajnálom, nem talált el egyet sem!");
            }
            else
            {
                Console.WriteLine($"Gratulálok önnek {winningNumbers.Intersect(usedNumbers).Count()} találata van!");
            }
            Console.WriteLine($"Az ön számai:\t{string.Join(' ', usedNumbers).PadLeft(15)}");
            Console.WriteLine($"Nyertes számok:\t{string.Join(' ', winningNumbers).PadLeft(15)}");
            Console.ReadLine();
        }
    }
}