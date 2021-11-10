using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                leftSum += currentNumber;
            }

            for (int i = n + 1; i <= 2 * n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                rightSum += currentNumber;
            }

            int diff = Math.Abs(leftSum - rightSum);

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
