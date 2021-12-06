using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
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

            List<int> result = new List<int>(firstList.Count + secondList.Count);

            for (int i = 0; i < Math.Min(firstList.Count, secondList.Count); i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[i]);
            }

            List<int> remainingElements = new List<int>((Math.Max(firstList.Count, secondList.Count)) - (Math.Min(firstList.Count, secondList.Count)));

            if (firstList.Count > secondList.Count)
            {
                remainingElements.AddRange(GetRemainingElements(firstList, secondList));
            }
            else
            {
                remainingElements.AddRange(GetRemainingElements(secondList, firstList));
            }

            result.AddRange(remainingElements);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> GetRemainingElements(List<int> longerList, List<int> shorterList)
        {
            List<int> remainingElements = new List<int>(longerList.Count - shorterList.Count);

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                remainingElements.Add(longerList[i]);
            }

            return remainingElements;
        }
    }
}
