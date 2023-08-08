using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RodCutting_Iterative
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] prices = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int length = int.Parse(Console.ReadLine());

			int[] bestPricesByLength = new int[Math.Max(prices.Length, length + 1)];

			int[] lastAddedLenghts = new int[Math.Max(prices.Length, length + 1)];

			FindOptimalSolution(prices, length, bestPricesByLength, lastAddedLenghts);

			Console.WriteLine(bestPricesByLength[length]);

			List<int> addedLengths = GetAddedLengths(lastAddedLenghts, length);

            Console.WriteLine(string.Join(' ', addedLengths));
        }

		private static List<int> GetAddedLengths(int[] lastAddedLenghts, int length)
		{
			List<int> addedLengths = new List<int>();

			while (length != 0)
			{
				int lastAddedLength = lastAddedLenghts[length];

				addedLengths.Add(lastAddedLength);

				length -= lastAddedLength;
			}

			return addedLengths;
		}

		private static void FindOptimalSolution(int[] prices, int length, int[] bestPrices, int[] lastAddedLenghts)
		{
			for (int i = 1; i <= length; i++)
			{
				bestPrices[i] = int.MinValue;

				for (int j = 1; j <= i; j++)
				{
					if (j == prices.Length)
					{
						break;
					}

					int newCost = prices[j] + bestPrices[i - j];

					if (newCost > bestPrices[i])
					{
						bestPrices[i] = newCost;

						lastAddedLenghts[i] = j;
					}
				}
			}
		}
	}
}
