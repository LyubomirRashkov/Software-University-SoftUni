using System;
using System.Linq;

namespace _03.BubbleSort
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			BubbleSort(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

		private static void BubbleSort(int[] numbers)
		{
			int countOfSortedElements = 0;

			bool isSorted = false;

			while (!isSorted)
			{
				isSorted = true;

				for (int i = 1; i < numbers.Length - countOfSortedElements; i++)
				{
					int previousIndex = i - 1;

					if (numbers[previousIndex] > numbers[i])
					{
						Swap(numbers, previousIndex, i);

						isSorted = false;
					}
				}

				countOfSortedElements++;
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
