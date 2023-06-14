using System;
using System.Linq;

namespace _05.QuickSort
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			QuickSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(' ', numbers));
        }

		private static void QuickSort(int[] numbers, int startIndex, int endIndex)
		{
			if (startIndex >= endIndex)
			{
				return;
			}

			int pivotIndex = startIndex;

			int leftIndex = pivotIndex + 1;

			int rightIndex = endIndex;

			while (leftIndex <= rightIndex)
			{
				if (numbers[leftIndex] > numbers[pivotIndex] && numbers[rightIndex] < numbers[pivotIndex])
				{
					Swap(numbers, leftIndex, rightIndex);
				}

				if (numbers[leftIndex] <= numbers[pivotIndex])
				{
					leftIndex++;
				}

				if (numbers[rightIndex] >= numbers[pivotIndex])
				{
					rightIndex--;
				}
			}

			Swap(numbers, pivotIndex, rightIndex);

			int countsOfElementsInLeftSubArray = (rightIndex - 1) - startIndex;

			int countOfElementsInRightSubArray = endIndex - (rightIndex + 1);

			if (countsOfElementsInLeftSubArray < countOfElementsInRightSubArray)
			{
				QuickSort(numbers, startIndex, rightIndex - 1);

				QuickSort(numbers, rightIndex + 1, endIndex);
			}
			else
			{
				QuickSort(numbers, rightIndex + 1, endIndex);

				QuickSort(numbers, startIndex, rightIndex - 1);
			}
		}

		private static void Swap(int[] numbers, int firstIndex, int secondIndex)
		{
			int temp = numbers[firstIndex];

			numbers[firstIndex] = numbers[secondIndex];

			numbers[secondIndex] = temp;
		}
	}
}
