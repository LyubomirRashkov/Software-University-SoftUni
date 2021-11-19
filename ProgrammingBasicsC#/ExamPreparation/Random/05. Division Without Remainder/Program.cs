using System;

namespace _05._Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentNumber = 0;
            int counterp2 = 0;
            int counterp3 = 0;
            int counterp4 = 0;

            for (int i = 1; i <= n; i++)
            {
                currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0)
                {
                    counterp2++;
                }
                if (currentNumber % 3 == 0)
                {
                    counterp3++;
                }
                if (currentNumber % 4 == 0)
                {
                    counterp4++;
                }
            }

            Console.WriteLine($"{((counterp2 * 100.0) / n):f2}%");
            Console.WriteLine($"{((counterp3 * 100.0) / n):f2}%");
            Console.WriteLine($"{((counterp4 * 100.0) / n):f2}%");
        }
    }
}
