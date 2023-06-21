using System;
using System.Collections.Generic;

namespace _01.Fibonacci
{
	public class Program
	{
		private static Dictionary<int, long> fibonacciByNumber;

		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			fibonacciByNumber = new Dictionary<int, long>();

			long fibonacci = CalculateFibonacci(n);

			Console.WriteLine(fibonacci);
		}

		private static long CalculateFibonacci(int n)
		{
			if (fibonacciByNumber.ContainsKey(n))
			{
				return fibonacciByNumber[n];
			}

			if (n == 0)
			{
				return 0;
			}

			if (n == 1)
			{
				return 1;
			}

			long result = CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);

			fibonacciByNumber.Add(n, result);

			return result;
		}
	}
}
