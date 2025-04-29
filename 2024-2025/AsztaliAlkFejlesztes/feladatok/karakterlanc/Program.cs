using System;

namespace karakterlanc
{
    class Program
    {
        static bool equals(string str1, string str2) 
        {
            return string.Compare(str1, str2) == 0;
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            // Comparison
            Console.WriteLine(equals(str, Console.ReadLine()));
            // Replace
            Console.WriteLine(str.Replace(' ', '.'));
            // Insert
            Console.WriteLine(str.Insert(3, "nig-"));
            // Remove
            Console.WriteLine(str.Remove(2, 1));
            // Upper- Lower- cases
            Console.WriteLine(str.ToUpper());
            Console.WriteLine(str.ToLower());
            // Char search
            Console.WriteLine(str.IndexOf('.'));
            // Str search
            Console.WriteLine(str.Contains("kocsi"));
            Console.ReadKey();
        }
    }
}
