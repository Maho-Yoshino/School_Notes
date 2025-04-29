using System;

namespace fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hány elemig adjam meg a fibonacci sorozatot? ");
            int N = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 1;
            Console.Write($"{a} {b} ");
            for (int i = 0; i < N; i++)
            {
                int c = a + b;
                Console.Write($"{c} ");
                if (a<b) {a = c;}
                else { b = c; }
            }
        }
    }
}
