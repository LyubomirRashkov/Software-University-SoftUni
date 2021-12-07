using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<int> result = new List<int>();

            for (int i = arrays.Count - 1; i >= 0; i--)
            {
                List<int> elements = arrays[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                result.AddRange(elements);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
