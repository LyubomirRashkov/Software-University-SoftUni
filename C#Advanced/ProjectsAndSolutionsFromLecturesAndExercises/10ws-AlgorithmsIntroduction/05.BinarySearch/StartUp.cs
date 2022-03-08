using System;
using System.Linq;

namespace _05.BinarySearch
{
    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

            int elementToLookFor = int.Parse(Console.ReadLine());

            int indexOfElementToLookFor = BinarySearch(numbers, elementToLookFor);

            Console.WriteLine(indexOfElementToLookFor);
        }

        private static int BinarySearch(int[] numbers, int elementToLookFor)
        {
            int lowBoundaryIndex = 0;
            int highBoundaryIndex = numbers.Length - 1;

            while (lowBoundaryIndex <= highBoundaryIndex)
            {
                int midIndex = (lowBoundaryIndex + highBoundaryIndex) / 2;

                if (elementToLookFor > numbers[midIndex])
                {
                    lowBoundaryIndex = midIndex + 1;
                }
                else if (elementToLookFor < numbers[midIndex])
                {
                    highBoundaryIndex = midIndex - 1;
                }
                else
                {
                    return midIndex;
                }
            }

            return -1;
        }
    }
}
