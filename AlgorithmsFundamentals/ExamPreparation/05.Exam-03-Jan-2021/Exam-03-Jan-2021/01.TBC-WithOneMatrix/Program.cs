using System;

namespace _01.TBC
{
	public class Program
	{
		private const char TargetSymbol = 't';
		private const char VisitedSymbol = 'v';

		private static char[,] matrix;

		public static void Main(string[] args)
		{
			matrix = ReadInput();

			int countOfTunnels = CountTunnels();

			Console.WriteLine(countOfTunnels);
		}

		private static char[,] ReadInput()
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

			return matrix;
		}

		private static int CountTunnels()
		{
			int count = 0;

			for (int r = 0; r < matrix.GetLength(0); r++)
			{
				for (int c = 0; c < matrix.GetLength(1); c++)
				{
					if (matrix[r, c] == TargetSymbol)
					{
						count++;

						ConnectTunnel(r, c);
					}
				}
			}

			return count;
		}

		private static void ConnectTunnel(int r, int c)
		{
			if (IsOutside(r, c) || matrix[r, c] != TargetSymbol)
			{
				return;
			}

			matrix[r, c] = VisitedSymbol;

			ConnectTunnel(r, c - 1);
			ConnectTunnel(r, c + 1);
			ConnectTunnel(r - 1, c);
			ConnectTunnel(r + 1, c);
			ConnectTunnel(r - 1, c - 1);
			ConnectTunnel(r + 1, c - 1);
			ConnectTunnel(r - 1, c + 1);
			ConnectTunnel(r + 1, c + 1);
		}

		private static bool IsOutside(int r, int c)
		{
			bool isOutside = r < 0 || r >= matrix.GetLength(0) || c < 0 || c >= matrix.GetLength(1);

			return isOutside;
		}
	}
}
