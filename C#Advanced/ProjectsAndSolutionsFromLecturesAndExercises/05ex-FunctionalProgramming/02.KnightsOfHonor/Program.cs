using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = str => Console.WriteLine($"Sir {str}");

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}
