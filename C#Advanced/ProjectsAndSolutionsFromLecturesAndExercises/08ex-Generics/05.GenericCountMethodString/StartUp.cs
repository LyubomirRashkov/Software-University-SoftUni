using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<string> inputs = new List<string>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                inputs.Add(input);
            }

            string elementToCompareWith = Console.ReadLine();

            int countOfGreaterElements = Box.CountOfGreaterElements(inputs, elementToCompareWith);

            Console.WriteLine(countOfGreaterElements);
        }
    }
}
