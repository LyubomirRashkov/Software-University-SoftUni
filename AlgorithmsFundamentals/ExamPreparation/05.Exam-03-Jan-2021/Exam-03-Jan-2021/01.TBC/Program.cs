using System;

namespace _01.TBC
{
	public class Program
	{
		private const char TargetSymbol = 't';

		private static char[,] matrix;
		private static bool[,] visited;

		public static void Main(string[] args)
		{
			matrix = ReadInput();

			visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

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
					if (visited[r, c] || matrix[r, c] != TargetSymbol)
					{
						continue;
					}

					count++;

					ConnectTunnel(r, c);
				}
			}

			return count;
		}

		private static void ConnectTunnel(int r, int c)
		{
			if (!ValidateCell(r, c) || visited[r, c] || matrix[r, c] != TargetSymbol)
			{
				return;
			}

			visited[r, c] = true;

			ConnectTunnel(r, c - 1);
			ConnectTunnel(r, c + 1);
			ConnectTunnel(r - 1, c);
			ConnectTunnel(r + 1, c);
			ConnectTunnel(r - 1, c - 1);
			ConnectTunnel(r + 1, c - 1);
			ConnectTunnel(r - 1, c + 1);
			ConnectTunnel(r + 1, c + 1);
		}

		private static bool ValidateCell(int r, int c)
		{
			bool isValid = (r >= 0 && r < matrix.GetLength(0) && c >= 0 && c < matrix.GetLength(1));

			return isValid;
		}
	}
}
