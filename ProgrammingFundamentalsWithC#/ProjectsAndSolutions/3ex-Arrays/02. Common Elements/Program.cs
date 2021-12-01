using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] secondArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (secondArray[i] == firstArray[j])
                    {
                        Console.Write(secondArray[i] + " ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
