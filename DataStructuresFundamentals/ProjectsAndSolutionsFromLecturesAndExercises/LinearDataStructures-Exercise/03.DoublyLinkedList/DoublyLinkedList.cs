namespace Problem03.DoublyLinkedList
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class DoublyLinkedList<T> : IAbstractLinkedList<T>
	{
		private class Node
		{
			public T Value { get; private set; }

			public Node Previous { get; set; }

			public Node Next { get; set; }

			public Node(T value)
			{
				this.Value = value;
			}
		}

		private Node head;
		private Node tail;

		public int Count { get; private set; }

		public void AddFirst(T item)
		{
			Node newNode = new Node(item);

			if (this.Count == 0)
			{
				this.head = this.tail = newNode;
			}
			else
			{
				newNode.Next = this.head;
				this.head.Previous = newNode;
				this.head = newNode;
			}

			this.Count++;
		}

		public void AddLast(T item)
		{
			Node newNode = new Node(item);

			if (this.Count == 0)
			{
				this.head = this.tail = newNode;
			}
			else
			{
				newNode.Previous = this.tail;
				this.tail.Next = newNode;
				this.tail = newNode;
			}

			this.Count++;
		}

		public T GetFirst()
		{
			this.EnsureNotEmpty();

			return this.head.Value;
		}

		public T GetLast()
		{
			this.EnsureNotEmpty();

			return this.tail.Value;
		}

		public T RemoveFirst()
		{
			this.EnsureNotEmpty();

			T value = this.head.Value;

			if (this.Count == 1)
			{
				this.head = this.tail = null;
			}
			else
			{
				this.head = this.head.Next;

				this.head.Previous = null;
			}

			this.Count--;

			return value;
		}

		public T RemoveLast()
		{
			this.EnsureNotEmpty();

			T value = this.tail.Value;

			if (this.Count == 1)
			{
				this.head = this.tail = null;
			}
			else
			{
				this.tail = this.tail.Previous; 
				
				this.tail.Next = null;
			}

			this.Count--;

			return value;
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
				throw new InvalidOperationException("DoublyLinkedList is empty!");
			}
		}
	}
}