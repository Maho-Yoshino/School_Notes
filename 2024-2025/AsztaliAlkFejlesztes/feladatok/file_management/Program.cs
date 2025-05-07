using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace file_management
{
    public class Program
    {
        public static string Input(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        private static bool NoFilter<G>(G item) => true;
        public static T TryInput<T>(string text, Func<T, bool> predicate = null)
        {
            predicate ??= NoFilter;
            while (true)
            {
                try
                {
                    T[] tmp = new T[] { TryConvert<T>(Input(text).Replace('.', ',')) };
                    if (tmp.All(predicate))
                    {
                        return tmp[0];
                    }
                }
                catch
                {
                    Console.WriteLine("Hibás érték.");
                    continue;
                }
            }
        }
        private static T TryConvert<T>(object val)
        {
            return (T)Convert.ChangeType(val, typeof(T));
        }
        public static void DebugPrint<T>(T[] list) => Console.WriteLine(string.Join(", ", list));
        static void Main(string[] args)
        {
            int fel_type = TryInput<int>("Adja meg, milyen feladatot akar (1:Írás, 2:Olvasás): ", x => x <= 2 && x >= 1);
            int fel_num = TryInput<int>("Adja meg, melyik feladatot akarja (1-4): ", x => x >= 1 && x <= (fel_type == 1 ? 4:5));
            Type _class = fel_type == 1 ? typeof(Iras):typeof(Olvasas);
            _class.GetMethod($"Fel{fel_num}").Invoke(null, null);
            Console.WriteLine("Feladat vége.");
            System.Diagnostics.Process.Start("explorer.exe", $"/open, {Path.Combine(Environment.CurrentDirectory)}");
            Console.ReadKey();
        }
    }
    class Olvasas : Program
    {
        public static void Fel1()
        {
            FileStream fs = new FileStream("beolvas.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string s;
            do
            {
                s = sr.ReadLine();
                Console.WriteLine(s);
            }
            while (!sr.EndOfStream);
            sr.Close();
            fs.Close();
        }
        public static void Fel2()
        {
            FileStream fs = new FileStream("adatok05.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int db = int.Parse(sr.ReadLine());
            int[] nums = new int[db];
            nums[0] = int.Parse(sr.ReadLine());
            int max = 0;
            for (int i = 1; i < db; i++)
            {
                nums[i] = int.Parse(sr.ReadLine());
                if (nums[i] > max)
                {
                    max = nums[i];
                }
            }
            sr.Close();
            fs.Close();
            Console.WriteLine($"A legnagyobb beolvasott szám: {max}");
        }
        public static void Fel3()
        {
            FileStream fs = new FileStream("olvasas06.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int db = int.Parse(sr.ReadLine());
            int szam, min = int.MaxValue, pdb = 0;
            for (int i = 0; i < db; i++)
            {
                szam = int.Parse(sr.ReadLine());
                if (szam % 2 == 0)
                {
                    pdb++;
                    if (szam < min)
                    {
                        min = szam;
                    }
                }
            }
            sr.Close();
            fs.Close();
            Console.WriteLine($"{(pdb > 0 ? "A legkisebb" : "Nincs")} páros {(pdb > 0 ? $"beolvasott szám: {min}" : "a beolvasottak között.")}");
        }
        public static void Fel4()
        {
            Console.Clear();
            FileStream fs = new FileStream("adatok.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string src_word = Input("Melyik szót keressem meg? ");
            while (!sr.EndOfStream)
            {
                string tmp = sr.ReadLine();
                string[] tmp_a = tmp.Split(' ');
                for (int i = 0; i < tmp_a.Length; i++)
                {
                    if (tmp_a[i] == src_word)
                    {
                        Console.WriteLine($"A keresett szó megvan itt: \n{tmp}");
                    }
                }
            }
            sr.Close();
            fs.Close();
        }
    }
    class Iras : Program
    {
        public static void Fel1()
        {
            FileStream fs = new FileStream("proba_kiiras.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Ez az első sor");
            sw.Write("Ez a második sor eleje..");
            sw.Write("Ez a második sor folytatása");
            sw.WriteLine("********");
            sw.Close();
            fs.Close();
            Console.WriteLine("A fájl a \"bin\\debug\\proba_kiiras.txt\" helyszínen található");
        }
        public static void Fel2()
        {
            int N = TryInput<int>("Hány számot írjak ki a fájlba? ");
            FileStream fs = new FileStream("szamok_egymasutan.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("A számok egymás mögé kerülnek:");
            for (int i = 1; i <= N; i++)
            {
                sw.Write($"{i}, ");
            }
            sw.Close();
            fs.Close();
        }
        public static void Fel3()
        {
            int N = TryInput<int>("Hány számot írjak egymás alá? ");
            FileStream fs = new FileStream("szamok_egymasala.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("A számok egymás alá kerülnek");
            for (int i = 1; i <= N; i++)
            {
                sw.WriteLine($"{i,2}, ");
            }
            sw.Close();
            fs.Close();
        }
        public static void Fel4()
        {
            int N = TryInput<int>("Hányszor hányas szorzótáblát írjak ki a fájlba? ");
            FileStream fs = new FileStream("szorzotabla.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"Az {N}x{N} szorzótáblát az alábbi táblázat mutatja:");
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    sw.Write($"{i * j,5}");
                }
                sw.WriteLine();
            }
            sw.Close();
            fs.Close();
        }
    }
}
