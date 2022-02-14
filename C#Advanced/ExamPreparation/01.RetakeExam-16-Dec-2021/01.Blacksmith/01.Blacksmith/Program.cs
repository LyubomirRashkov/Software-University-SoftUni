using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputSteel = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputCarbon = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> steel = new Queue<int>(inputSteel);

            Stack<int> carbon = new Stack<int>(inputCarbon);

            SortedDictionary<string, int> swords = new SortedDictionary<string, int>();

            int countOfSwords = 0;

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int takenSteel = steel.Dequeue();
                int takenCarbon = carbon.Pop();

                int sum = takenSteel + takenCarbon;

                if (sum == 70)
                {
                    if (!swords.ContainsKey("Gladius"))
                    {
                        swords.Add("Gladius", 1);
                    }
                    else
                    {
                        swords["Gladius"]++;
                    }

                    countOfSwords++;
                }
                else if (sum == 80)
                {
                    if (!swords.ContainsKey("Shamshir"))
                    {
                        swords.Add("Shamshir", 1);
                    }
                    else
                    {
                        swords["Shamshir"]++;
                    }

                    countOfSwords++;
                }
                else if (sum == 90)
                {
                    if (!swords.ContainsKey("Katana"))
                    {
                        swords.Add("Katana", 1);
                    }
                    else
                    {
                        swords["Katana"]++;
                    }

                    countOfSwords++;
                }
                else if (sum == 110)
                {
                    if (!swords.ContainsKey("Sabre"))
                    {
                        swords.Add("Sabre", 1);
                    }
                    else
                    {
                        swords["Sabre"]++;
                    }

                    countOfSwords++;
                }
                else if (sum == 150)
                {
                    if (!swords.ContainsKey("Broadsword"))
                    {
                        swords.Add("Broadsword", 1);
                    }
                    else
                    {
                        swords["Broadsword"]++;
                    }

                    countOfSwords++;
                }
                else
                {
                    carbon.Push(takenCarbon + 5);
                }
            }

            if (countOfSwords == 0)
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {countOfSwords} swords.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.Write("Steel left: ");
                Console.WriteLine(string.Join(", ", steel));
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.Write("Carbon left: ");
                Console.WriteLine(string.Join(", ", carbon));
            }

            foreach (var kvp in swords)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
