namespace Problem01.List
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class List<T> : IAbstractList<T>
	{
		private const int DEFAULT_CAPACITY = 4;

		private T[] items;

		public int Count { get; private set; }

		public List()
			: this(DEFAULT_CAPACITY)
		{
		}

		public List(int capacity)
		{
			if (capacity <= 0) 
			{
				throw new ArgumentOutOfRangeException(nameof(capacity));
			}

			this.items = new T[capacity];
		}

		public T this[int index] 
		{
			get
			{
				this.ValidateIndex(index);
				return this.items[index];
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
				this.items = this.Grow();
			}

			this.items[this.Count++] = item;
		}

		public int IndexOf(T item)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (this.items[i].Equals(item))
				{
					return i;
				}
			}

			return -1;
		}

		public bool Contains(T item) => this.IndexOf(item) >= 0;

		public void Insert(int index, T item)
		{
			this.ValidateIndex(index);

			if (this.Count == this.items.Length)
			{
				this.items = this.Grow();
			}

			for (int i = this.Count; i > index; i--)
			{
				this.items[i] = this.items[i - 1];
			}

			this.items[index] = item;

			this.Count++;
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

		public void RemoveAt(int index)
		{
			this.ValidateIndex(index);

			for (int i = index; i < this.Count - 1; i++)
			{
				this.items[i] = this.items[i + 1];
			}

			this.Count--;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < this.Count; i++)
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

		private T[] Grow()
		{
			T[] newArr = new T[this.items.Length * 2];

			Array.Copy(this.items, newArr, this.items.Length);

			return newArr;
		}
	}
}