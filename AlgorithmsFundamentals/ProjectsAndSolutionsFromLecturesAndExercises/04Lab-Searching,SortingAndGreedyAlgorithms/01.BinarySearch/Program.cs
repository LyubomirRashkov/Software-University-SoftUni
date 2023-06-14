using System;
using System.Linq;

namespace _01.BinarySearch
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int targetNumber = int.Parse(Console.ReadLine());

			int index = BinarySearch(numbers, targetNumber);

			Console.WriteLine(index);
        }

		private static int BinarySearch(int[] numbers, int targetNumber)
		{
			int leftIndex = 0;

			int rightIndex = numbers.Length - 1;

			while (leftIndex <= rightIndex)
			{
				int middleIndex = (leftIndex + rightIndex) / 2;

				if (targetNumber == numbers[middleIndex])
				{
					return middleIndex;
				}

				if (targetNumber < numbers[middleIndex])
				{
					rightIndex = middleIndex - 1;
				}
				else
				{
					leftIndex = middleIndex + 1;
				}
			}

			return -1;
		}
	}
}
