using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[] firstArray = new int[rows];
            int[] secondArray = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int[] currentArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArray[i] = currentArray[0];
                    secondArray[i] = currentArray[1];
                }
                else
                {
                    firstArray[i] = currentArray[1];
                    secondArray[i] = currentArray[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}
