using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MoveDown_Right
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());

			int cols = int.Parse(Console.ReadLine());

			int[,] matrix = new int[rows, cols];

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				int[] rowElements = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = rowElements[j];
				}
			}

			int[,] dp = new int[matrix.GetLength(0), matrix.GetLength(1)];

			dp[0, 0] = matrix[0, 0];

			for (int c = 1; c < dp.GetLength(1); c++)
			{
				dp[0, c] = dp[0, c - 1] + matrix[0, c];
			}

			for (int r = 1; r < dp.GetLength(0); r++)
			{
				dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
			}

			for (int r = 1; r < matrix.GetLength(0); r++)
			{
				for (int c = 1; c < matrix.GetLength(1); c++)
				{
					int maxValue = Math.Max(dp[r, c - 1], dp[r - 1, c]);

					dp[r, c] = maxValue + matrix[r, c];
				}
			}

			Stack<string> path = new Stack<string>();

			int currentRow = dp.GetLength(0) - 1;

			int currentCol = dp.GetLength(1) - 1;

			while (currentRow > 0 && currentCol > 0)
			{
				path.Push($"[{currentRow}, {currentCol}]");

				int upperValue = dp[currentRow - 1, currentCol];

				int leftValue = dp[currentRow, currentCol - 1];

				if (upperValue > leftValue)
				{
					currentRow--;
				}
				else
				{
					currentCol--;
				}
			}

			while (currentRow > 0)
			{
				path.Push($"[{currentRow}, {currentCol}]");

				currentRow--;
			}

			while (currentCol > 0)
			{
				path.Push($"[{currentRow}, {currentCol}]");

				currentCol--;
			}

			path.Push($"[{currentRow}, {currentCol}]");

			Console.WriteLine(string.Join(' ', path));
		}
	}
}
