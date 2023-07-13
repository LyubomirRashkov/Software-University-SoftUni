using System;
using System.Linq;

namespace _09.Numbers
{
	public class Program
	{
		private static int number;
		private static int[] elements;
		private static int[] combinations;

		public static void Main(string[] args)
		{
			number = int.Parse(Console.ReadLine());

			elements = Enumerable.Range(1, number)
				.Reverse()
				.ToArray();

			for (int i = 1; i <= number; i++)
			{
				combinations = new int[i];

				GenerateCombinations(0, 0);
			}
		}

		private static void GenerateCombinations(int index, int startIndex)
		{
			if (index == combinations.Length)
			{
				PrintSolution(combinations, number);

				return;
			}

			if (combinations.Sum() > number)
			{
				return;
			}

			for (int i = startIndex; i < elements.Length; i++)
			{
				combinations[index] = elements[i];

				GenerateCombinations(index + 1, i);
			}
		}

		private static void PrintSolution(int[] combination, int number)
		{
			if (combination.Sum() == number)
			{
				Console.WriteLine(string.Join(" + ", combination));
			}
		}
	}
}
