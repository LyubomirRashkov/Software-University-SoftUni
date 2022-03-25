using _03.Telephony.Common;
using _03.Telephony.Interfaces;
using System;

namespace _03.Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
