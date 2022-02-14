using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> data;

        public Stack(params T[] elements)
        {
            this.data = elements.ToList();
        }

        public void Push(params T[] elementsToPush) 
        {
            for (int i = 0; i < elementsToPush.Length; i++)
            {
                this.data.Add(elementsToPush[i]);
            }
        }

        public void Pop() 
        {
            if (this.data.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                this.data.RemoveAt(this.data.Count - 1);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
