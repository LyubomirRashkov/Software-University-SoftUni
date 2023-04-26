namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node newNode = new Node(item);

            newNode.Next = this.top;

            this.top = newNode;

            this.Count++;
        }

        public T Peek()
        {
			this.ValidateCollection();

            return this.top.Value;
		}

		public T Pop()
        {
            this.ValidateCollection();

            T value = this.top.Value;

            this.top = this.top.Next;

            this.Count--;

            return value;
        }

        public bool Contains(T item)
        {
            Node node = this.top;

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
            Node node = this.top;

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
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}