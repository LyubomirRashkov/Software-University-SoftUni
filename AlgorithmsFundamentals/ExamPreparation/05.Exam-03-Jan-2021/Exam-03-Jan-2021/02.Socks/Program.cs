using System;
using System.Linq;

namespace _02.Socks
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] arr1 = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] arr2 = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[,] lcs = new int[arr1.Length + 1, arr2.Length + 1];

			for (int r = 1; r < lcs.GetLength(0); r++)
			{
				for (int c = 1; c < lcs.GetLength(1); c++)
				{
					if (arr1[r - 1] == arr2[c - 1])
					{
						lcs[r, c] = lcs[r - 1, c - 1] + 1;
					}
					else
					{
						lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
					}
				}
			}

			Console.WriteLine(lcs[lcs.GetLength(0) - 1, lcs.GetLength(1) - 1]);
        }
	}
}
