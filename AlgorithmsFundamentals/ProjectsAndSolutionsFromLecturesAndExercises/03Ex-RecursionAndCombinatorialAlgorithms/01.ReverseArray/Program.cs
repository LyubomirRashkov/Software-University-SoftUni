using System;

namespace _01.ReverseArray
{
	public class Program
	{
		private static string[] elements;

		public static void Main(string[] args)
		{
			elements = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			RecursiveReverse(0);
		}

		private static void RecursiveReverse(int index)
		{
			if (index == elements.Length / 2)
			{
                Console.WriteLine(string.Join(' ', elements));

				return;
            }

			Swap(index, elements.Length - 1 - index);

			RecursiveReverse(index + 1);
		}

		private static void Swap(int firstIndex, int secondIndex)
		{
			string temp = elements[firstIndex];

			elements[firstIndex] = elements[secondIndex];

			elements[secondIndex] = temp;
		}
	}
}
