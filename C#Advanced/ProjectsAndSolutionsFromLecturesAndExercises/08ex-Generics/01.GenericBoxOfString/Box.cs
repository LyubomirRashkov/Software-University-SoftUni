using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T item)
        {
            this.data = item;
        }

        private T data;

        public override string ToString()
        {
            return $"{typeof(T)}: {data}";
        }
    }
}
