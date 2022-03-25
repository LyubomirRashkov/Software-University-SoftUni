using System;
using System.Linq;

namespace _03.Telephony.Common
{
    public static class Validator
    {
        public static void ThrowIfNumberIsInvalid(string number) 
        {
            if (number.Any(ch => !char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid number!");
            }
        }

        public static void ThrowIfSiteIsInvalid(string site) 
        {
            if (site.Any(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid URL!");
            }
        }
    }
}
