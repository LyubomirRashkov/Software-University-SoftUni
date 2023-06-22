using System;
using System.Linq;

namespace _03.SumWithUnlimitedAmountOfCoins
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] coins = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int targetSum = int.Parse(Console.ReadLine());

			int[] sums = new int[targetSum + 1];

			sums[0] = 1;

			foreach (var coin in coins)
			{
				for (int sum = coin; sum < sums.Length; sum++)
				{
					sums[sum] += sums[sum - coin];
				}
			}

			Console.WriteLine(sums[targetSum]);
        }
	}
}
