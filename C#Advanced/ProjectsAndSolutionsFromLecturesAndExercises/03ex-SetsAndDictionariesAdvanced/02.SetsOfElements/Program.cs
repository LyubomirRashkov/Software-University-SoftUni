using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] countOfInputs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int countOfInputsForTheFirstSet = countOfInputs[0];
            int countOfInputsForTheSecondSet = countOfInputs[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < countOfInputsForTheFirstSet; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                firstSet.Add(currentNumber);
            }

            for (int i = 0; i < countOfInputsForTheSecondSet; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                secondSet.Add(currentNumber);
            }

            List<int> repeatingNumbers = firstSet.Intersect(secondSet).ToList();

            Console.WriteLine(string.Join(' ', repeatingNumbers));
        }
    }
}
