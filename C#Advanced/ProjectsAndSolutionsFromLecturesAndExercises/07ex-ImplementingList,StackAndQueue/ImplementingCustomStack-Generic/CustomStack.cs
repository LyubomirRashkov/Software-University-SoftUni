using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomStack
{
    public class CustomStack<T>
    {
        private const int InitialCapacity = 4;

        private T[] data;

        public CustomStack()
        {
            this.data = new T[InitialCapacity];
            this.Count = 0;
        }

        public CustomStack(int capacity)
        {
            this.data = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.CheckIfResizeIsNeeded();

            this.data[Count] = element;
            this.Count++;
        }

        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            T[] tempData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                tempData[i] = this.data[i];
            }

            this.data = tempData;
        }

        public T Pop()
        {
            this.CheckIfTheStackIsEmpty();

            T element = this.data[this.Count - 1];

            Count--;

            return element;
        }

        public T Peek() 
        {
            this.CheckIfTheStackIsEmpty();

            T element = this.data[this.Count - 1];

            return element;
        }

        private void CheckIfTheStackIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }

        public void ForEach(Action<T> action) 
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.data[i]);
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.data[i];
            }

            return result;
        }
    }
}
