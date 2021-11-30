using System;

namespace _02_2._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());

            int[] numbers = new int[countOfNumbers];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[numbers.Length - 1 - i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
