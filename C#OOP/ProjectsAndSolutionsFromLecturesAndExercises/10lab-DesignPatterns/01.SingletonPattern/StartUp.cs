using System;

namespace _01.SingletonPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SingletonDataContainer db1 = SingletonDataContainer.Instance;
            SingletonDataContainer db2 = SingletonDataContainer.Instance;
            SingletonDataContainer db3 = SingletonDataContainer.Instance;
            SingletonDataContainer db4 = SingletonDataContainer.Instance;

            Console.WriteLine();

            Console.WriteLine($"The current population of China is {db1.GetPopulation("China")}");
        }
    }
}
