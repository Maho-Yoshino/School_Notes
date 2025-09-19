using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace erettegi_fel_emelt_1
{
    internal class Program
    {
        private static bool NoFilter<G>(G item) => true;
        static private string Input(string txt)
        {
            Console.Write(txt);
            return Console.ReadLine();
        }
        static private T TryInput<T>(string txt, Func<T, bool> predicate = null)
        {
            predicate = predicate == null ? NoFilter : predicate;
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
        static void Main(string[] args)
        {
            int feladat_num = int.Parse(Console.ReadLine());
            switch (TryInput<byte>("Melyik feladatot kéri? (2, 3): ", x=> x>=2 && x<=3))
            {
                case 2:
                    Console.Clear();
                    Fel2();
                    break;
                case 3:
                    Console.Clear();
                    Fel3();
                    break;
            }
            Console.Write("\n<Program vége>");
            Console.ReadLine();
        }
        static void Fel2() {
            const int N = 20;
            int[] A = new int[N];
            void Feltolt()
            {
                Random rnd = new Random();
                for (int i = 0; i < N; i++)
                {
                    A[i] = rnd.Next(2, 1001);
                }
            }
            void Kiir()
            {
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine(A[i]);
                }
            }
            bool Prim(int _A)
            {
                int I = 2;
                while (I <= Math.Sqrt(_A) && (_A%I!=0))
                {
                    I++;
                }
                return !(I <= Math.Sqrt(_A));
            }
            void PrimPakol()
            {
                int E = 0;
                int V = N - 1;
                int S = A[0];
                while (E<V)
                {
                    while (E<V && !(Prim(A[V])))
                    {
                        V -= 1;
                    }
                    if (E<V)
                    {
                        A[E] = A[V];
                        E++;
                        while (E<V && Prim(A[E]))
                        {
                            E++;
                        }
                        if (E<V)
                        {
                            A[V] = A[E];
                            V--;
                        }
                    }
                }
                A[E] = S;
            }
            void Sub_Main()
            {
                Feltolt();
                Kiir();
                PrimPakol();
                Kiir();
            }
            Sub_Main();
        }
        public class cFel3
        {
            public struct Point
            {
                public int x;
                public int y;
                public bool SequenceEqual(Point a)
                {
                    return x==a.x && y==a.y;
                }
            }
            public byte[] rgb;
            public Point start_pos, end_pos;
            public double SzakaszLength => Math.Sqrt((start_pos.x - end_pos.x) ^ 2 + (start_pos.y - end_pos.y) ^ 2);
            public cFel3(string tmp)
            {
                byte[] line = tmp.Split(';').ToList().ConvertAll(x => byte.Parse(x)).ToArray();
                start_pos = new Point { x=line[0], y=line[1] };
                end_pos = new Point { x=line[2], y=line[3] };
                rgb = new byte[] { line[4], line[5], line[6] };
            }
            public bool IsMirror(cFel3 a, int[] CanvasSize)
            {
                return (a.start_pos.y == start_pos.y && a.end_pos.y == end_pos.y &&
                    (a.start_pos.x == (CanvasSize[0] - 1 - start_pos.x)) &&
                    (a.end_pos.x == (CanvasSize[0] - 1 - end_pos.x)));
            }
            public bool IsVertMirror(cFel3 a, int[] CanvasSize)
            {
                return (a.start_pos.x == start_pos.x && a.end_pos.x == end_pos.x &&
                    (a.start_pos.y == (CanvasSize[0] - 1 - start_pos.y)) &&
                    (a.end_pos.y == (CanvasSize[0] - 1 - end_pos.y)));
            }
        }
        static void Fel3()
        {
            string[] lines = File.ReadAllLines(Input("Adja meg a fájl nevét: "));
            int[] sizes = lines[0].Split(';').ToList().ConvertAll(x => int.Parse(x)).ToArray();
            cFel3[] adat = new cFel3[lines.Length - 1];
            for (int i = 0; i < lines.Length-1; i++)
            {
                adat[i] = new cFel3(lines[i + 1]);
            }
            // B feladat
            Console.WriteLine($"B feladat: {adat.Count(sor => sor.rgb.SequenceEqual(adat[0].rgb) && sor.IsMirror(adat[0], sizes))}");
            List<cFel3> erintkezo_szakaszok = new List<cFel3>();
            // D feladat
            cFel3 leghosszabb = adat.Where(x => x.rgb.Count(y => y == 255) == 1 && x.rgb.Count(y => y == 0) == 2).OrderBy(x => x.SzakaszLength).ToArray()[0];
            foreach (cFel3 sor in adat)
            {
                if (adat.Any(x => x.start_pos.SequenceEqual(sor.start_pos) || x.start_pos.SequenceEqual(sor.end_pos) || x.end_pos.SequenceEqual(sor.start_pos) || x.end_pos.SequenceEqual(sor.end_pos)) && !erintkezo_szakaszok.Contains(sor))
                {

                }
            }
        }
    }
}
