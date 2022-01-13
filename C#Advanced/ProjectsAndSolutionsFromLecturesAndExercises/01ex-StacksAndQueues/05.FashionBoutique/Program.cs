using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfTheClothesInTheBox = new Stack<int>(clothesInTheBox);

            int rackCapacity = int.Parse(Console.ReadLine());

            int clothesOnTheCurrentRack = 0;

            int countOfRacks = 1;

            while (stackOfTheClothesInTheBox.Count > 0)
            {
                if (clothesOnTheCurrentRack + stackOfTheClothesInTheBox.Peek() < rackCapacity)
                {
                    clothesOnTheCurrentRack += stackOfTheClothesInTheBox.Pop();
                }
                else if (clothesOnTheCurrentRack + stackOfTheClothesInTheBox.Peek() == rackCapacity)
                {
                    stackOfTheClothesInTheBox.Pop();

                    if (stackOfTheClothesInTheBox.Count > 1)
                    {
                        countOfRacks++;
                        clothesOnTheCurrentRack = 0;
                    }
                }
                else
                {
                    countOfRacks++;
                    clothesOnTheCurrentRack = stackOfTheClothesInTheBox.Pop();
                }
            }

            Console.WriteLine(countOfRacks);
        }
    }
}
