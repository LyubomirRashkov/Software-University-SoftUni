using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ConnectedAreasInAMatrix
{
	public class Area
	{
		public int Row { get; set; }

		public int Col { get; set; }

		public int Size { get; set; }
	}

	public class Program
	{
		private const char VisitedCell = 'V';

		private static int size;
		private static char[,] matrix;

		public static void Main(string[] args)
		{
			ReadInput();

			List<Area> areas = SearchForAreas();

			PrintOutput(areas);
		}

		private static void ReadInput()
		{
			int rows = int.Parse(Console.ReadLine());

			int cols = int.Parse(Console.ReadLine());

			matrix = new char[rows, cols];

			for (int r = 0; r < matrix.GetLength(0); r++)
			{
				string inputLine = Console.ReadLine();

				for (int c = 0; c < matrix.GetLength(1); c++)
				{
					matrix[r, c] = inputLine[c];
				}
			}
		}

		private static List<Area> SearchForAreas()
		{
			List<Area> areas = new List<Area>();

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					size = 0;

					FindSizeOfCurrentArea(row, col);

					if (size > 0)
					{
						Area area = new Area { Row = row, Col = col, Size = size };

						areas.Add(area);
					}
				}
			}

			return areas;
		}

		private static void PrintOutput(List<Area> areas)
		{
			List<Area> sortedAreas = areas
				.OrderByDescending(a => a.Size)
				.ThenBy(a => a.Row)
				.ThenBy(a => a.Col)
				.ToList();

			Console.WriteLine($"Total areas found: {sortedAreas.Count}");

			for (int i = 0; i < sortedAreas.Count; i++)
			{
				Console.WriteLine($"Area #{i + 1} at ({sortedAreas[i].Row}, {sortedAreas[i].Col}), size: {sortedAreas[i].Size}");
			}
		}

		private static void FindSizeOfCurrentArea(int row, int col)
		{
			if (!CellIsValid(row, col))
			{
				return;
			}

			size++;

			matrix[row, col] = VisitedCell;

			FindSizeOfCurrentArea(row - 1, col);
			FindSizeOfCurrentArea(row + 1, col);
			FindSizeOfCurrentArea(row, col - 1);
			FindSizeOfCurrentArea(row, col + 1);
		}

		private static bool CellIsValid(int row, int col)
		{
			if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
			{
				return false;
			}

			if (matrix[row, col] == '*' || matrix[row, col] == VisitedCell)
			{
				return false;
			}

			return true;
		}
	}
}
