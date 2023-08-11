using System;
using System.Collections.Generic;

namespace _03.LongestStringChain
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string[] strs = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			int[] lengths = new int[strs.Length];

			int[] previousOnes = new int[strs.Length];

			int indexOfLastAddedString = -1;

			FillArrays(strs, lengths, previousOnes, ref indexOfLastAddedString);

			Stack<string> elements = GetElements(strs, previousOnes, indexOfLastAddedString);

            Console.WriteLine(string.Join(' ', elements));
        }

		private static Stack<string> GetElements(string[] strs, int[] previousOnes, int indexOfLastAddedString)
		{
			Stack<string> elements = new Stack<string>();

			while (indexOfLastAddedString != -1)
			{
				elements.Push(strs[indexOfLastAddedString]);

				indexOfLastAddedString = previousOnes[indexOfLastAddedString];
			}

			return elements;
		}

		private static void FillArrays(string[] strs, int[] lengths, int[] previousOnes, ref int indexOfLastAddedString)
		{
			int bestLength = 0;

			for (int i = 0; i < strs.Length; i++)
			{
				string currentString = strs[i];

				int currentLength = 1;

				int currentParent = -1;

				for (int j = 0; j < i; j++)
				{
					if (strs[j].Length < currentString.Length && lengths[j] + 1 > currentLength)
					{
						currentLength = lengths[j] + 1;

						currentParent = j;
					}
				}

				lengths[i] = currentLength;

				previousOnes[i] = currentParent;

				if (currentLength > bestLength)
				{
					bestLength = currentLength;

					indexOfLastAddedString = i;
				}
			}
		}
	}
}
