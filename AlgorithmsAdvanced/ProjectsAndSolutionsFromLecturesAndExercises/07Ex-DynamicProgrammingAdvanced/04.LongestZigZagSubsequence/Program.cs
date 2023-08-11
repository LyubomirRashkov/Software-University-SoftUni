﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LongestZigZagSubsequence
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[,] dp = new int[2, numbers.Length];

			int[,] previousOnes = new int[2, numbers.Length];

			int rowOfLastAddedIndex = -1;

			int indexOfLastAddedNumber = -1;

			FillMatrices(numbers, dp, previousOnes, ref rowOfLastAddedIndex, ref indexOfLastAddedNumber);

			Stack<int> elements = GetElements(numbers, previousOnes, rowOfLastAddedIndex, indexOfLastAddedNumber);

            Console.WriteLine(string.Join(' ', elements));
        }

		private static Stack<int> GetElements(
			int[] numbers, 
			int[,] previousOnes,
			int rowOfLastAddedIndex, 
			int indexOfLastAddedNumber)
		{
			Stack<int> elements = new Stack<int>();

			while (indexOfLastAddedNumber != -1)
			{
				elements.Push(numbers[indexOfLastAddedNumber]);

				indexOfLastAddedNumber = previousOnes[rowOfLastAddedIndex, indexOfLastAddedNumber];

				rowOfLastAddedIndex = rowOfLastAddedIndex == 0 ? 1 : 0;
			}

			return elements;
		}

		private static void FillMatrices(
			int[] numbers,
			int[,] dp,
			int[,] previousOnes,
			ref int rowOfLastAddedIndex,
			ref int indexOfLastAddedNumber)
		{
			dp[0, 0] = dp[1, 0] = 1;

			previousOnes[0, 0] = previousOnes[1, 0] = -1;

			int bestLength = 0;

			for (int i = 1; i < numbers.Length; i++)
			{
				for (int j = i - 1; j >= 0; j--)
				{
					if (numbers[i] > numbers[j] && dp[1, j] + 1 >= dp[0, i])
					{
						dp[0, i] = dp[1, j] + 1;

						previousOnes[0, i] = j;
					}

					if (numbers[i] < numbers[j] && dp[0, j] + 1 >= dp[1, i])
					{
						dp[1, i] = dp[0, j] + 1;

						previousOnes[1, i] = j;
					}
				}

				if (dp[0, i] > bestLength)
				{
					bestLength = dp[0, i];

					indexOfLastAddedNumber = i;

					rowOfLastAddedIndex = 0;
				}

				if (dp[1, i] > bestLength)
				{
					bestLength = dp[1, i];

					indexOfLastAddedNumber = i;

					rowOfLastAddedIndex = 1;
				}
			}
		}
	}
}
