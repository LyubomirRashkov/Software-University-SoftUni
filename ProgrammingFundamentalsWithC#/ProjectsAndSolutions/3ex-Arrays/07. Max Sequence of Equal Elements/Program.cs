using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int counter = 1;
            int element = 0;
            int maxCount = int.MinValue;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (maxCount < counter)
                {
                    maxCount = counter;
                    element = input[i];
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }
    }
}
