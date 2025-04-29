using System;
using System.Text.RegularExpressions;

namespace regex_testing_2024_11_22
{
    class Program
    {
        private Regex rgx = new Regex("[\\D]");
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            Console.WriteLine(ConvertToInt(num));
            Console.ReadKey();
        }
        static double ConvertToFloat(string input) {
            input = input.Replace(',', '.');
            string[] input_arr = input.Split('.');
            string output_str = rgx.Replace(input_arr[0], "");
            if (input_arr.Length == 2)
            {
                output_str += "." + rgx.Replace(input_arr[1], "");
            }
            return int.Parse(output_str);
        }
        static int ConvertToInt(string input)
        {
            return int.Parse(new Regex("[\\D]").Replace(input, ""));
        }
    }
}
