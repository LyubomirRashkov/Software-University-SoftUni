using System;

namespace CarRacing.Utilities
{
    public static class Validator
    {
        public static void ThrowExceptionIfStringIsNullOrWhitespace(string str, string message) 
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowExceptionIfParameterIsBelowBoundary(double parameter, double boundary, string message) 
        {
            if (parameter < boundary)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
