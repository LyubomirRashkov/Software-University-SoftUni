using System;
using System.Collections.Generic;

namespace _01.BinomialCoefficients
{
	public class Program
	{
		private static Dictionary<string, long> coefficientByRowAndCol;

		public static void Main(string[] args)
		{
			int row = int.Parse(Console.ReadLine());

			int col = int.Parse(Console.ReadLine());

			coefficientByRowAndCol = new Dictionary<string, long>();

			long coefficient = GetBinomialCoefficient(row, col);

			Console.WriteLine(coefficient);
        }

		private static long GetBinomialCoefficient(int row, int col)
		{
			if (row == 0 || col == 0 || col == row)
			{
				return 1;
			}

			string key = $"{row}-{col}";

			if (coefficientByRowAndCol.ContainsKey(key))
			{
				return coefficientByRowAndCol[key];
			}

			long result = GetBinomialCoefficient(row - 1, col - 1) + GetBinomialCoefficient(row - 1, col);

			coefficientByRowAndCol.Add(key, result);

			return result;
		}
	}
}
