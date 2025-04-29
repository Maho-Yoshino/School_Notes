using System;

namespace metodus_gyakorlo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Feladat száma (1-3):");
            bool success = int.TryParse(Console.ReadLine(), out int fel);
            while (!success || fel < 1 || fel > 4)
            {
                Console.Write("\nFeladat száma (1-3):");
                success = int.TryParse(Console.ReadLine(), out fel);
            }
            switch (fel)
            {
                case 1:
                    typeof(Fel1).GetMethod("Rendezo").Invoke(null, null);
                    break;
                case 2:
                    typeof(Fel2).GetMethod("Program").Invoke(null, null);
                    break;
                case 3:
                    typeof(Fel3).GetMethod("Program").Invoke(null, null);
                    break;
            }
        }
    }
    class Fel1 : Program
    {
        private const int N = 30;
        static int[] A = new int[N];
        public static void Rendezo()
        {
            Generalas();
            Kiir();
            BeillesztRendez();
            Kiir();
            Console.ReadKey();
        }
        private static void Kiir()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();
        }
        private static void BeillesztRendez()
        {
            int i, j, x;
            for (i = 1; i < N; i++)
            {
                j = i - 1;
                x = A[i];
                while (j > -1 && x < A[j])
                {
                    A[j + 1] = A[j];
                    j--;
                }
                A[j + 1] = x;
            }
        }
        private static void Generalas()
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                A[i] = rnd.Next(-50, 51);
            }
        }
    }
    class Fel2 : Program
    {
        private const int max = 30;
        private static int N;
        static int[] A = new int[max];
        private static void Beolvas()
        {
            int i = 0, j;
            bool success;
            success = int.TryParse(Console.ReadLine(), out int kovetkezo);
            while (!success)
            {
                success = int.TryParse(Console.ReadLine(), out kovetkezo);
            }
            while (kovetkezo > 0 && i < max)
            {
                j = i - 1;
                while (j > -1 && kovetkezo < A[j])
                {
                    A[j + 1] = A[j];
                    j--;
                }
                A[j + 1] = kovetkezo;
                i++; 
                if (i < max)
                {
                    success = int.TryParse(Console.ReadLine(), out kovetkezo);
                    while (!success)
                    {
                        success = int.TryParse(Console.ReadLine(), out kovetkezo);
                    }
                }
            }
            N = i;
        }
        private static void Kiir()
        {
            int i;
            for (i = 0; i < N; i++)
            {
                Console.WriteLine($"{A[i]} {(A[i] % 2 == 0 ? "(páros)" : "(páratlan)")}");
            }
        }
        public static void Program()
        {
            Beolvas();
            Kiir();
        }
    }
    class Fel3 : Program
    {
        private const int N = 10;
        private static int[] A = new int[N];
        private static void TombBeker()
        {
            for (int i = 0; i < N; i++)
            {
                bool success = int.TryParse(Console.ReadLine(), out int tmp);
                while (!success)
                {
                    success = int.TryParse(Console.ReadLine(), out tmp);
                }
                A[i] = tmp;
            }
        }
        private static void OrgonaRendez()
        {
            int i, j = 0, k = N-1, l, ind, s;
            for (i = 0; i < N; i++)
            {
                ind = j;
                for (l = j+1; l < k; l++)
                {
                    if (A[l]<A[ind])
                    {
                        ind = l;
                    }
                }
                s = A[ind];
                if (i%2==0)
                {
                    A[ind] = A[j];
                    A[j] = s;
                    j++;
                }
                else
                {
                    A[ind] = A[k];
                    A[k] = s;
                    k--;
                }
            }
        }
        private static void TombKiir()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write($"{A[i]} ");
            }
        }
        public static void Program()
        {
            TombBeker();
            OrgonaRendez();
            TombKiir();
            Console.ReadKey();
        }
    }
}
