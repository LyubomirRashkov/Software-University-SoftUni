using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        continue;
                    }

                    if (input[i] + input[j] == targetSum)
                    {
                        Console.Write(input[i] + " " + input[j]);
                        Console.WriteLine();
                        int targetj = input[j];
                    }
                }
            }
        }
    }
}
