using System;
using System.Linq;

namespace _05_2.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word.Length % 2 == 0)
                .ToList()
                .ForEach(word => Console.WriteLine(word));
        }
    }
}
