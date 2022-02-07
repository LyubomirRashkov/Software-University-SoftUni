using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;

        private ListNode<T> tail;

        public int Count
        {
            get
            {
                int count = 0;

                ListNode<T> current = head;

                while (current != null)
                {
                    count++;
                    current = current.NextNode;
                }

                return count;
            }
        }

        public void AddFirst(T element)
        {
            ListNode<T> elementToAdd = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = elementToAdd;
                this.tail = elementToAdd;
            }
            else
            {
                this.head.PreviousNode = elementToAdd;
                elementToAdd.NextNode = this.head;
                this.head = elementToAdd;
            }
        }

        public void AddLast(T element)
        {
            ListNode<T> elementToAdd = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = elementToAdd;
                this.tail = elementToAdd;
            }
            else
            {
                this.tail.NextNode = elementToAdd;
                elementToAdd.PreviousNode = this.tail;
                this.tail = elementToAdd;
            }
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            T removed = this.head.Value;

            if (this.Count == 1)
            {
                this.head = default;
                this.tail = default;
            }
            else
            {
                this.head = this.head.NextNode;
                this.head.PreviousNode = default;
            }

            return removed;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            T removed = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = default;
                this.tail = default;
            }
            else
            {
                this.tail = this.tail.PreviousNode;
                this.tail.NextNode = default;
            }

            return removed;
        }

        public void ForEach(Action<T> action) 
        {
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray() 
        {
            T[] result = new T[this.Count];

            ListNode<T> currentNode = this.head;
            int index = 0;

            while (currentNode != null)
            {
                result[index] = currentNode.Value;
                index++;
                currentNode = currentNode.NextNode;
            }

            return result;
        }
    }
}
