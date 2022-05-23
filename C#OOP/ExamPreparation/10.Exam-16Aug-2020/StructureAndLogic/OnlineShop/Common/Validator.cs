using System;

namespace OnlineShop.Common
{
    public static class Validator
    {
        public static void ThrowsExceptionWhenParameterIsLessThanOrEqualToZero(double parameter, string message)
        {
            if (parameter <= 0.0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowsExceptionWhenParameterIsNullOrWhiteSpace(string parameter, string message)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
