using System;
using System.Linq;

namespace _03.RoadTrip
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] values = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] spaces = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int totalSpace = int.Parse(Console.ReadLine());

			int[,] dp = new int[values.Length + 1, totalSpace + 1];

			FillMatrix(dp, values, spaces);

            Console.WriteLine($"Maximum value: {dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1]}");
        }

		private static void FillMatrix(int[,] dp, int[] values, int[] spaces)
		{
			for (int row = 1; row < dp.GetLength(0); row++)
			{
				int currentItemValue = values[row - 1];

				int currentItemSpace = spaces[row - 1];

				for (int space = 0; space < dp.GetLength(1); space++)
				{
					int excludingValue = dp[row - 1, space];

					if (space < currentItemSpace)
					{
						dp[row, space] = excludingValue;

						continue;
					}

					int includingValue = currentItemValue + dp[row - 1, space - currentItemSpace];

					dp[row, space] = Math.Max(excludingValue, includingValue);
				}
			}
		}
	}
}
