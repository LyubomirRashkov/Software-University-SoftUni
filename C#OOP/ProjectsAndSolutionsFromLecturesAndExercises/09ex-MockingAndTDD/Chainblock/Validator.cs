using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock
{
    public static class Validator<T>
    {
        public static void DoesTransactionExist(Dictionary<int, ITransaction> collection, int key) 
        {
            if (!collection.ContainsKey(key))
            {
                throw new InvalidOperationException();
            }
        }

        public static void IsCollectionEmpty(IEnumerable<T> collection) 
        {
            if (collection.Count() == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
