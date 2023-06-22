using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumWithLimitedAmountOfCoins
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

			int counter = 0;

			HashSet<int> sums = new HashSet<int> { 0 };

			foreach (int coin in coins) 
			{
				HashSet<int> newSums = new HashSet<int>();

				foreach (var sum in sums)
				{
					int newSum = sum + coin;

					newSums.Add(newSum);

					if (newSum == targetSum)
					{
						counter++;
					}
				}

				sums.UnionWith(newSums);
			}

            Console.WriteLine(counter);
        }
	}
}
