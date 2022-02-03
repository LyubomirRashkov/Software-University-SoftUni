using System;

namespace ImplementingCustomList
{
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;

        private T[] data;

        public CustomList()
        {
            this.data = new T[InitialCapacity];
            this.Count = 0;
        }

        public CustomList(int capacity)
        {
            this.data = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return data[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                data[index] = value;
            }
        }

        public void Add(T element)
        {
            this.CheckIfResizeIsNeeded();

            this.data[this.Count] = element;

            this.Count++;
        }

        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            T[] tempData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                tempData[i] = this.data[i];
            }

            this.data = tempData;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            T removed = this.data[index];

            this.data[index] = default;

            this.ShiftToLeft(index);

            this.Count--;

            if (this.Count * 4 == this.data.Length)
            {
                this.Shrink();
            }

            return removed;
        }

        private void Shrink()
        {
            T[] tempData = new T[this.data.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                tempData[i] = this.data[i];
            }

            this.data = tempData;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
        }

        public void Inset(int index, T element)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            this.CheckIfResizeIsNeeded();

            this.ShiftToRight(index);

            this.data[index] = element;

            this.Count++;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index ; i--)
            {
                this.data[i] = this.data[i - 1];
            }
        }

        public bool Contains(T element) 
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex) 
        {
            if (firstIndex < 0 || firstIndex >= this.Count || secondIndex < 0 || secondIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            T temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        public T[] ToArray() 
        {
            T[] result = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.data[i];
            }

            return result;
        }
    }
}
