using System;
using System.Linq;

namespace lotto
{
    internal class Program
    {
        public static T TryInput<T>(string text, Func<T, bool> predicate)
        {
            static bool NoFilter<G>(G item) => true;
            predicate = predicate == null ? NoFilter : predicate;
            while (true)
            {
                try
                {
                    Console.Write(text);
                    T[] tmp = new T[1] { (T)Convert.ChangeType((Console.ReadLine() ?? "").Replace('.', ','), typeof(T)) };
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
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            byte[] usedNumbers = new byte[5];
            byte[] winningNumbers = new byte[5];
            byte i;
            for (i=0; i < 5; i++)
            {
                usedNumbers[i] = TryInput<byte>($"Adja meg a {i+1}. számot: ", x=>x>=1&&x<=90);
            }
            for (i=0; i<5;i++)
            {
                do
                {
                    byte rnd_num = Convert.ToByte(rnd.Next(1, 90));
                    if (winningNumbers.Contains(rnd_num))
                    {
                        continue;
                    }
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