using System;

namespace _01.MoveDown_Right_IterativeWithArray
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());

			int cols = int.Parse(Console.ReadLine());

			long[] arr = new long[cols];

			Array.Fill(arr, 1);

			for (int i = 1; i < rows; i++)
			{
				for (int j = 1; j < cols; j++)
				{
					arr[j] += arr[j - 1];
				}
			}

			Console.WriteLine(arr[^1]);
        }
	}
}
