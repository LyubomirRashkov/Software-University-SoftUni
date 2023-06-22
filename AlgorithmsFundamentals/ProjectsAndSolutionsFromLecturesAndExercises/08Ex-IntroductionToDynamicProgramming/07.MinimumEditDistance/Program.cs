using System;

namespace _07.MinimumEditDistance
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int replacementCost = int.Parse(Console.ReadLine());

			int insertCost = int.Parse(Console.ReadLine());

			int deleteCost = int.Parse(Console.ReadLine());

			string str1 = Console.ReadLine();

			string str2 = Console.ReadLine();

			int requiredOperationsValue = GetValueOfOperations(str1, str2, replacementCost, insertCost, deleteCost);

			Console.WriteLine($"Minimum edit distance: {requiredOperationsValue}");
		}

		private static int GetValueOfOperations(
			string str1, 
			string str2, 
			int replacementCost, 
			int insertCost, 
			int deleteCost)
		{
			int[,] dp = new int[str1.Length + 1, str2.Length + 1];

			for (int row = 1; row < dp.GetLength(0); row++)
			{
				dp[row, 0] = dp[row - 1, 0] + deleteCost;
			}

			for (int col = 1; col < dp.GetLength(1); col++)
			{
				dp[0, col] = dp[0, col - 1] + insertCost;
			}

			for (int row = 1; row < dp.GetLength(0); row++)
			{
				for (int col = 1; col < dp.GetLength(1); col++)
				{
					if (str1[row - 1] == str2[col - 1])
					{
						dp[row, col] = dp[row - 1, col - 1];
					}
					else
					{
						int replace = dp[row - 1, col - 1] + replacementCost;

						int insert = dp[row, col - 1] + insertCost;

						int delete = dp[row - 1, col] + deleteCost;

						dp[row, col] = Math.Min(Math.Min(replace, insert), delete);
					}
				}
			}

			return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
		}
	}
}
