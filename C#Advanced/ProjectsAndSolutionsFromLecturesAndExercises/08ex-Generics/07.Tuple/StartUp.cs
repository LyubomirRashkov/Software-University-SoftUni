using System;
using System.Collections.Generic;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAndAddressInput = Console.ReadLine()
                .Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);

            string firstName = nameAndAddressInput[0];
            string secondName = nameAndAddressInput[1];
            string wholeName = firstName + " " + secondName;
            string address = nameAndAddressInput[2];

            MyTuple<string, string> nameAndAddress = new MyTuple<string, string>(wholeName, address);

            string[] nameAndBeerInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = nameAndBeerInput[0];
            int litersOfBeer = int.Parse(nameAndBeerInput[1]);

            MyTuple<string, int> nameAndBeer = new MyTuple<string, int>(name, litersOfBeer);

            string[] numbersInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int integerNumber = int.Parse(numbersInput[0]);
            double doubleNumber = double.Parse(numbersInput[1]);

            MyTuple<int, double> numbers = new MyTuple<int, double>(integerNumber, doubleNumber);

            Console.WriteLine(nameAndAddress.GetInfo());
            Console.WriteLine(nameAndBeer.GetInfo());
            Console.WriteLine(numbers.GetInfo());
        }
    }
}
