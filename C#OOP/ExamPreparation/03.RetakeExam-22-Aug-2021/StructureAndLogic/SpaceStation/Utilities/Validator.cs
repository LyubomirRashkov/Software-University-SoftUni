using System;

namespace SpaceStation.Utilities
{
    public static class Validator
    {
        public static void ThrowsExceptionWhenParameterIsNullOrWhiteSpace(string parameter, string message)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
