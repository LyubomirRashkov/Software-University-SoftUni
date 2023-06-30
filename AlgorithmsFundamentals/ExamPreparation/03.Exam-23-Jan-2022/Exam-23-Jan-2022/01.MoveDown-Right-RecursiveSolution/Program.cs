using System;
using System.Collections.Generic;

namespace _01.MoveDown_Right_RecursiveSolution
{
	public class Program
	{
		private static Dictionary<string, long> cache;

		public static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());

			int cols = int.Parse(Console.ReadLine());

			cache = new Dictionary<string, long>();

			long countOfPaths = GetCountOfPaths(rows, cols);

            Console.WriteLine(countOfPaths);
        }

		private static long GetCountOfPaths(int rows, int cols)
		{
			if (rows == 1 || cols == 1)
			{
				return 1;
			}

			string key = $"{rows} {cols}";

			if (cache.ContainsKey(key))
			{
				return cache[key];
			}

			long result = GetCountOfPaths(rows - 1, cols) + GetCountOfPaths(rows, cols - 1);

			cache.Add(key, result);

			return result;
		}
	}
}
