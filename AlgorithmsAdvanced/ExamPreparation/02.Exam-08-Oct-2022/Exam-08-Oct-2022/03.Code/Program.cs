using System;
using System.Linq;

namespace _03.Code
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] firstNumbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int[] secondNumbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int[,] lcs = new int[firstNumbers.Length + 1, secondNumbers.Length + 1];

			for (int r = 1; r <= firstNumbers.Length; r++)
			{
				for (int c = 1; c <= secondNumbers.Length; c++)
				{
					if (firstNumbers[r - 1] == secondNumbers[c - 1])
					{
						lcs[r, c] = lcs[r - 1, c - 1] + 1;
					}
					else
					{
						lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
					}
				}
			}

			int[] elements = new int[lcs[firstNumbers.Length, secondNumbers.Length]];

			int index = elements.Length - 1;

			int row = firstNumbers.Length;

			int col = secondNumbers.Length;

			while (row > 0 && col > 0)
			{
				if (firstNumbers[row - 1] == secondNumbers[col - 1])
				{
					elements[index] = firstNumbers[row - 1];

					index--;

					row--;

					col--;
				}
				else if (lcs[row - 1, col] > lcs[row, col - 1])
				{
					row--;
				}
				else
				{
					col--;
				}
			}

			Console.WriteLine(string.Join(" ", elements));

			Console.WriteLine(elements.Length);
		}
	}
}
