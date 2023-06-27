using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BankRobbery
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int sum = numbers.Sum();

			int targetSum = sum / 2;

			Dictionary<int, int> sumsWithLastAddedNum = GetAllPossibleSums(numbers);

			SortedSet<int> subset = FindSubset(sumsWithLastAddedNum, targetSum);

			SortedSet<int> restOfNumbers = new SortedSet<int>();

			foreach (var num in numbers)
			{
				if (!subset.Contains(num))
				{
					restOfNumbers.Add(num);
				}
			}

            Console.WriteLine(string.Join(' ', subset));

            Console.WriteLine(string.Join(' ', restOfNumbers));
        }

		private static SortedSet<int> FindSubset(Dictionary<int, int> sumsWithLastAddedNum, int targetSum)
		{
			SortedSet<int> subset = new SortedSet<int>();

			while (targetSum > 0)
			{
				int num = sumsWithLastAddedNum[targetSum];

				subset.Add(num);

				targetSum -= num;
			}

			return subset;
		}

		private static Dictionary<int, int> GetAllPossibleSums(int[] numbers)
		{
			Dictionary<int, int> sumsWithLastAddedNum = new Dictionary<int, int> { { 0, 0 } };

			foreach (var num in numbers)
			{
				int[] currentSums = sumsWithLastAddedNum.Keys.ToArray();

				foreach (var sum in currentSums)
				{
					int newSum = sum + num;

					if (!sumsWithLastAddedNum.ContainsKey(newSum))
					{
						sumsWithLastAddedNum.Add(newSum, num);
					}
				}
			}

			return sumsWithLastAddedNum;
		}
	}
}
