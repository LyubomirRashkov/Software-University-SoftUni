using System;

namespace _03.Generating0_1Vectors
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int[] vector = new int[n];

			GenerateVectors(vector, 0);
		}

		private static void GenerateVectors(int[] vector, int index)
		{
			if (index == vector.Length)
			{
                Console.WriteLine(string.Join(string.Empty, vector));

                return;
			}

			for (int i = 0; i < 2; i++)
			{
				vector[index] = i;

				GenerateVectors(vector, index + 1);
			}
		}
	}
}
