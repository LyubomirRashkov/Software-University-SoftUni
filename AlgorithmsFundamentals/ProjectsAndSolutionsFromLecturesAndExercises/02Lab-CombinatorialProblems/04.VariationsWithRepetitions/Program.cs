using System;
using System.Linq;

namespace _04.VariationsWithRepetitions
{
	public class Program
	{
		private static int k;
		private static char[] elements;
		private static char[] variations;

		public static void Main(string[] args)
		{
			elements = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(char.Parse)
				.ToArray();

			k = int.Parse(Console.ReadLine());

			variations = new char[k];

			GenerateVariations(0);
		}

		private static void GenerateVariations(int index)
		{
			if (index == variations.Length)
			{
                Console.WriteLine(string.Join(' ', variations));

				return;
            }

			for (int i = 0; i < elements.Length; i++)
			{
				variations[index] = elements[i];

				GenerateVariations(index + 1);
			}
		}
	}
}
