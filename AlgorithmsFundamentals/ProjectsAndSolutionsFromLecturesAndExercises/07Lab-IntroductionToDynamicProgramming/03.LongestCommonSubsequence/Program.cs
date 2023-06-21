using System;
using System.Collections.Generic;

namespace _03.LongestCommonSubsequence
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string str1 = Console.ReadLine();

			string str2 = Console.ReadLine();

			int[,] lcs = new int[str1.Length + 1, str2.Length + 1];

			for (int r = 1; r < lcs.GetLength(0); r++)
			{
				for (int c = 1; c < lcs.GetLength(1); c++)
				{
					if (str1[r - 1] == str2[c - 1])
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

			/*
			int row = lcs.GetLength(0) - 1;

			int col = lcs.GetLength(1) - 1;

			Stack<char> commonSymbols = new Stack<char>();

			while (row > 0 && col > 0)
			{
				if (str1[row - 1] == str2[col - 1])
				{
					commonSymbols.Push(str1[row - 1]);

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

			Console.WriteLine(string.Join("", commonSymbols));
			*/
		}
	}
}
