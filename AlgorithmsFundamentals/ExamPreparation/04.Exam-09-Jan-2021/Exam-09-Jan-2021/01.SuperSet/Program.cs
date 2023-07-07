using System;
using System.Linq;

namespace _01.SuperSet
{
	public class Program
	{
		private static int[] numbers;

		public static void Main(string[] args)
		{
			numbers = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			for (int i = 1; i <= numbers.Length; i++)
			{
				int[] combinations = new int[i];

				GenerateCombinations(0, 0, combinations);
			}
		}

		private static void GenerateCombinations(int index, int elementsStartIndex, int[] combinations)
		{
			if (index >= combinations.Length)
			{
				Console.WriteLine(string.Join(' ', combinations));

				return;
			}

			for (int i = elementsStartIndex; i < numbers.Length; i++)
			{
				combinations[index] = numbers[i];

				GenerateCombinations(index + 1, i + 1, combinations);
			}
		}
	}
}
