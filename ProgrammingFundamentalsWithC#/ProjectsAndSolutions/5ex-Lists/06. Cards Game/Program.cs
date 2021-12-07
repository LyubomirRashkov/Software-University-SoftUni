using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (firstList.Count == 0 || secondList.Count == 0)
                {
                    break;
                }

                if (firstList[0] > secondList[0])
                {
                    int biggerNumber = firstList[0];
                    int smallerNumber = secondList[0];

                    firstList.RemoveAt(0);
                    firstList.Add(biggerNumber);
                    firstList.Add(smallerNumber);

                    secondList.RemoveAt(0);
                }
                else if (secondList[0] > firstList[0])
                {
                    int biggerNumber = secondList[0];
                    int smallerNumber = firstList[0];

                    secondList.RemoveAt(0);
                    secondList.Add(biggerNumber);
                    secondList.Add(smallerNumber);

                    firstList.RemoveAt(0);
                }
                else
                {
                    firstList.RemoveAt(0);
                    secondList.RemoveAt(0);
                }
            }

            if (firstList.Count == 0)
            {
                int sum = GetSum(secondList);

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            else if (secondList.Count == 0)
            {
                int sum = GetSum(firstList);

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
        }

        private static int GetSum(List<int> winningList)
        {
            int sum = 0;

            foreach (int number in winningList)
            {
                sum += number;
            }

            return sum;
        }
    }
}
