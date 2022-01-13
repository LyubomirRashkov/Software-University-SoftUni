using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    public class PetrolPump
    {
        public int Petrol { get; set; }

        public int Distance { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPetrolPumps = int.Parse(Console.ReadLine());

            Queue<PetrolPump> petrolPumps = new Queue<PetrolPump>(numberOfPetrolPumps);

            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                int[] currentPetrolPump = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int petrol = currentPetrolPump[0];
                int distance = currentPetrolPump[1];

                PetrolPump petrolPump = new PetrolPump
                {
                    Petrol = petrol,
                    Distance = distance
                };

                petrolPumps.Enqueue(petrolPump);
            }

            int index = 0;

            while (true)
            {
                int currentPetrol = 0;

                foreach (PetrolPump petrolPump in petrolPumps)
                {
                    currentPetrol += petrolPump.Petrol;
                    currentPetrol -= petrolPump.Distance;

                    if (currentPetrol < 0)
                    {
                        PetrolPump temp = petrolPumps.Dequeue();
                        petrolPumps.Enqueue(temp);
                        index++;
                        break;
                    }
                }

                if (currentPetrol >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
