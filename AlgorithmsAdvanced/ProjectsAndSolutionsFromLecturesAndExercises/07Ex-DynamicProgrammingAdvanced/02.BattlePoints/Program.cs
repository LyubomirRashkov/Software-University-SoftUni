using System;
using System.Linq;

namespace _02.BattlePoints
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] energyRequired = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] battlePoints = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int energyTotal = int.Parse(Console.ReadLine());

			int[,] dp = new int[energyRequired.Length + 1, energyTotal + 1];

			FillMatrix(dp, energyRequired, battlePoints);

			Console.WriteLine(dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1]);
        }

		private static void FillMatrix(int[,] dp, int[] energyRequired, int[] battlePoints)
		{
			for (int row = 1; row < dp.GetLength(0); row++)
			{
				int currentEnergyRequired = energyRequired[row - 1];

				int currentBattlePoints = battlePoints[row - 1];

				for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
				{
					int excludingValue = dp[row - 1, capacity];

					if (capacity < currentEnergyRequired)
					{
						dp[row, capacity] = excludingValue;

						continue;
					}

					int includingValue = currentBattlePoints + dp[row - 1, capacity - currentEnergyRequired];

					if (capacity >= currentEnergyRequired && includingValue > excludingValue)
					{
						dp[row, capacity] = includingValue;
					}
					else
					{
						dp[row, capacity] = excludingValue;
					}
				}
			}
		}
	}
}
