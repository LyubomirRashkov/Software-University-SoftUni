using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
            this.thirdItem = thirdItem;
        }

        private T1 firstItem;

        private T2 secondItem;

        private T3 thirdItem;

        public string GetInfo() 
        {
            string info = $"{this.firstItem} -> {this.secondItem} -> {this.thirdItem}";

            return info;
        }
    }
}
