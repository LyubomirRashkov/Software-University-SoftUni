using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            int health = 100;
            int bitcoins = 0;
            bool isAlive = true;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] commands = rooms[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int value = int.Parse(commands[1]);

                if (commands[0] == "potion")
                {
                    int previousHealth = health;

                    if (health + value > 100)
                    {
                        health = 100;
                    }
                    else
                    {
                        health += value;
                    }

                    Console.WriteLine($"You healed for {health - previousHealth} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (commands[0] == "chest")
                {
                    bitcoins += value;
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    health -= value;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {commands[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {commands[0]}.");
                        Console.WriteLine($"Best room: {i+1}");
                        isAlive = false;
                        break;
                    }
                }
            }

            if (isAlive)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
