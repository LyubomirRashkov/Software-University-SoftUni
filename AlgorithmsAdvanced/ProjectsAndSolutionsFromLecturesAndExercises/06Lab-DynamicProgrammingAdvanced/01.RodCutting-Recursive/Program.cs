using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RodCutting
{
	public class Program
	{
		private static int[] prices;

		private static int[] bestPricesByLength;

		private static int[] lastAddedLengths;

		public static void Main(string[] args)
		{
			prices = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int length = int.Parse(Console.ReadLine());

			bestPricesByLength = new int[prices.Length];

			lastAddedLengths = new int[prices.Length];

			int bestPrice = CutRod(length);

			Console.WriteLine(bestPrice);

			List<int> lengths = GetLengths(length);

			Console.WriteLine(string.Join(' ', lengths));
		}

		private static List<int> GetLengths(int length)
		{
			List<int> lengths = new List<int>();

			while (length != 0)
			{
				int currentLength = lastAddedLengths[length];

				lengths.Add(currentLength);

				length -= currentLength;
			}

			return lengths;
		}

		private static int CutRod(int length)
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

			int lastLength = length;

			for (int i = 1; i < length; i++)
			{
				int currentPrice = prices[i] + CutRod(length - i);

				if (bestPrice < currentPrice)
				{
					bestPrice = currentPrice;

					lastLength = i;
				}
			}

			bestPricesByLength[length] = bestPrice;

			lastAddedLengths[length] = lastLength;

			return bestPrice;
		}
	}
}
