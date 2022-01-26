using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());

            Func<string, int, bool> filter = (str, num) => str.Length <= num;

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(name => filter(name, maxLength))
                .ToArray();

            Console.WriteLine(string.Join('\n', names));
        }
    }
}
