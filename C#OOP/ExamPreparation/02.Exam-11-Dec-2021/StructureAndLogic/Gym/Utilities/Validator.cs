using System;

namespace Gym.Utilities
{
    public static class Validator
    {
        public static void ThrowsExceptionWhenParameterIsNullOrEmpty(string parameter, string message)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
