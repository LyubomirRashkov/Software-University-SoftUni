using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public string RandomString() 
        {
            random = new Random();

            int index = random.Next(this.Count);

            string element = this[index];

            this.RemoveAt(index);

            return element;
        }
    }
}
