using System;
using System.Collections.Generic;

namespace _06.QueensPuzzle
{
	public class Program
	{
		private const int size = 8;

		private static HashSet<int> attackedCols = new HashSet<int>();
		private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
		private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

		public static void Main(string[] args)
		{
			bool[,] board = new bool[size, size];

			PlaceQueens(board, 0);
		}

		private static void PlaceQueens(bool[,] board, int row)
		{
			if (row == board.GetLength(0))
			{
				PrintSolution(board);

				return;
			}

			for (int col = 0; col < board.GetLength(1); col++)
			{
				if (IsSafe(row, col))
				{
					MarkPositionAsQueen(board, row, col);

					PlaceQueens(board, row + 1);

					MarkPositionAsNoQueen(board, row, col);
				}
			}
		}

		private static void PrintSolution(bool[,] board)
		{
			for (int row = 0; row < board.GetLength(0); row++)
			{
				for (int col = 0; col < board.GetLength(1); col++)
				{
					if (board[row, col])
					{
						Console.Write("* ");
					}
					else
					{
						Console.Write("- ");
					}
				}

				Console.WriteLine();
			}

			Console.WriteLine();
		}

		private static bool IsSafe(int row, int col)
			=> !attackedCols.Contains(col)
			&& !attackedLeftDiagonals.Contains(col - row)
			&& !attackedRightDiagonals.Contains(col + row);

		private static void MarkPositionAsQueen(bool[,] board, int row, int col)
		{
			board[row, col] = true;

			attackedCols.Add(col);
			attackedLeftDiagonals.Add(col - row);
			attackedRightDiagonals.Add(col + row);
		}

		private static void MarkPositionAsNoQueen(bool[,] board, int row, int col)
		{
			board[row, col] = false;

			attackedCols.Remove(col);
			attackedLeftDiagonals.Remove(col - row);
			attackedRightDiagonals.Remove(col + row);
		}
	}
}
