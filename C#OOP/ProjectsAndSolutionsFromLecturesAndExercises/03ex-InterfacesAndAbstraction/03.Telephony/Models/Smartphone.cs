using _03.Telephony.Common;
using _03.Telephony.Interfaces;
using System;

namespace _03.Telephony.Models
{
    internal class Smartphone : ICallable, IBrowsable
    {
        public void Call(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);

            Console.WriteLine($"Calling... {number}");
        }

        public void Browse(string site)
        {
            Validator.ThrowIfSiteIsInvalid(site);

            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
