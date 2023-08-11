using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CableMerchant_Recursive
{
	public class Program
	{
		private static List<int> prices;

		private static int[] bestPricesByLength;

		public static void Main(string[] args)
		{
			prices = new List<int> { 0 };

			prices.AddRange(Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse));

			int connectorPrice = int.Parse(Console.ReadLine());

			bestPricesByLength = new int[prices.Count];

			CutRod(prices.Count - 1, connectorPrice);

            Console.WriteLine(string.Join(' ', bestPricesByLength.Skip(1)));
        }

		private static int CutRod(int length, int connectorPrice)
		{
			if (length == 0)
			{
				return 0;
			}

			if (bestPricesByLength[length] != 0)
			{
				return bestPricesByLength[length];
			}

			int bestPrice = prices[length];

			for (int i = 1; i < length; i++)
			{
				int currentPrice = prices[i] + CutRod(length - i, connectorPrice) - 2 * connectorPrice;

				if (bestPrice < currentPrice)
				{
					bestPrice = currentPrice;
				}
			}

			bestPricesByLength[length] = bestPrice;

			return bestPrice;
		}
	}
}
