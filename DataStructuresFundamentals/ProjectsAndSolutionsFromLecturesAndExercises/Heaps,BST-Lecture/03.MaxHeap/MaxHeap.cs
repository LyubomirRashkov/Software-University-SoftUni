namespace _03.MaxHeap
{
    using System;
	using System.Collections.Generic;

	public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private readonly List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);

            this.HeapifyUp(this.elements.Count - 1);
        }

		public T ExtractMax()
        {
            this.ValidateCollection();

            T element = this.elements[0];

            int lastIndex = this.elements.Count - 1;

            this.Swap(0, lastIndex);

            this.elements.RemoveAt(lastIndex);

            this.HeapifyDown(0);

            return element;
        }

		public T Peek()
        {
            this.ValidateCollection();

            return this.elements[0];
        }

		private void HeapifyUp(int index)
		{
            int parentIndex = (index - 1) / 2;

            while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) > 0)
            {
                this.Swap(index, parentIndex);

                index = parentIndex;

                parentIndex = (index - 1) / 2;
            }
		}

		private void Swap(int index, int parentIndex)
		{
			(this.elements[index], this.elements[parentIndex]) = 
                (this.elements[parentIndex], this.elements[index]);

			//T temp = this.elements[index];

			//this.elements[index] = this.elements[parentIndex];

			//this.elements[parentIndex] = temp;
		}

		private void HeapifyDown(int index)
		{
            int indexOfGreaterChild = this.GetIndexOfGreaterChild(index);

            while (IsValid(indexOfGreaterChild) 
                && this.elements[index].CompareTo(this.elements[indexOfGreaterChild]) < 0)
            {
                this.Swap(index, indexOfGreaterChild);

                index = indexOfGreaterChild;

                indexOfGreaterChild = this.GetIndexOfGreaterChild(index);
            }
		}

		private int GetIndexOfGreaterChild(int index)
		{
			int firstChildIndex = (2 * index) + 1;
			int secondChildIndex = (2 * index) + 2;

            if (!IsValid(firstChildIndex))
            {
                return -1;
            }
            else if (!IsValid(secondChildIndex) 
                || this.elements[firstChildIndex].CompareTo(this.elements[secondChildIndex]) > 0)
            {
                return firstChildIndex;
            }

            return secondChildIndex;
		}

        private bool IsValid(int index) => index >= 0 && index < this.elements.Count;

		private void ValidateCollection()
		{
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
		}
	}
}
