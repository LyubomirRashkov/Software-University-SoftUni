using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CableMerchant
{
	public class Program
	{
		public static void Main(string[] args)
		{
			List<int> prices = new List<int> { 0 };

			prices.AddRange(Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse));

			int connectorPrice = int.Parse(Console.ReadLine());

			int[] bestPricesByLength = new int[prices.Count];

			FindOptimalSolutions(prices, connectorPrice, bestPricesByLength);

			Console.WriteLine(string.Join(' ', bestPricesByLength.Skip(1)));
		}

		private static void FindOptimalSolutions(
			List<int> prices,
			int connectorPrice,
			int[] bestPrices)
		{
			for (int i = 1; i < prices.Count; i++)
			{
				bestPrices[i] = prices[i];

				for (int j = 1; j < i; j++)
				{
					int newCost = prices[j] + bestPrices[i - j] - 2 * connectorPrice;

					if (newCost > bestPrices[i])
					{
						bestPrices[i] = newCost;
					}
				}
			}
		}
	}
}
