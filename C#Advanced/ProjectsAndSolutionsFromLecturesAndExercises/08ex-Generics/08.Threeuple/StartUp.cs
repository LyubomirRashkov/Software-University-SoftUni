using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAddressTownInput = Console.ReadLine()
                .Split(' ', 4, StringSplitOptions.RemoveEmptyEntries);

            string firstName = nameAddressTownInput[0];
            string secondName = nameAddressTownInput[1];

            string wholeName = firstName + " " + secondName;

            string address = nameAddressTownInput[2];
            string town = nameAddressTownInput[3];

            Threeuple<string, string, string> nameAddressTown = new Threeuple<string, string, string>(wholeName, address, town);

            string[] nameBeerDrunkInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = nameBeerDrunkInput[0];
            int litersOfBeer = int.Parse(nameBeerDrunkInput[1]);
            string drunkOrNot = nameBeerDrunkInput[2];

            bool isDrunk = drunkOrNot == "drunk" ? true : false;

            Threeuple<string, int, bool> nameBeerDrunk = new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk);

            string[] nameBalanceBankInput = Console.ReadLine()
                .Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);

            string inputName = nameBalanceBankInput[0];
            double accountBalance = double.Parse(nameBalanceBankInput[1]);
            string bankName = nameBalanceBankInput[2];

            Threeuple<string, double, string> nameBalanceBank = new Threeuple<string, double, string>(inputName, accountBalance, bankName);

            Console.WriteLine(nameAddressTown.GetInfo());
            Console.WriteLine(nameBeerDrunk.GetInfo());
            Console.WriteLine(nameBalanceBank.GetInfo());
        }
    }
}
