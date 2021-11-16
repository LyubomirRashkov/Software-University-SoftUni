using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFloors = int.Parse(Console.ReadLine());
            int numberOfRoomsOnOneFloor = int.Parse(Console.ReadLine());

            for (int i = numberOfFloors; i >= 1; i--)
            {
                for (int j = 0; j < numberOfRoomsOnOneFloor; j++)
                {
                    if (i == numberOfFloors)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if (i % 2 != 0)
                    {
                        Console.Write($"A{i}{j} ");
                    }
                    else
                    {
                        Console.Write($"O{i}{j} ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
