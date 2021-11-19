using System;

namespace _05._Suitcases_Load
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalSpace = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int counter = 0;
            double requiredSpace = 0;

            while (input != "End")
            {
                double suitcaseVolume = double.Parse(input);
                counter++;

                if (counter % 3 == 0)
                {
                    suitcaseVolume *= 1.1;
                }

                if ((totalSpace - requiredSpace) < suitcaseVolume)
                {
                    counter--;
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {counter} suitcases loaded.");
                    return;
                }

                requiredSpace += suitcaseVolume;

                input = Console.ReadLine();
            }

            if (input == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {counter} suitcases loaded.");
        }
    }
}
