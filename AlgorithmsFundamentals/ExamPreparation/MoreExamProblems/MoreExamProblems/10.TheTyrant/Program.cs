using System;
using System.Linq;

namespace _10.TheTyrant
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int minSum = GetMinimumSum(numbers);

			Console.WriteLine(minSum);
		}

		private static int GetMinimumSum(int[] numbers)
		{
			int n = numbers.Length;

			if (n <= 4)
			{
				return numbers.Min();
			}

			int[] dp = new int[n];

			dp[0] = numbers[0];
			dp[1] = numbers[1];
			dp[2] = numbers[2];
			dp[3] = numbers[3];

			for (int i = 4; i < n; i++)
			{
				dp[i] = Math.Min(Math.Min(dp[i - 4], dp[i - 3]), Math.Min(dp[i - 2], dp[i - 1])) + numbers[i];
			}

			int minSum = Math.Min(Math.Min(dp[n - 1], dp[n - 2]), Math.Min(dp[n - 3], dp[n - 4]));

			return minSum;
		}
	}
}
