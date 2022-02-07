using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class MyTuple<T1, T2>
    {
        public MyTuple(T1 firstItem, T2 secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }

        public T1 FirstItem { get; private set; }

        public T2 SecondItem { get; private set; }

        public string GetInfo() 
        {
            string info = $"{this.FirstItem} -> {this.SecondItem}";

            return info;
        }
    }
}
