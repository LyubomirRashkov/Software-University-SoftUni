using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                int currentInput = int.Parse(Console.ReadLine());

                box.Add(currentInput);
            }

            int[] indices = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indices[0];
            int secondIndex = indices[1];

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
