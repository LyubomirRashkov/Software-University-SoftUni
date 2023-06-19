using System;
using System.Collections.Generic;

namespace _02.AreasInMatrix
{
	public class Program
	{
		private static char[,] matrix;
		private static bool[,] visited;

		public static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());

			int cols = int.Parse(Console.ReadLine());

			matrix = new char[rows, cols];

			visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				string inputLine = Console.ReadLine();

				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = inputLine[j];
				}
			}

			SortedDictionary<char, int> countOfAreasBySymbol = new SortedDictionary<char, int>();

			int totalAreasCount = 0;

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (visited[i, j])
					{
						continue;
					}

					char symbol = matrix[i, j];

					Dfs(i, j, symbol);

					if (!countOfAreasBySymbol.ContainsKey(symbol))
					{
						countOfAreasBySymbol.Add(symbol, 1);
					}
					else
					{
						countOfAreasBySymbol[symbol]++;
					}

					totalAreasCount++;
				}
			}

            Console.WriteLine($"Areas: {totalAreasCount}");

			foreach (var kvp in countOfAreasBySymbol)
			{
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
            }
        }

		private static void Dfs(int row, int col, char symbol)
		{
			if (row < 0 || row == matrix.GetLength(0) || col < 0 || col == matrix.GetLength(1))
			{
				return;
			}

			if (visited[row, col])
			{
				return;
			}

			if (matrix[row, col] != symbol)
			{
				return;
			}

			visited[row, col] = true;

			Dfs(row - 1, col, symbol);
			Dfs(row + 1, col, symbol);
			Dfs(row, col - 1, symbol);
			Dfs(row, col + 1, symbol);
		}
	}
}
