using System;

namespace _01.StringsMashup
{
	public class Program
	{
		private static char[] symbols;
		private static char[] combinations;

		public static void Main(string[] args)
		{
			symbols = Console.ReadLine().ToCharArray();

			Array.Sort(symbols);

			int n = int.Parse(Console.ReadLine());

			combinations = new char[n];

			GenerateCombinations(0, 0);
		}

		private static void GenerateCombinations(int index, int elementsStartIndex)
		{
			if (index == combinations.Length)
			{
                Console.WriteLine(string.Join("", combinations));

				return;
            }

			for (int i = elementsStartIndex; i < symbols.Length; i++)
			{
				combinations[index] = symbols[i];

				GenerateCombinations(index + 1, i);
			}
		}
	}
}
