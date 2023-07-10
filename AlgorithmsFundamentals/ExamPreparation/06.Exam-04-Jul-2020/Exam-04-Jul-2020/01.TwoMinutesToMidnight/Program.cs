using System;
using System.Collections.Generic;

namespace _01.TwoMinutesToMidnight
{
	public class Program
	{
		private static Dictionary<string, long> cache;

		public static void Main(string[] args)
		{
			int firstNumber = int.Parse(Console.ReadLine());

			int secondNumber = int.Parse(Console.ReadLine());

			cache = new Dictionary<string, long>();

			long combinationsCount = GetCombinationsCount(firstNumber, secondNumber);

            Console.WriteLine(combinationsCount);
        }

		private static long GetCombinationsCount(int row, int col)
		{
			if (row == 0 || col == 0 || row == col)
			{
				return 1;
			}

			string key = $"{row}-{col}";

			if (cache.ContainsKey(key))
			{
				return cache[key];
			}

			long result = GetCombinationsCount(row - 1, col) + GetCombinationsCount(row - 1, col - 1);

			cache.Add(key, result);

			return result;
		}
	}
}
