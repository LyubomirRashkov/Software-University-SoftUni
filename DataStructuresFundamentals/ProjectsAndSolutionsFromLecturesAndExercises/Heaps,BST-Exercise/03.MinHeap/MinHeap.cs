using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
	public class MinHeap<T> : IAbstractHeap<T>
		where T : IComparable<T>
	{
		protected List<T> elements;
		protected Dictionary<T, int> indexesByValues;

		public MinHeap()
		{
			this.elements = new List<T>();
			this.indexesByValues = new Dictionary<T, int>();
		}

		public int Count => this.elements.Count;

		public void Add(T element)
		{
			this.elements.Add(element);

			int lastIndex = this.elements.Count - 1;

			if (!this.indexesByValues.ContainsKey(element))
			{
				this.indexesByValues.Add(element, lastIndex);
			}

			this.HeapifyUp(lastIndex);
		}

		public T ExtractMin()
		{
			this.ValidateCollection();

			T element = this.elements[0];

			int lastIndex = this.elements.Count - 1;

			this.Swap(0, lastIndex);

			this.elements.RemoveAt(lastIndex);

			this.indexesByValues.Remove(element);

			this.HeapifyDown(0);

			return element;
		}

		public T Peek()
		{
			this.ValidateCollection();

			return this.elements[0];
		}

		protected void HeapifyUp(int index)
		{
			int parentIndex = (index - 1) / 2;

			while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) < 0)
			{
				this.Swap(index, parentIndex);

				index = parentIndex;

				parentIndex = (index - 1) / 2;
			}
		}

		private void ValidateCollection()
		{
			if (this.Count == 0)
			{
				throw new InvalidOperationException();
			}
		}

		private void Swap(int firstIndex, int secondIndex)
		{
			this.indexesByValues[this.elements[firstIndex]] = secondIndex;

			this.indexesByValues[this.elements[secondIndex]] = firstIndex;

			(this.elements[firstIndex], this.elements[secondIndex]) =
				(this.elements[secondIndex], this.elements[firstIndex]);

			//T temp = this.elements[firstIndex];

			//this.elements[firstIndex] = this.elements[secondIndex];

			//this.elements[secondIndex] = temp;
		}

		private void HeapifyDown(int index)
		{
			int indexOfSmallerChild = this.GetIndexOfSmallerChild(index);

			while (this.ValidateIndex(indexOfSmallerChild)
				&& this.elements[index].CompareTo(this.elements[indexOfSmallerChild]) > 0)
			{
				this.Swap(index, indexOfSmallerChild);

				index = indexOfSmallerChild;

				indexOfSmallerChild = this.GetIndexOfSmallerChild(index);
			}
		}

		private int GetIndexOfSmallerChild(int index)
		{
			int firstChildIndex = (2 * index) + 1;

			int secondChildIndex = (2 * index) + 2;

			if (!this.ValidateIndex(firstChildIndex))
			{
				return -1;
			}

			if (!this.ValidateIndex(secondChildIndex)
				|| this.elements[firstChildIndex].CompareTo(this.elements[secondChildIndex]) < 0)
			{
				return firstChildIndex;
			}

			return secondChildIndex;
		}

		private bool ValidateIndex(int index) => index >= 0 && index < this.elements.Count;
	}
}
