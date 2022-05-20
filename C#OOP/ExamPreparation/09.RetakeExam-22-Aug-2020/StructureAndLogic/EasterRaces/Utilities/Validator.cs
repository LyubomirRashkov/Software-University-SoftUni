using System;

namespace EasterRaces.Utilities
{
    public static class Validator
    {
        public static void ThrowExceptionIfParameterIsNullEmptyOrHasLengthLessThanMinimumLength(string parameter,
                                                                                          int minimumLength, string message)
        {
            if (string.IsNullOrEmpty(parameter) || parameter.Length < minimumLength)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
