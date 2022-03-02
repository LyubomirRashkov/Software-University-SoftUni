using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine()
                                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray());

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray());

            string[] bombKinds = new string[] { "Datura Bombs", "Cherry Bombs", "Smoke Decoy Bombs" };

            SortedDictionary<string, int> bombs = new SortedDictionary<string, int>();

            for (int i = 0; i < bombKinds.Length; i++)
            {
                if (!bombs.ContainsKey(bombKinds[i]))
                {
                    bombs.Add(bombKinds[i], 0);
                }
            }

            const int targetNumberOfBombsOfEachType = 3;

            List<string> bombs2 = new List<string>();

            while (effects.Any() && casings.Any() && bombs2.Count < bombKinds.Length)
            {
                int currentEffect = effects.Peek();
                int currentCasing = casings.Pop();

                if ((currentEffect + currentCasing) == 40)
                {
                    bombs["Datura Bombs"]++;

                    if (bombs["Datura Bombs"] == targetNumberOfBombsOfEachType)
                    {
                        bombs2.Add("Datura Bombs");
                    }

                    effects.Dequeue();
                }
                else if ((currentEffect + currentCasing) == 60)
                {
                    bombs["Cherry Bombs"]++;

                    if (bombs["Cherry Bombs"] == targetNumberOfBombsOfEachType)
                    {
                        bombs2.Add("Cherry Bombs");
                    }

                    effects.Dequeue();
                }
                else if ((currentEffect + currentCasing) == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;

                    if (bombs["Smoke Decoy Bombs"] == targetNumberOfBombsOfEachType)
                    {
                        bombs2.Add("Smoke Decoy Bombs");
                    }

                    effects.Dequeue();
                }
                else
                {
                    casings.Push(currentCasing - 5);
                }
            }

            if (bombs2.Count == bombKinds.Length)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var kvp in bombs)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
