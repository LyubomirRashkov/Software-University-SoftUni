using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> 
        where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.elements = new List<T>();
            this.indexesByValues = new Dictionary<T, int>();
        }

        public void Enqueue(T element) => this.Add(element);

        public T Dequeue() => this.ExtractMin();

        public void DecreaseKey(T key)
        {
            int index = this.indexesByValues[key];

            this.HeapifyUp(index);
        }
    }
}
