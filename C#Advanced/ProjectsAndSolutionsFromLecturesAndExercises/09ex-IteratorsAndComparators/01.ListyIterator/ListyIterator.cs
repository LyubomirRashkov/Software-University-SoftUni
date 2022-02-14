using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> data;

        private int currentIndex;

        public ListyIterator(params T[] inputElements)
        {
            this.data = inputElements.ToList();
            currentIndex = 0;
        }

        public bool Move() 
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext() 
        {
            if (this.currentIndex < this.data.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print() 
        {
            if (this.data.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine($"{this.data[currentIndex]}");
            }
        }
    }
}
