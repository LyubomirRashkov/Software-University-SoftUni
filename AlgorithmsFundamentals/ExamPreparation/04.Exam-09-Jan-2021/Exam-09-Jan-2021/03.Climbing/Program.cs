using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.Climbing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[,] matrix = ReadInput();

			int[,] dp = FillDPMatrix(matrix);

			Stack<int> path = GetPath(matrix, dp);

			Console.WriteLine(dp[0, 0]);

            Console.WriteLine(string.Join(' ', path));
        }

		private static int[,] ReadInput()
		{
			int rows = int.Parse(Console.ReadLine());

			int cols = int.Parse(Console.ReadLine());

			int[,] inputMatrix = new int[rows, cols];

			for (int r = 0; r < inputMatrix.GetLength(0); r++)
			{
				int[] input = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				for (int c = 0; c < inputMatrix.GetLength(1); c++)
				{
					inputMatrix[r, c] = input[c];
				}
			}

			return inputMatrix;
		}

		private static int[,] FillDPMatrix(int[,] matrix)
		{
			int[,] dpMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

			int lastRow = dpMatrix.GetLength(0) - 1;

			int lastCol = dpMatrix.GetLength(1) - 1;

			dpMatrix[lastRow, lastCol] = matrix[lastRow, lastCol];

			for (int c = lastCol - 1; c >= 0; c--)
			{
				dpMatrix[lastRow, c] = dpMatrix[lastRow, c + 1] + matrix[lastRow, c];
			}

			for (int r = lastRow - 1; r >= 0; r--)
			{
				dpMatrix[r, lastCol] = dpMatrix[r + 1, lastCol] + matrix[r, lastCol];
			}

			for (int r = lastRow - 1; r >= 0; r--)
			{
				for (int c = lastCol - 1; c >= 0; c--)
				{
					int down = dpMatrix[r + 1, c];

					int right = dpMatrix[r, c + 1];

					dpMatrix[r, c] = Math.Max(down, right) + matrix[r, c];
				}
			}

			return dpMatrix;
		}

		private static Stack<int> GetPath(int[,] matrix, int[,] dp)
		{
			Stack<int> path = new Stack<int>();

			int lastRow = matrix.GetLength(0) - 1;

			int lastCol = matrix.GetLength(1) - 1;

			int currentRow = 0;

			int currentCol = 0;

			while (currentRow < lastRow && currentCol < lastCol)
			{
				path.Push(matrix[currentRow, currentCol]);

				int down = dp[currentRow + 1, currentCol];

				int right = dp[currentRow, currentCol + 1];

				if (right > down)
				{
					currentCol++;
				}
				else
				{
					currentRow++;
				}
			}

			while (currentRow < lastRow)
			{
				path.Push(matrix[currentRow, currentCol]);

				currentRow++;
			}

			while (currentCol < lastCol)
			{
				path.Push(matrix[currentRow, currentCol]);
				currentCol++;
			}

			path.Push(matrix[currentRow, currentCol]);

			return path;
		}
	}
}
