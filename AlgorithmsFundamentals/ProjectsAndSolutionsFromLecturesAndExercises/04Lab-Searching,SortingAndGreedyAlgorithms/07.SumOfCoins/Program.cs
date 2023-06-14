using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SumOfCoins
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Queue<int> coins = new Queue<int>(Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.OrderByDescending(c => c));

			int targetSum = int.Parse(Console.ReadLine());

			Dictionary<int, int> countOfCoinsByNominal = new Dictionary<int, int>();

			int countOfAllUsedCoins = 0;

			while (targetSum > 0 && coins.Count > 0)
			{
				int currentCoin = coins.Dequeue();

				int count = targetSum / currentCoin;

				if (count > 0)
				{
					countOfAllUsedCoins += count;

					countOfCoinsByNominal[currentCoin] = count;

					targetSum %= currentCoin;
				}
			}

			if (targetSum != 0)
			{
				Console.WriteLine("Error");
			}
			else
			{
				Console.WriteLine($"Number of coins to take: {countOfAllUsedCoins}");

				foreach (var kvp in countOfCoinsByNominal)
				{
                    Console.WriteLine($"{kvp.Value} coin(s) with value {kvp.Key}");
                }
			}
		}
	}
}
