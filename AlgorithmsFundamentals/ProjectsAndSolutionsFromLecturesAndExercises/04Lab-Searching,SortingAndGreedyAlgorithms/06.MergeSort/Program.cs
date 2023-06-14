using System;
using System.Linq;

namespace _06.MergeSort
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] sortedNumbers = MergeSort(numbers);

            Console.WriteLine(string.Join(' ', sortedNumbers));
        }

		private static int[] MergeSort(int[] numbers)
		{
			if (numbers.Length <= 1)
			{
				return numbers;
			}

			int[] leftSubArray = numbers.Take(numbers.Length / 2).ToArray();

			int[] rightSubArray = numbers.Skip(numbers.Length / 2).ToArray();

			return Merge(MergeSort(leftSubArray), MergeSort(rightSubArray));
		}

		private static int[] Merge(int[] leftArray, int[] rightArray)
		{
			int[] mergedArray = new int[leftArray.Length + rightArray.Length];

			int mergedIndex= 0;

			int leftIndex = 0;

			int rightIndex = 0;

			while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
			{
				if (leftArray[leftIndex] < rightArray[rightIndex])
				{
					mergedArray[mergedIndex++] = leftArray[leftIndex++];
				}
				else
				{
					mergedArray[mergedIndex++] = rightArray[rightIndex++];
				}
			}

			for (int i = leftIndex; i < leftArray.Length; i++)
			{
				mergedArray[mergedIndex++] = leftArray[i];
			}

			for (int i = rightIndex; i < rightArray.Length; i++)
			{
				mergedArray[mergedIndex++] = rightArray[i];
			}

			return mergedArray;
		}
	}
}
