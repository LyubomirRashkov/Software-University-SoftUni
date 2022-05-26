using System;

namespace Formula1.Utilities
{
    public static class Validator
    {
        public static void ThrowExceptionWhenParameterIsNullWhiteSpaceOrHasLengthLessThanMinLength(string parameter, int minLength, string message)
        {
            if (string.IsNullOrWhiteSpace(parameter) || parameter.Length < minLength)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowExceptionWhenParameterIsLessThanMinValueOrIsGreaterThahMaxValue(double parameter, double minValue, double maxValue, string message)
        {
            if (parameter < minValue || parameter > maxValue)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
