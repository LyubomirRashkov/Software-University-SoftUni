using System;

namespace _01.MoveDown_Right_IterativeWithMatrix
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());

			int cols = int.Parse(Console.ReadLine());

			long[,] matrix = new long[rows, cols];

			for (int c = 1; c < matrix.GetLength(1); c++)
			{
				matrix[0, c] = 1;
			}

			for (int r = 1; r < matrix.GetLength(0); r++)
			{
				matrix[r, 0] = 1;
			}

			for (int r = 1; r < matrix.GetLength(0); r++)
			{
				for (int c = 1; c < matrix.GetLength(1); c++)
				{
					matrix[r, c] = matrix[r - 1, c] + matrix[r, c - 1];
				}
			}

			Console.WriteLine(matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]);
        }
	}
}
