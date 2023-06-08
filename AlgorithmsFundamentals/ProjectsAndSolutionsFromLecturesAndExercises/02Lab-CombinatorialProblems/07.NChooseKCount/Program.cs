using System;

namespace _07.NChooseKCount
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int k = int.Parse(Console.ReadLine());

			long count = CalculateNumberOfCombinationsWithoutRepetitions(n, k);

            Console.WriteLine(count);
        }

		private static long CalculateNumberOfCombinationsWithoutRepetitions(int row, int col)
		{
			if (row <= 1 || col == 0 || col == row)
			{
				return 1;
			}

			return CalculateNumberOfCombinationsWithoutRepetitions(row - 1, col - 1) 
				+ CalculateNumberOfCombinationsWithoutRepetitions(row - 1, col);
		}
	}
}
