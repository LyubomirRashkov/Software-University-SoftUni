using System;

namespace Bakery.Utilities
{
    public static class Validator
    {
        public static void ThrowsExceptionWhenParameterIsEqualOrLessThanTheGivenBase(decimal parameter, decimal @base, string message)
        {
            if (parameter <= @base)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowsExceptionIfParameterIsNullOrWhiteSpace(string parameter, string message)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
