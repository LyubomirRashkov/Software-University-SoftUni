using System;

namespace _01.SquareRoot
{
    public class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                CalculateSquareRoot(number);
                Console.WriteLine(CalculateSquareRoot(number));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        private static double CalculateSquareRoot(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }

            return Math.Sqrt(number);
        }
    }
}
