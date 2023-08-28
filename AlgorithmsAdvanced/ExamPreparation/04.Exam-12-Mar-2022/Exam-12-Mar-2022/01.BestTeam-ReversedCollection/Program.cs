using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BestTeam
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] reverseNumbers = numbers.Reverse().ToArray();

			Stack<int> LISElements = GetElements(numbers);

			Stack<int> LDSElements = GetElements(reverseNumbers);

			if (LISElements.Count > LDSElements.Count)
			{
				Console.WriteLine(string.Join(' ', LISElements));
			}
			else
			{
				Console.WriteLine(string.Join(' ', LDSElements.Reverse()));
			}
		}

		private static Stack<int> GetElements(int[] numbers)
		{
			int[] lengths = new int[numbers.Length];

			int[] previousOnes = new int[numbers.Length];

			int indexOfLastAddedNumber = -1;

			FillArrays(numbers, lengths, previousOnes, ref indexOfLastAddedNumber);

			Stack<int> elements = RetrieveElements(numbers, previousOnes, indexOfLastAddedNumber);

			return elements;
		}

		private static Stack<int> RetrieveElements(int[] numbers, int[] previousOnes, int indexOfLastAddedNumber)
		{
			Stack<int> elements = new Stack<int>();

			while (indexOfLastAddedNumber != -1)
			{
				elements.Push(numbers[indexOfLastAddedNumber]);

				indexOfLastAddedNumber = previousOnes[indexOfLastAddedNumber];
			}

			return elements;
		}

		private static void FillArrays(
			int[] numbers,
			int[] lengths,
			int[] previousOnes,
			ref int indexOfLastAddedNumber)
		{
			int bestLength = 0;

			for (int i = 0; i < numbers.Length; i++)
			{
				int currentLength = 1;

				int currentParent = -1;

				for (int j = 0; j < i; j++)
				{
					if (numbers[i] > numbers[j] && lengths[j] + 1 > currentLength)
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

					indexOfLastAddedNumber = i;
				}
			}
		}
	}
}