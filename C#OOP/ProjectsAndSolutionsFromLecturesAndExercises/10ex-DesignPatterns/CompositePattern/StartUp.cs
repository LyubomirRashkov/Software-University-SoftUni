using System;

namespace CompositePattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("phone", 256);
            phone.CalculateTotalPrice();

            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 10);

            SingleGift truckToy = new SingleGift("TruckToy", 587);
            SingleGift plainToy = new SingleGift("PlainToy", 289);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            CompositeGift childBox = new CompositeGift("ChildBox", 10);

            SingleGift soldierToy = new SingleGift("SoldierToy", 200);

            childBox.Add(soldierToy);

            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
