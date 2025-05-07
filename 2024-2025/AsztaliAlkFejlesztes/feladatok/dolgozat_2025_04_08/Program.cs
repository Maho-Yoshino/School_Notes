using System;
using System.Linq;

namespace dolgozat_2025_04_08
{
    class Program
    {
        private static bool NoFilter<G>(G item) => true;
        public static T TryInput<T>(string text, Func<T, bool> predicate = null)
        {
            predicate ??= NoFilter;
            while (true)
            {
                try
                {
                    T[] tmp = new T[] { (T)Convert.ChangeType(Input(text).Replace('.', ','), typeof(T)) };
                    if (tmp.All(predicate))
                    {
                        return tmp[0];
                    }
                }
                catch
                {
                    Console.WriteLine("Hibás érték megadva.");
                    continue;
                }
            }
        }
        private static string Input(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        static void Main()
        {
            double F = TryInput<double>("Adja meg az autó fogyasztását (l/100km): ");
            double V = TryInput<double>("Adja meg az üzemanyag tartály méretét literben: ");
            double L = TryInput<double>("Adja meg, mennyire messze kíván menni km-ben: ");
            double egy_tank = V * 100 / F;
            Console.WriteLine(egy_tank > L ? "Az út megtehető tankolás nélkül." : "Az út során tankolni kell!");
            Console.ReadKey();
        }
    }
}
