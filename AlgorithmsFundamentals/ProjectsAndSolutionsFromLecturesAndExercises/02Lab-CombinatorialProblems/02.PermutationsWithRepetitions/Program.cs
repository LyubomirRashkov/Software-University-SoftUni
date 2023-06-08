using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PermutationsWithRepetitions
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

			HashSet<char> used = new HashSet<char> { elements[index] };

			for (int i = index + 1; i < elements.Length; i++)
			{
				if (!used.Contains(elements[i]))
				{
					Swap(index, i);

					Permute(index + 1);

					Swap(index, i);

					used.Add(elements[i]);
				}
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
