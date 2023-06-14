using System;
using System.Linq;

namespace _02.SelectionSort
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			SelectionSort(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

		private static void SelectionSort(int[] numbers)
		{
			for (int i = 0; i < numbers.Length; i++)
			{
				int indexOfMinElement = i;

				for (int j = i + 1; j < numbers.Length; j++)
				{
					if (numbers[j] < numbers[indexOfMinElement])
					{
						indexOfMinElement = j;
					}
				}

				Swap(numbers, i, indexOfMinElement);
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
