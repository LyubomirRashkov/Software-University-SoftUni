using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SubsetSumProblemWithRepetition
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

			bool[] possibleSums = new bool[targetSum + 1];

			possibleSums[0] = true;

			for (int sum = 0; sum < possibleSums.Length; sum++)
			{
				if (!possibleSums[sum])
				{
					continue;
				}

				foreach (var num in numbers)
				{
					int newSum = sum + num;

					if (newSum > targetSum)
					{
						continue;
					}

					possibleSums[newSum] = true;
				}
			}

			if (possibleSums[targetSum])
			{
				List<int> subset = FindSubset(numbers, targetSum, possibleSums);

				Console.WriteLine($"A possible solution is with numbers {string.Join(", ", subset)}");
			}
			else
			{
				Console.WriteLine($"{targetSum} can't be reached with the given numbers!");
			}
        }

		private static List<int> FindSubset(int[] numbers, int targetSum, bool[] possibleSums)
		{
			List<int> subset = new List<int>();

			while (targetSum > 0)
			{
				foreach (var num in numbers)
				{
					int previousSum = targetSum - num;

					if (previousSum >= 0 && possibleSums[previousSum])
					{
						subset.Add(num);

						targetSum = previousSum;

						if (targetSum == 0)
						{
							break;
						}
					}
				}
			}

			return subset;
		}
	}
}
