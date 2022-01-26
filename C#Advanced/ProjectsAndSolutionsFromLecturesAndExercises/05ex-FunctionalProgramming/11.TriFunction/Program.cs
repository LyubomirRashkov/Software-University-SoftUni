using System;
using System.Linq;

namespace _11.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isValid = (name, sum) => name.ToCharArray().Select(curChar => (int)curChar).Sum() >= targetSum;

            Func<string[], int, Func<string, int, bool>, string> targetName = (collection, sum, func) => collection.FirstOrDefault(name => func(name, sum));

            string specialName = targetName(names, targetSum, isValid);

            Console.WriteLine(specialName);
        }
    }
}
