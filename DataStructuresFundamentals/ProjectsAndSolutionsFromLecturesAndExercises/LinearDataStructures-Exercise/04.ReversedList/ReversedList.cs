namespace Problem04.ReversedList
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	public class ReversedList<T> : IAbstractList<T>
	{
		private const int DefaultCapacity = 4;

		private T[] items;

		public ReversedList()
			: this(DefaultCapacity)
		{
		}

		public ReversedList(int capacity)
		{
			if (capacity <= 0)
				throw new ArgumentOutOfRangeException(nameof(capacity));

			this.items = new T[capacity];
		}

		public int Count { get; private set; }

		public T this[int index]
		{
			get
			{
				this.ValidateIndex(index);
				return this.items[this.Count - 1 - index];
			}
			set
			{
				this.ValidateIndex(index);
				this.items[index] = value;
			}
		}

		public void Add(T item)
		{
			if (this.Count == this.items.Length)
			{
				this.Grow();
			}

			this.items[this.Count++] = item;
		}

		public int IndexOf(T item)
		{
			//int index = 0;
			//bool isFound = false;

			//for (int i = this.Count - 1; i >= 0; i--)
			//{
			//	if (this.items[i].Equals(item))
			//	{
			//		isFound = true;

			//		break;
			//	}

			//	index++;
			//}

			//return isFound ? index : -1;


			// We loop back to return the "leftmost" element (in our case, it's the rightmost element)
			for (int i = this.Count - 1; i >= 0; i--) 
			{
				if (this.items[i].Equals(item))
				{
					return (this.Count - 1 - i);
				}
			}

			return -1;
		}

		public bool Contains(T item)
		{
			return this.IndexOf(item) != -1;
		}

		public void Insert(int index, T item)
		{
			this.ValidateIndex(index);

			if (this.Count == this.items.Length)
			{
				this.Grow();
			}

			int realIndex = this.Count - index; // Here it's not "this.Count - 1 - index" because we want to insert the element 'after' (or looking from right to left 'before' (because we start indexing from 0))

			for (int i = this.Count; i > realIndex; i--)
			{
				this.items[i] = this.items[i - 1];
			}

			this.items[realIndex] = item;

			this.Count++;
		}

		public void RemoveAt(int index)
		{
			this.ValidateIndex(index);

			int realIndex = this.Count - 1 - index; // Here it's not "this.Count - index" because we want to remove the element 'before' (or looking from right to left 'after' (because we start indexing from 0))

			for (int i = realIndex; i < this.Count - 1; i++)
			{
				this.items[i] = this.items[i + 1];
			}

			this.Count--;
		}

		public bool Remove(T item)
		{
			int index = this.IndexOf(item);

			if (index == -1)
			{
				return false;
			}

			this.RemoveAt(index);

			return true;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = this.Count - 1; i >= 0; i--)
			{
				yield return this.items[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		private void ValidateIndex(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new IndexOutOfRangeException("Index is not valid!");
			}
		}

		private void Grow()
		{
			T[] newArr = new T[this.items.Length * 2];

			for (int i = 0; i < this.Count; i++)
			{
				newArr[i] = this.items[i];
			}

			this.items = newArr;
		}
	}
}