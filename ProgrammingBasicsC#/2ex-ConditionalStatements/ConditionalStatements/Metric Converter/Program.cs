using System;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputUnitOfMeasure = Console.ReadLine();
            string outputUnitOfMeasure = Console.ReadLine();

            double newNumberInMeters = 0;
            double newNumberInCentimeters = 0;
            double newNumberInMilimeters = 0;

            if (inputUnitOfMeasure == "m")
            {
                newNumberInMeters = number;
                newNumberInCentimeters = number * 100;
                newNumberInMilimeters = number * 1000;
            }
            else if (inputUnitOfMeasure == "cm")
            {
                newNumberInMeters = number * 0.01;
                newNumberInCentimeters = number;
                newNumberInMilimeters = number * 10;
            }
            else if (inputUnitOfMeasure == "mm")
            {
                newNumberInMeters = number * 0.001;
                newNumberInCentimeters = number * 0.1;
                newNumberInMilimeters = number;
            }

            if (outputUnitOfMeasure == "m")
            {
                Console.WriteLine("{0:f3}", newNumberInMeters);
            }
            else if (outputUnitOfMeasure == "cm")
            {
                Console.WriteLine("{0:f3}",newNumberInCentimeters);
            }
            else if (outputUnitOfMeasure == "mm")
            {
                Console.WriteLine("{0:f3}",newNumberInMilimeters);
            }
        }
    }
}
