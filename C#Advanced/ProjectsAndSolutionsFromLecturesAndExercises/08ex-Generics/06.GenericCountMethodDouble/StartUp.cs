using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<double> inputs = new List<double>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                double input = double.Parse(Console.ReadLine());

                inputs.Add(input);
            }

            double elementToCompareWith = double.Parse(Console.ReadLine());

            int countOfGreaterElements = Box.CountOfGreaterElements(inputs, elementToCompareWith);

            Console.WriteLine(countOfGreaterElements);
        }
    }
}
