using System;

namespace _04._Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int wallHeight = int.Parse(Console.ReadLine());
            int wallWidth = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int allLitres = 0;

            double allClearWalls = Math.Ceiling((wallHeight * wallWidth) * 4 - (percent / 100) * ((wallHeight * wallWidth) * 4));

            while (input != "Tired!")
            {
                int litres = int.Parse(input);

                allLitres += litres;

                if (allLitres > allClearWalls)
                {
                    Console.WriteLine($"All walls are painted and you have {allLitres - allClearWalls} l paint left!");
                    break;
                }
                else if (allLitres == allClearWalls)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "Tired!")
            {
                Console.WriteLine($"{allClearWalls - allLitres} quadratic m left.");
            }
        }
    }
}
