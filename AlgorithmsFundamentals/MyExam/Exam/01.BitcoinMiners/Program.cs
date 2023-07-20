using System;
using System.Collections.Generic;

namespace _01.BitcoinMiners
{
	public class Program
	{
		private static Dictionary<string, long> cache = new Dictionary<string, long>();

		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int x = int.Parse(Console.ReadLine());

			long combinationsCount = GetCountOfCombinations(n, x);

            Console.WriteLine(combinationsCount);
        }

		private static long GetCountOfCombinations(int row, int col)
		{
			if (row == 0 || col == 0 || row == col)
			{
				return 1;
			}

			string key = $"{row}->{col}";

			if (cache.ContainsKey(key))
			{
				return cache[key];
			}

			long result = GetCountOfCombinations(row - 1, col) + GetCountOfCombinations(row - 1, col - 1);

			cache.Add(key, result);

			return result;
		}
	}
}
