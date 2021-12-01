using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            bool areEqual = false;

            for (int i = 0; i < input.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += input[j];
                }

                for (int k = i + 1; k < input.Length; k++)
                {
                    rightSum += input[k];
                }

                if (leftSum == rightSum)
                {
                    areEqual = true;
                    Console.WriteLine(i);
                }
            }

            if (!areEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}
