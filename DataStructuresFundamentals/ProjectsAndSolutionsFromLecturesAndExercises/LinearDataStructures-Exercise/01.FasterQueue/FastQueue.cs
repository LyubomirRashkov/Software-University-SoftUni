namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
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
        private Node tail;

        public int Count { get; private set; }

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

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            T value = this.head.Value;

            this.head = this.head.Next;

            this.Count--;

            return value;
        }

        public void Enqueue(T item)
        {
            var node = new Node(item);

            if (this.Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                this.tail.Next = node;

                this.tail = node;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.head.Value;
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

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}