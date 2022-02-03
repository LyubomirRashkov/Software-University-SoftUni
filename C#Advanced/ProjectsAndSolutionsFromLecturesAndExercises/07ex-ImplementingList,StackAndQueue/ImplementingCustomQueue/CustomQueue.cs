using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomQueue
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;

        private const int FirstElementIndex = 0;

        private int[] data;

        public CustomQueue()
        {
            this.data = new int[InitialCapacity];
            this.Count = 0;
        }

        public CustomQueue(int capacity)
        {
            this.data = new int[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(int element)
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

        public int Dequeue() 
        {
            this.CheckIfTheQueueIsEmpty();

            int element = this.data[FirstElementIndex];

            for (int i = 0; i < this.Count - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }

            this.Count--;

            return element;
        }

        private void CheckIfTheQueueIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
        }

        public int Peek() 
        {
            this.CheckIfTheQueueIsEmpty();

            int element = this.data[FirstElementIndex];

            return element;
        }

        public void Clear() 
        {
            this.data = new int[InitialCapacity];
            this.Count = 0;
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
