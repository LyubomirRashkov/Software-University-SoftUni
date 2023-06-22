using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.DividingPresents
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			Dictionary<int, int> possibleSums = GetAllPossibleSums(numbers);

			int sum = numbers.Sum();

			int alanSum = sum / 2;

			while (!possibleSums.ContainsKey(alanSum))
			{
				alanSum--;
			}

			List<int> alanSubset = FindSubset(possibleSums, alanSum);

			int bobSum = sum - alanSum;

            Console.WriteLine($"Difference: {bobSum - alanSum}");

			Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");

            Console.WriteLine($"Alan takes: {string.Join(' ', alanSubset)}");

            Console.WriteLine("Bob takes the rest.");
        }

		private static List<int> FindSubset(Dictionary<int, int> possibleSums, int targetSum)
		{
			List<int> subset = new List<int>();

			while (targetSum != 0)
			{
				subset.Add(possibleSums[targetSum]);

				targetSum -= possibleSums[targetSum];
			}

			return subset;
		}

		private static Dictionary<int, int> GetAllPossibleSums(int[] numbers)
		{
			Dictionary<int, int> possibleSums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var number in numbers)
			{
				int[] currentSums = possibleSums.Keys.ToArray();

				foreach (var sum in currentSums)
				{
					int newSum = sum + number;

					if (possibleSums.ContainsKey(newSum))
					{
						continue;
					}

					possibleSums.Add(newSum, number);
				}
            }

			return possibleSums;
        }
	}
}
