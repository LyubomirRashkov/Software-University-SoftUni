using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            data = new List<T>();
        }

        private List<T> data;

        public void Add(T item) 
        {
            data.Add(item);
        }

        public T Remove() 
        {
            if (this.Count > 0)
            {
                T elementToRemove = this.data[this.Count - 1];
                this.data.RemoveAt(this.Count - 1);

                return elementToRemove;
            }

            throw new InvalidOperationException("There are no elements in the box!");
        }

        public int Count {
            get 
            {
                return data.Count;
            }
        }
    }
}
