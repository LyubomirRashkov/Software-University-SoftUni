using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintLine(1, i);
            }

            for (int i = (n - 1); i > 0; i--)
            {
                PrintLine(1, i);
            }
        }

        static void PrintLine(int start, int end)
        {
            for (int j = start; j <= end; j++)
            {
                Console.Write($"{j} ");
            }

            Console.WriteLine();
        }
    }
}
