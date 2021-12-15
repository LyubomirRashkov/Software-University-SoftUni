using System;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sortedNumbers = (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .ToArray());

            int count = sortedNumbers.Length > 3 ? 3 : sortedNumbers.Length;

            for (int i = 0; i < count; i++)
            {
                Console.Write(sortedNumbers[i] + " ");
            }
        }
    }
}
