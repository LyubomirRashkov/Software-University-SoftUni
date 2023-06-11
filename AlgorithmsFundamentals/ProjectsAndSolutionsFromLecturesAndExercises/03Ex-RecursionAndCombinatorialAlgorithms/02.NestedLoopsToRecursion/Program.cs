using System;

namespace _02.NestedLoopsToRecursion
{
	public class Program
	{
		private static int[] arr;

		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			arr = new int[n];

			GenerateArrays(0);
		}

		private static void GenerateArrays(int index)
		{
			if (index == arr.Length)
			{
                Console.WriteLine(string.Join(' ', arr));

				return;
            }

			for (int i = 1; i <= arr.Length; i++)
			{
				arr[index] = i;

				GenerateArrays(index + 1);
			}
		}
	}
}
