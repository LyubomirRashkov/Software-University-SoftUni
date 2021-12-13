using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    public class Box
    {
        public string SerialNumber { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal CalculatePrice()
        {
            return ItemPrice * Quantity;
        }

        public override string ToString()
        {
            return $"{SerialNumber}\n-- {Item} - ${(ItemPrice):F2}: {Quantity}\n-- ${(ItemPrice * Quantity):F2}";

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] boxData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string serialNumber = boxData[0];
                string item = boxData[1];
                int quantity = int.Parse(boxData[2]);
                decimal itemPrice = decimal.Parse(boxData[3]);

                Box box = new Box
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    Quantity = quantity,
                    ItemPrice = itemPrice
                };

                boxes.Add(box);
            }

            List<Box> orderedBoxes = boxes
                .OrderByDescending(b => b.CalculatePrice())
                .ToList();

            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
