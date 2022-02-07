using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string inputLine = Console.ReadLine();

                box.Add(inputLine);
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
