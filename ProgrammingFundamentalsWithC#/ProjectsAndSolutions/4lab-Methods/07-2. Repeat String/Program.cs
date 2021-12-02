using System;
using System.Text;

namespace _07_2._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(text,n));
        }

        private static string RepeatString(string str, int n)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                result.Append(str);
            }

            return result.ToString();
        }
    }
}
