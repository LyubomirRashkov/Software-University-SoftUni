using System;
using System.Linq;

namespace Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(inputNumbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
