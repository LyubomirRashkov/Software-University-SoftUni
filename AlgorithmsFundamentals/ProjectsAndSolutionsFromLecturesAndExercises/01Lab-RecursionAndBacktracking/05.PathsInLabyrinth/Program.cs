using System;
using System.Collections.Generic;

namespace _05.PathsInLabyrinth
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());

			int cols = int.Parse(Console.ReadLine());

			char[,] lab = new char[rows, cols];

			for (int row = 0; row < lab.GetLength(0); row++)
			{
				string inputRow = Console.ReadLine();

				for (int col = 0; col < lab.GetLength(1); col++)
				{
					lab[row, col] = inputRow[col];
				}
			}

			FindPaths(lab, 0, 0, new List<string>(), string.Empty);
		}

		private static void FindPaths(char[,] lab, int row, int col, List<string> steps, string currentStep)
		{
			if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1))
			{
				return;
			}

			if (lab[row, col] == '*' || lab[row, col] == 'V')
			{
				return;
			}

			steps.Add(currentStep);

			if (lab[row, col] == 'e')
			{
                Console.WriteLine(string.Join(string.Empty, steps));

				steps.RemoveAt(steps.Count - 1);

                return;
			}

			lab[row, col] = 'V';

			FindPaths(lab, row, col - 1, steps, "L");

			FindPaths(lab, row, col + 1, steps, "R");

			FindPaths(lab, row - 1, col, steps, "U");

			FindPaths(lab, row + 1, col, steps, "D");

			lab[row, col] = '-';

			steps.RemoveAt(steps.Count - 1);
		}
	}
}
