using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            List<int> plates = new List<int>(Console.ReadLine()
                                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToArray());

            Stack<int> currentWave = null;

            bool areAllPlatesDestroyed = false;

            for (int i = 1; i <= numberOfWaves; i++)
            {
                currentWave = new Stack<int>(Console.ReadLine()
                                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray());

                if (i % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());

                    plates.Add(additionalPlate);
                }

                while (plates.Count > 0 && currentWave.Count > 0)
                {
                    int currentPlate = plates[0];
                    int currentOrc = currentWave.Peek();

                    if (currentOrc > currentPlate)
                    {
                        plates.RemoveAt(0);
                        currentWave.Pop();

                        currentOrc -= currentPlate;
                        currentWave.Push(currentOrc);
                    }
                    else if (currentOrc < currentPlate)
                    {
                        currentWave.Pop();

                        plates[0] -= currentOrc;
                    }
                    else
                    {
                        plates.RemoveAt(0);
                        currentWave.Pop();
                    }
                }

                if (plates.Count == 0)
                {
                    areAllPlatesDestroyed = true;

                    break;
                }
            }

            if (areAllPlatesDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                Console.WriteLine($"Orcs left: {string.Join(", ", currentWave)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");

                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
