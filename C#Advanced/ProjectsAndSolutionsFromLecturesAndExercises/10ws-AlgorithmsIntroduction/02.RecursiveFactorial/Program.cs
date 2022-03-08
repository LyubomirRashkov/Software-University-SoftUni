using System;

namespace _02.RecursiveFactorial
{
    public class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            long factorial = GetFactorial(number);

            Console.WriteLine(factorial);
        }

        private static long GetFactorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * GetFactorial(number - 1);
        }
    }
}
