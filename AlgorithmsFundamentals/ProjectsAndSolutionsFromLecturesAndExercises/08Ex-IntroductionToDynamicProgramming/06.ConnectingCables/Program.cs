using System;
using System.Linq;

namespace _06.ConnectingCables
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] orderedNumbers = Enumerable.Range(1, numbers.Length).ToArray();

			int count = GetLengthOfLongestCommonSubsequence(numbers, orderedNumbers);

			Console.WriteLine($"Maximum pairs connected: {count}");
		}

		private static int GetLengthOfLongestCommonSubsequence(int[] arr1, int[] arr2)
		{
			int[,] lcs = new int[arr1.Length + 1, arr2.Length + 1];

			for (int row = 1; row < lcs.GetLength(0); row++)
			{
				for (int col = 1; col < lcs.GetLength(1); col++)
				{
					if (arr2[row - 1] == arr1[col - 1])
					{
						lcs[row, col] = lcs[row - 1, col - 1] + 1;
					}
					else
					{
						int maxValue = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);

						lcs[row, col] = maxValue;
					}
				}
			}

			return lcs[lcs.GetLength(0) - 1, lcs.GetLength(1) - 1];
		}
	}
}
