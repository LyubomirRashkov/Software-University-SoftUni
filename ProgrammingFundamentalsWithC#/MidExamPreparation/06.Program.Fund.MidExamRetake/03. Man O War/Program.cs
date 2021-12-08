using System;
using System.Linq;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] warship = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxHealth = int.Parse(Console.ReadLine());

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Retire")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Fire")
                {
                    int index = int.Parse(parts[1]);
                    int damage = int.Parse(parts[2]);

                    if (index >= 0 && index < warship.Length)
                    {
                        warship[index] -= damage;

                        if (warship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (parts[0] == "Defend")
                {
                    int startIndex = int.Parse(parts[1]);
                    int endIndex = int.Parse(parts[2]);
                    int damage = int.Parse(parts[3]);

                    if (startIndex >= 0 && startIndex < pirateShip.Length && endIndex >= 0 && endIndex < pirateShip.Length)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;

                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (parts[0] == "Repair")
                {
                    int index = int.Parse(parts[1]);
                    int health = int.Parse(parts[2]);

                    if (index >= 0 && index < pirateShip.Length)
                    {
                        pirateShip[index] += health;

                        if (pirateShip[index] > maxHealth)
                        {
                            pirateShip[index] = maxHealth;
                        }
                    }
                }
                else if (parts[0] == "Status")
                {
                    int sectionsCount = 0;

                    for (int i = 0; i < pirateShip.Length; i++)
                    {
                        if (pirateShip[i] < 0.2 * maxHealth)
                        {
                            sectionsCount++;
                        }
                    }

                    Console.WriteLine($"{sectionsCount} sections need repair.");
                }
            }

            int pirateShipSum = 0;

            for (int i = 0; i < pirateShip.Length; i++)
            {
                pirateShipSum += pirateShip[i];
            }

            Console.WriteLine($"Pirate ship status: {pirateShipSum}");

            int warshipSum = 0;

            for (int i = 0; i < warship.Length; i++)
            {
                warshipSum += warship[i];
            }

            Console.WriteLine($"Warship status: {warshipSum}");
        }
    }
}
