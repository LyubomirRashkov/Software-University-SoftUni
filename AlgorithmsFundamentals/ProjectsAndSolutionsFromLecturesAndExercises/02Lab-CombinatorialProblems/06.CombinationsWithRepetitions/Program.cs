using System;
using System.Linq;

namespace _06.CombinationsWithRepetitions
{
	public class Program
	{
		private static int k;
		private static char[] elements;
		private static char[] combinations;

		public static void Main(string[] args)
		{
			elements = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(char.Parse)
				.ToArray();

			k = int.Parse(Console.ReadLine());

			combinations = new char[k];

			GenerateCombinations(0, 0);
		}

		private static void GenerateCombinations(int index, int elementsStartIndex)
		{
			if (index == combinations.Length)
			{
                Console.WriteLine(string.Join(' ', combinations));

				return;
            }

			for (int i = elementsStartIndex; i < elements.Length; i++)
			{
				combinations[index] = elements[i];

				GenerateCombinations(index + 1, i);
			}
		}
	}
}
