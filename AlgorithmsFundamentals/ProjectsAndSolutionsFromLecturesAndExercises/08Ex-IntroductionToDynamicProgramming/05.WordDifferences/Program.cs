using System;

namespace _05.WordDifferences
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string str1 = Console.ReadLine();

			string str2 = Console.ReadLine();

			int requiredOperationsCount = GetCountOfOperations(str1, str2);

            Console.WriteLine($"Deletions and Insertions: {requiredOperationsCount}");
        }

		private static int GetCountOfOperations(string str1, string str2)
		{
			int[,] dp = new int[str2.Length + 1, str1.Length + 1];

			for (int col = 0; col < dp.GetLength(1); col++)
			{
				dp[0, col] = col;
			}

			for (int row = 0; row < dp.GetLength(0); row++)
			{
				dp[row, 0] = row;
			}

			for (int row = 1; row < dp.GetLength(0); row++)
			{
				for (int col = 1; col < dp.GetLength(1); col++)
				{
					if (str1[col - 1] == str2[row - 1])
					{
						dp[row, col] = dp[row - 1, col - 1];
					}
					else
					{
						int minValue = Math.Min(dp[row - 1, col], dp[row, col - 1]);

						dp[row, col] = minValue + 1;
					}
				}
			}

			return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
		}
	}
}
