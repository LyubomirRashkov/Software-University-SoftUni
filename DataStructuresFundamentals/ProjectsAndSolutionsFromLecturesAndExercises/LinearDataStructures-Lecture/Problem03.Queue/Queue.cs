namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Value { get; private set; }

            public Node Next { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Node newNode = new Node(item);

            if (this.Count == 0)
            {
                this.head = newNode;
            }
            else
            {
                Node node = this.head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.ValidateCollection();

            return this.head.Value;
        }

		public T Dequeue()
        {
            this.ValidateCollection();

            T value = this.head.Value;

            this.head = this.head.Next;

            this.Count--;

            return value;
        }

        public bool Contains(T item)
        {
            Node node = this.head;

            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;

            while (node != null)
            {
                yield return node.Value;

                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		private void ValidateCollection()
		{
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
		}
    }
}