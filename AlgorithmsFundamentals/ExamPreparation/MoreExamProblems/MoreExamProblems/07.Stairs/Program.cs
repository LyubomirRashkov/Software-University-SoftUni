using System;

namespace _07.Stairs
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int[] dp = new int[n + 1];

			dp[0] = 1;

			dp[1] = 1;

			for (int i = 2; i < dp.Length; i++)
			{
				dp[i] = dp[i - 1] + dp[i - 2];
			}

			Console.WriteLine(dp[^1]);
        }
	}
}
