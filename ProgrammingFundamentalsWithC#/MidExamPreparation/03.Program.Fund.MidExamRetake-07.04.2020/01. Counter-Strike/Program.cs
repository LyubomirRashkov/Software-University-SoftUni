using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            int winsCount = 0;

            bool hasEnergy = true;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End of battle")
                {
                    break;
                }

                int distance = int.Parse(line);

                if (energy < distance)
                {
                    hasEnergy = false;
                    Console.WriteLine($"Not enough energy! Game ends with {winsCount} won battles and {energy} energy");
                    break;
                }
                else
                {
                    energy -= distance;
                    winsCount++;
                }

                if (winsCount % 3 == 0)
                {
                    energy += winsCount;
                }
            }

            if (hasEnergy)
            {
                Console.WriteLine($"Won battles: {winsCount}. Energy left: {energy}");
            }
        }
    }
}
