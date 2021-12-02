using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            RepeatString(text, n);
        }

        private static void RepeatString(string str, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(str);
            }
            Console.WriteLine();
        }
    }
}
