using System;
using System.Collections.Generic;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string inputLine = Console.ReadLine();

                Box<string> box = new Box<string>(inputLine);

                boxes.Add(box);
            }

            foreach (Box<string> box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
