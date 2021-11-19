using System;

namespace _06._Vet_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double totalSum = 0;

            for (int i = 1; i <= days; i++)
            {
                double sum = 0;
                double add = 0;

                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        add = 2.50;
                        sum += add;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        add = 1.25;
                        sum += add;
                    }
                    else
                    {
                        add = 1;
                        sum += add;
                    }

                }
                totalSum += sum;
                Console.WriteLine($"Day: {i} - {sum:f2} leva");
            }

            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
