using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class Box<T>
    {
        public Box()
        {
            this.data = new List<T>();
        }

        private List<T> data;

        public void Add(T item) 
        {
            this.data.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex) 
        {
            T temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T element in data)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
