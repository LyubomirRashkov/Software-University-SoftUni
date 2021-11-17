using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int sumOfAllPrimeNumbers = 0;
            int sumOfAllNonprimeNumbers = 0;

            while (input != "stop")
            {
                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    int counter = 0;

                    for (int i = 2; i < number; i++)
                    {
                        int remainder = number % i;

                        if (remainder == 0)
                        {
                            sumOfAllNonprimeNumbers += number;
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                    }

                    if (counter == number - 2)
                    {
                        sumOfAllPrimeNumbers += number;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumOfAllPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOfAllNonprimeNumbers}");
        }
    }
}
