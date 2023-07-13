using System;
using System.Linq;
using System.Text;

namespace _05.MonkeyBusiness
{
	public class Program
	{
		private static int counter = 0;
		private static readonly StringBuilder sb = new StringBuilder();

		public static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());

			int[] numbers = Enumerable.Range(1, number).ToArray();

			Generate(0, numbers);

			Console.WriteLine(sb.ToString().Trim());

			Console.WriteLine($"Total Solutions: {counter}");
		}

		private static void Generate(int index, int[] numbers)
		{
			if (index == numbers.Length)
			{
				PrintSolution(numbers);

				return;
			}

			for (int i = 0; i < 2; i++)
			{
				if (i == 0)
				{
					numbers[index] = Math.Abs(numbers[index]);
				}
				else
				{
					numbers[index] = 0 - numbers[index];
				}

				Generate(index + 1, numbers);
			}
		}

		private static void PrintSolution(int[] arr)
		{
			if (arr.Sum() == 0)
			{
				counter++;

				for (int i = 0; i < arr.Length; i++)
				{
					if (arr[i] > 0)
					{
						sb.Append($"+{arr[i].ToString()} ");
					}
					else
					{
						sb.Append($"{arr[i].ToString()} ");
					}
				}

				sb.AppendLine();
			}
		}
	}
}
