using System;

namespace _05._Divide_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double numbersWhichAreDividedInto2 = 0;
            double numbersWhichAreDividedInto3 = 0;
            double numbersWhichAreDividedInto4 = 0;

            double p2 = 0;
            double p3 = 0;
            double p4 = 0;

            for (int i = 1; i <= n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0)
                {
                    numbersWhichAreDividedInto2 += 1;
                }
                if (currentNumber % 3 == 0)
                {
                    numbersWhichAreDividedInto3 += 1;
                }
                if (currentNumber % 4 == 0)
                {
                    numbersWhichAreDividedInto4 += 1;
                }
            }

            p2 = (numbersWhichAreDividedInto2 / n) * 100;
            p3 = (numbersWhichAreDividedInto3 / n) * 100;
            p4 = (numbersWhichAreDividedInto4 / n) * 100;

            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
        }
    }
}
