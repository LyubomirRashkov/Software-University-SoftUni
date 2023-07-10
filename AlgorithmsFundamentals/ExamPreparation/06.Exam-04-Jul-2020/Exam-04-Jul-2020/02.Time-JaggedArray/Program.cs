using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Time_JaggedArray
{
	public class Program
	{
		private static int[][] lcs;

		public static void Main(string[] args)
		{
			int[] arr1 = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] arr2 = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			InitializeTable(arr1, arr2);

			Stack<int> subset = new Stack<int>();

			int row = arr1.Length;

			int col = arr2.Length;

			while (row > 0 && col > 0)
			{
				if (arr1[row - 1] == arr2[col - 1])
				{
					subset.Push(arr1[row - 1]);

					row--;

					col--;
				}
				else if (lcs[row - 1][col] > lcs[row][col - 1])
				{
					row--;
				}
				else
				{
					col--;
				}
			}

			Console.WriteLine(string.Join(' ', subset));

			Console.WriteLine(lcs[^1][^1]);
		}

		private static void InitializeTable(int[] arr1, int[] arr2)
		{
			lcs = new int[arr1.Length + 1][];

			for (int row = 0; row < lcs.Length; row++)
			{
				lcs[row] = new int[arr2.Length + 1];
			}

			for (int row = 1; row < lcs.Length; row++)
			{
				for (int col = 1; col < lcs[row].Length; col++)
				{
					if (arr1[row - 1] == arr2[col - 1])
					{
						lcs[row][col] = lcs[row - 1][col - 1] + 1;
					}
					else
					{
						lcs[row][col] = Math.Max(lcs[row - 1][col], lcs[row][col - 1]);
					}
				}
			}
		}
	}
}
