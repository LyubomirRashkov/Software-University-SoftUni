using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sumOfTwo = Sum(firstNumber, secondNumber);
            int result = Subtract(sumOfTwo, thirdNumber);

            Console.WriteLine(result);
        }

        private static int Subtract(int firstNumber, int secondNumber)
        {
            return (firstNumber - secondNumber);
        }

        private static int Sum(int firstNumber, int secondNumber)
        {
            return (firstNumber + secondNumber);
        }
    }
}
