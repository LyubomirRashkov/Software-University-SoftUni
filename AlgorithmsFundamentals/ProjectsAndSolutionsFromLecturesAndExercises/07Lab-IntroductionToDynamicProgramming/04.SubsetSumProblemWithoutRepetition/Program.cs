using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SubsetSumProblemWithoutRepetition
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int targetSum = int.Parse(Console.ReadLine());

			Dictionary<int, int> possibleSums = GetAllPossibleSums(numbers);

			if (possibleSums.ContainsKey(targetSum))
			{
				List<int> subset = FindSubset(possibleSums, targetSum);

				Console.WriteLine($"Required numbers are {string.Join(", ", subset)}");
            }
			else
			{
                Console.WriteLine($"{targetSum} can't be reached with the given numbers!");
            }
		}

		private static List<int> FindSubset(Dictionary<int, int> sums, int targetSum)
		{
			List<int> subset = new List<int>();

			while (targetSum > 0)
			{
				int num = sums[targetSum];

				subset.Add(num);

				targetSum -= num;
			}

			return subset;
		}

		private static Dictionary<int, int> GetAllPossibleSums(int[] numbers)
		{
			Dictionary<int, int> sums = new Dictionary<int, int> { { 0, 0 }  };

			foreach (var num in numbers)
			{
				int[] currentSums = sums.Keys.ToArray();

				foreach (var sum in currentSums)
				{
					int newSum = sum + num;

					if (!sums.ContainsKey(newSum))
					{
						sums.Add(newSum, num);
					}
				}
			}

			return sums;
		}
	}
}
