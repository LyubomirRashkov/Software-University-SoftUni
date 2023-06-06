using System;

namespace _04.RecursiveFactorial
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			long factorial = CalculateFactorial(n);

            Console.WriteLine(factorial);
        }

		private static int CalculateFactorial(int n)
		{
			if (n == 0)
			{
				return 1;
			}

			return n * CalculateFactorial(n - 1);
		}
	}
}
