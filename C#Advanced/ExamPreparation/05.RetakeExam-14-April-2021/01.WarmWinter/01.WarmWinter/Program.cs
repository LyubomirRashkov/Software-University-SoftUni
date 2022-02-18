using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray());

            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToArray());

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Pop();
                int currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    sets.Add(currentHat + currentScarf);

                    scarfs.Dequeue();
                }
                else if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();

                    hats.Push(currentHat + 1);
                }
            }

            int mostExpensiveSet = sets.OrderByDescending(s => s).First();

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");

            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
