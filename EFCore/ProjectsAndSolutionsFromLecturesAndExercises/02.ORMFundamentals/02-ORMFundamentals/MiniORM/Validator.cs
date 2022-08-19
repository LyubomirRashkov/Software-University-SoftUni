using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
    internal static class Validator
    {
        internal static void ThrowExceptionIfParameterIsNull(object parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter), "Item cannot be null!");
            }
        }

        internal static void ThrowExceptionWhenThereAreInvalidEntities(object[] invalidEntities, IEnumerable<object> dbSet)
        {
            if (invalidEntities.Any())
            {
                throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
            }
        }
    }
}
