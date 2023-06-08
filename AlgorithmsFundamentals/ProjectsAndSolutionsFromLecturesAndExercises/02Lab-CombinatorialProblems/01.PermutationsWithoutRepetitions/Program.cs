using System;
using System.Linq;

namespace _01.PermutationsWithoutRepetitions
{
	public class Program
	{
		private static char[] elements;

		public static void Main(string[] args)
		{
			elements = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(char.Parse)
				.ToArray();

			Permute(0);
		}

		private static void Permute(int index)
		{
			if (index == elements.Length)
			{
				Console.WriteLine(string.Join(' ', elements));

				return;
            }

			Permute(index + 1);

			for (int i = index + 1; i < elements.Length; i++)
			{
				Swap(index, i);

				Permute(index + 1);

				Swap(index, i);
			}
		}

		private static void Swap(int firstIndex, int secondIndex)
		{
			char temp = elements[firstIndex];

			elements[firstIndex] = elements[secondIndex];

			elements[secondIndex] = temp;
		}
	}
}
