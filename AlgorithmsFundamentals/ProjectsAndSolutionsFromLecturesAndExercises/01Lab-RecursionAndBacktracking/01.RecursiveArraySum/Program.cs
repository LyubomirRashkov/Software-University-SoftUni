using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int sum = CalculateSum(numbers, 0);

            Console.WriteLine(sum);
        }

		private static int CalculateSum(int[] numbers, int index)
		{
			if (index == numbers.Length)
			{
				return 0;
			}

			return numbers[index] + CalculateSum(numbers, index + 1);
		}
	}
}
