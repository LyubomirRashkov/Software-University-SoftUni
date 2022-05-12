using System;

namespace Easter.Utilities
{
    public static class Validator
    {
        public static void ThrowsExceptionWhenParameterIsNullEmptyOrWhiteSpace(string parameter, string message)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
