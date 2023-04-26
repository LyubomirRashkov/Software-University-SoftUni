namespace Problem04.SinglyLinkedList
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

		public void AddFirst(T item)
		{
			Node newNode = new Node(item);

			newNode.Next = this.head;

			this.head = newNode;

			this.Count++;
		}

		public void AddLast(T item)
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

		public T GetFirst()
		{
			this.ValidateCollection();

			return this.head.Value;
		}

		public T GetLast()
		{
			this.ValidateCollection();

			Node node = this.head;

			while (node.Next != null)
			{
				node = node.Next;
			}

			return node.Value;
		}

		public T RemoveFirst()
		{
			this.ValidateCollection();

			T value = this.head.Value;

			this.head = this.head.Next;

			this.Count--;

			return value;
		}

		public T RemoveLast()
		{
			this.ValidateCollection();

			T value = default;

			if (this.Count == 1)
			{
				value = this.head.Value;

				this.head = null;
			}
			else
			{
				Node node = this.head;

				while (node.Next.Next != null)
				{
					node = node.Next;
				}

				value = node.Next.Value;

				node.Next = null;
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

		private void ValidateCollection()
		{
			if (this.Count == 0)
			{
				throw new InvalidOperationException("SinglyLinkedList is empty!");
			}
		}
	}
}