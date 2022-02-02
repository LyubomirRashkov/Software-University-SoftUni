using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public ListNode(int value)
            {
                this.Value = value;
            }

            public int Value { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }
        }

        private ListNode head;

        private ListNode tail;

        public int Count
        {
            get
            {
                int count = 0;

                ListNode current = head;

                while (current != null)
                {
                    count++;
                    current = current.NextNode;
                }

                return count;
            }
        }

        public void AddFirst(int element)
        {
            ListNode elementToAdd = new ListNode(element);

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

        public void AddLast(int element)
        {
            ListNode elementToAdd = new ListNode(element);

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

        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            int removed = this.head.Value;

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

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            int removed = this.tail.Value;

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

        public void ForEach(Action<int> action) 
        {
            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray() 
        {
            int[] result = new int[this.Count];

            ListNode currentNode = this.head;
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
