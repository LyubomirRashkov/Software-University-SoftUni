using System;

namespace ImplementingCustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] data;

        public CustomList()
        {
            this.data = new int[InitialCapacity];
            this.Count = 0;
        }

        public CustomList(int capacity)
        {
            this.data = new int[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index]
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

        public void Add(int element)
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
            int[] tempData = new int[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                tempData[i] = this.data[i];
            }

            this.data = tempData;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int removed = this.data[index];

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
            int[] tempData = new int[this.data.Length / 2];

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

        public void Inset(int index, int element)
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

        public bool Contains(int element) 
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i] == element)
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

            int temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        public int[] ToArray() 
        {
            int[] result = new int[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.data[i];
            }

            return result;
        }
    }
}
