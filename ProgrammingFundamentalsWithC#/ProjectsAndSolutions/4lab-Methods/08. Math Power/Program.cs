using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = RaiseToPower(number, power);

            Console.WriteLine(result);
        }

        private static double RaiseToPower(double number, int power)
        {
            double result;

            if (power < 0)
            {
                result = 1 / number;

                for (int i = 1; i < Math.Abs(power); i++)
                {
                    result *= (1 / number);
                }
            }
            else if (power == 0)
            {
                result = 1;
            }
            else
            {
                result = number;

                for (int i = 1; i < power; i++)
                {
                    result *= number;
                }
            }

            return result;
        }
    }
}
