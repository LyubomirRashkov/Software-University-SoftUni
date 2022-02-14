using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        private int[] data;

        public Lake(int[] inputElements)
        {
            this.data = inputElements;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.data[i];
                }
            }

            for (int i = this.data.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return this.data[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
