using System;

namespace _06._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                if (number % i == 0)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        if (number % j == 0)
                        {
                            for (int k = 1; k <= 9; k++)
                            {
                                if (number % k == 0)
                                {
                                    for (int l = 1; l <= 9; l++)
                                    {
                                        if (number % l == 0)
                                        {
                                            Console.Write($"{i}{j}{k}{l} ");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
