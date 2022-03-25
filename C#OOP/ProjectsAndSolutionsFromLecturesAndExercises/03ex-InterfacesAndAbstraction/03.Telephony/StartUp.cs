using _03.Telephony.Models;
using System;

namespace _03.Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        smartphone.Call(phoneNumber);
                    }
                    else
                    {
                        stationaryPhone.Call(phoneNumber);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (string site in sites)
            {
                try
                {
                    smartphone.Browse(site);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
