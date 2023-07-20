using System;
using System.Collections.Generic;

namespace _03.BitcoinTransactions
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string[] arr1 = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			string[] arr2 = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			int[,] lcs = FillLcsMatrix(arr1, arr2);

			Stack<string> commonElements = GetCommonElements(arr1, arr2, lcs);

            Console.WriteLine($"[{string.Join(' ', commonElements)}]");
        }

		private static int[,] FillLcsMatrix(string[] arr1, string[] arr2)
		{
			int[,] lcs = new int[arr1.Length + 1, arr2.Length + 1];

			for (int r = 1; r < lcs.GetLength(0); r++)
			{
				for (int c = 1; c < lcs.GetLength(1); c++)
				{
					if (arr1[r - 1] == arr2[c - 1])
					{
						lcs[r, c] = lcs[r - 1, c - 1] + 1;
					}
					else
					{
						lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
					}
				}
			}

			return lcs;
		}

		private static Stack<string> GetCommonElements(string[] arr1, string[] arr2, int[,] lcs)
		{
			Stack<string> commonElements = new Stack<string>();

			int row = lcs.GetLength(0) - 1;

			int col = lcs.GetLength(1) - 1;

			while (row > 0 && col > 0)
			{
				if (arr1[row - 1] == arr2[col - 1])
				{
					commonElements.Push(arr1[row - 1]);

					row--;

					col--;
				}
				else if (lcs[row - 1, col] >= lcs[row, col - 1])
				{
					row--;
				}
				else
				{
					col--;
				}
			}

			return commonElements;
		}
	}
}
