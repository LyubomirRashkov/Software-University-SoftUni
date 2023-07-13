using System;
using System.Linq;

namespace _01.AlphaDecay
{
	public class Program
	{
		private static int[] elements;
		private static int[] variations;
		private static bool[] used;

		public static void Main(string[] args)
		{
			elements = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int k = int.Parse(Console.ReadLine());

			variations = new int[k];

			used = new bool[elements.Length];

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
				if (!used[i])
				{
					used[i] = true;

					variations[index] = elements[i];

					GenerateVariations(index + 1);

					used[i] = false;
				}
			}
		}
	}
}
