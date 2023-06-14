using System;
using System.Linq;

namespace _04.InsertionSort
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			InsertionSort(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

		private static void InsertionSort(int[] numbers)
		{
			for (int i = 1; i < numbers.Length; i++)
			{
				int current = i;

				while (current > 0 && numbers[current - 1] > numbers[current])
				{
					Swap(numbers, current, current - 1);

					current--;
				}
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
