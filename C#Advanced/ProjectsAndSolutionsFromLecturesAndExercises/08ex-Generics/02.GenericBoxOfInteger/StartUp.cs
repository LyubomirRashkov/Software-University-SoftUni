using System;
using System.Collections.Generic;

namespace _02.GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                int inputInteger = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(inputInteger);

                boxes.Add(box);
            }

            foreach (Box<int> box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
