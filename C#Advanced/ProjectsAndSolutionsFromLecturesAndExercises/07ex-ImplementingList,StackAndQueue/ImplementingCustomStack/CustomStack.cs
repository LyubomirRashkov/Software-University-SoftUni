using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;

        private int[] data;

        public CustomStack()
        {
            this.data = new int[InitialCapacity];
            this.Count = 0;
        }

        public CustomStack(int capacity)
        {
            this.data = new int[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(int element)
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
            int[] tempData = new int[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                tempData[i] = this.data[i];
            }

            this.data = tempData;
        }

        public int Pop()
        {
            this.CheckIfTheStackIsEmpty();

            int element = this.data[this.Count - 1];

            Count--;

            return element;
        }

        public int Peek() 
        {
            this.CheckIfTheStackIsEmpty();

            int element = this.data[this.Count - 1];

            return element;
        }

        private void CheckIfTheStackIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }

        public void ForEach(Action<int> action) 
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.data[i]);
            }
        }

        public int[] ToArray()
        {
            int[] result = new int[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.data[i];
            }

            return result;
        }
    }
}
