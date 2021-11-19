using System;

namespace _09._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int volume = width * length * height;
            int cartoonsVolume = 0;

            string input = Console.ReadLine();

            while (input != "Done")
            {
                int numOfCartoons = int.Parse(input);

                cartoonsVolume += numOfCartoons;

                if (cartoonsVolume >= volume)
                {
                    Console.WriteLine($"No more free space! You need {cartoonsVolume - volume} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
            }

            if (input == "Done")
            {
                Console.WriteLine($"{volume - cartoonsVolume} Cubic meters left.");
            }
        }
    }
}
