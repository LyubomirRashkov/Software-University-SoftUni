using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            while (numbers.Length > 1)
            {
                int[] condensedNumbers = new int[numbers.Length - 1];

                for (int i = 0; i < numbers.Length-1; i++)
                {
                    condensedNumbers[i] = numbers[i] + numbers[i + 1];
                }

                numbers = condensedNumbers;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
