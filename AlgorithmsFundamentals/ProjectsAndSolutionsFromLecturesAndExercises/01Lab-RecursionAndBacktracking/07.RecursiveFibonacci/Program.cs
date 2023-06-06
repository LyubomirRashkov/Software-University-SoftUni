using System;
using System.Collections.Generic;

namespace _07.RecursiveFibonacci
{
	public class Program
	{
		private static readonly Dictionary<int, long> results = new Dictionary<int, long>();

		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			long fibonacciNumber = CalculateFibonacci(n);

			Console.WriteLine(fibonacciNumber);
		}

		private static long CalculateFibonacci(int n)
		{
			if (n <= 1)
			{
				return 1;
			}

			if (results.ContainsKey(n))
			{
				return results[n];
			}

			long result = CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);

			results.Add(n, result);

			return result;
		}
	}
}
