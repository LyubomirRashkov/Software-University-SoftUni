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

			int[] increasingLengths = new int[numbers.Length];

			int[] decreasingLengths = new int[numbers.Length];

			int[] increasingPreviousOnes = new int[numbers.Length];

			int[] decreasingPreviousOnes = new int[numbers.Length];

			int bestIndex = 0;

			bool isIncreasingBetter = false;

			FillArrays(
				numbers,
				increasingLengths,
				decreasingLengths,
				increasingPreviousOnes,
				decreasingPreviousOnes,
				ref bestIndex,
				ref isIncreasingBetter);

			Stack<int> elements = new Stack<int>();

			if (isIncreasingBetter)
			{
				elements = GetElements(numbers, increasingPreviousOnes, bestIndex);
			}
			else
			{
				elements = GetElements(numbers, decreasingPreviousOnes, bestIndex);
			}

			Console.WriteLine(string.Join(' ', elements));
		}

		private static Stack<int> GetElements(int[] numbers, int[] previousOnes, int index)
		{
			Stack<int> elements = new Stack<int>();

			while (index != -1)
			{
				elements.Push(numbers[index]);

				index = previousOnes[index];
			}

			return elements;
		}

		private static void FillArrays(
			int[] numbers,
			int[] increasingLengths,
			int[] decreasingLengths,
			int[] increasingPreviousOnes,
			int[] decreasingPreviousOnes,
			ref int bestIndex,
			ref bool isIncreasingBetter)
		{
			int bestIncreasingLength = 0;

			int bestDecreasingLength = 0;

			int indexOfIncreasingNumber = 0;

			int indexOfDecreasingNumber = 0;

			for (int i = 0; i < numbers.Length; i++)
			{
				int currentNumber = numbers[i];

				int currentIncreasingLength = 1;

				int currentIncreasinsParent = -1;

				int currentDecreasingLength = 1;

				int currentDecreasingParent = -1;

				for (int j = 0; j < i; j++)
				{
					if (numbers[j] < currentNumber && increasingLengths[j] + 1 > currentIncreasingLength)
					{
						currentIncreasingLength = increasingLengths[j] + 1;

						currentIncreasinsParent = j;
					}
					else if (numbers[j] > currentNumber && decreasingLengths[j] + 1 >= currentDecreasingLength)
					{
						currentDecreasingLength = decreasingLengths[j] + 1;

						currentDecreasingParent = j;
					}
				}

				increasingLengths[i] = currentIncreasingLength;

				increasingPreviousOnes[i] = currentIncreasinsParent;

				decreasingLengths[i] = currentDecreasingLength;

				decreasingPreviousOnes[i] = currentDecreasingParent;

				if (currentIncreasingLength > bestIncreasingLength)
				{
					bestIncreasingLength = currentIncreasingLength;

					indexOfIncreasingNumber = i;
				}

				if (currentDecreasingLength > bestDecreasingLength)
				{
					bestDecreasingLength = currentDecreasingLength;

					indexOfDecreasingNumber = i;
				}
			}

			if (bestIncreasingLength > bestDecreasingLength)
			{
				bestIndex = indexOfIncreasingNumber;

				isIncreasingBetter = true;
			}
			else
			{
				bestIndex = indexOfDecreasingNumber;

				isIncreasingBetter = false;
			}
		}
	}
}
