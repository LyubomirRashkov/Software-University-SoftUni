using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ClusterBorder
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] singleTimes = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] pairTimes = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] dp = new int[singleTimes.Length + 1];

			dp[0] = 0;

			dp[1] = singleTimes[0];

			for (int i = 2; i <= singleTimes.Length; i++)
			{
				int singleShipTime = singleTimes[i - 1] + dp[i - 1];

				int pairShipTime = pairTimes[i - 2] + dp[i - 2];

				dp[i] = Math.Min(singleShipTime, pairShipTime);
			}

			Console.WriteLine($"Optimal Time: {dp[^1]}");

			Stack<string> passes = new Stack<string>();

			int index = dp.Length - 1;

			while (index > 0)
			{
				if (dp[index - 1] + singleTimes[index - 1] == dp[index])
				{
					passes.Push($"Single {index}");

					index--;
				}
				else
				{
					passes.Push($"Pair of {index - 1} and {index}");

					index -= 2;
				}
			}

            Console.WriteLine(string.Join(Environment.NewLine, passes));
        }
	}
}
