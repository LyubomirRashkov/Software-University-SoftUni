namespace Problem02.CircularQueue
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class CircularQueue<T> : IAbstractQueue<T>
	{
		private const int DEFAULT_CAPACITY = 4;  

		private T[] elements;
		private int startIndex;
		private int endIndex;

        public CircularQueue(int capacity = DEFAULT_CAPACITY)
        {
			this.elements = new T[capacity];
        }

        public int Count { get; private set; }

		public void Enqueue(T item)
		{
			if (this.Count == this.elements.Length)
			{
				this.elements = this.CopyElements(new T[this.elements.Length * 2]);

				this.startIndex = 0;
				this.endIndex = this.Count;
			}

			this.elements[this.endIndex] = item;

			this.endIndex = (this.endIndex + 1) % this.elements.Length;

			this.Count++;
		}

		public T Peek()
		{
			this.EnsureNotEmpty();

			return this.elements[this.startIndex];
		}

		public T Dequeue()
		{
			this.EnsureNotEmpty();

			T element = this.elements[this.startIndex];

			this.startIndex = (this.startIndex + 1) % this.elements.Length;

			this.Count--;

			return element;
		}

		public T[] ToArray()
		{
			return this.CopyElements(new T[this.Count]);
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < this.Count; i++)
			{
				yield return this.elements[(this.startIndex + i) % this.elements.Length];
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		private T[] CopyElements(T[] resultArr)
		{
			for (int i = 0; i < this.Count; i++)
			{
				resultArr[i] = this.elements[(startIndex + i) % this.elements.Length];
			}

			return resultArr;
		}

		private void EnsureNotEmpty()
		{
			if (this.Count == 0)
			{
				throw new InvalidOperationException("Queue is empty!");
			}
		}
	}

}
