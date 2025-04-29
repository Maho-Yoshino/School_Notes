using System;

namespace dolgozat_2025_02_04
{
    class Program
    {
        private static int N = 20;
        private static int[] A = new int[N];
        private static void Generalas()
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                A[i] = rnd.Next(-100, 101);
            }
        }
        private static void ShellRendezes()
        {
            int D, I, J, X, Y;
            D = 1;
            while (D*2<=N)
            {
                D *= 2;
            }
            D = D - 1;
            do
            {
                I = 0;
                while (I <= D && I + D < N)
                {
                    for (J = I + D; J < N; J = J + D)
                    {
                        X = A[J];
                        Y = J - D;
                        while (Y > -1 && X < A[Y])
                        {
                            A[Y + D] = A[Y];
                            Y = Y - D;
                        }
                        A[Y + D] = X;
                    }
                    I++;
                }
                D /= 2;
            }
            while (D > 0);
        }
        private static void Kiiras()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write($"{A[i]} ");
            }
        }
        static void Main(string[] args)
        {
            Generalas();
            Kiiras();
            ShellRendezes();
            Kiiras();
            Console.ReadKey();
        }
    }
}
