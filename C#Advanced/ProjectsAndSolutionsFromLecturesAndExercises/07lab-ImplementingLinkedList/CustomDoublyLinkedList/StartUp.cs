using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.AddFirst(3);
            
            Console.WriteLine("List after AddFirst(): " + string.Join(", ", list.ToArray()));

            list.AddFirst(2);

            Console.WriteLine("List after AddFirst(): " + string.Join(", ", list.ToArray()));

            list.AddFirst(1);

            Console.WriteLine("List after AddFirst(): " + string.Join(", ", list.ToArray()));

            list.AddLast(4);

            Console.WriteLine("List after AddLast(): " + string.Join(", ", list.ToArray()));

            list.AddFirst(0);

            Console.WriteLine("List after AddFirst(): " + string.Join(", ", list.ToArray()));

            list.AddLast(100);

            Console.WriteLine("List after AddLast(): " + string.Join(", ", list.ToArray()));

            int removed = list.RemoveFirst();

            Console.WriteLine("The removed element with RemoveFirst() is " + removed);

            Console.WriteLine("The list after RemoveFirst(): " + string.Join(", ", list.ToArray()));
            
            removed = list.RemoveLast();

            Console.WriteLine("The removed element with RemoveLast() is " + removed);

            Console.WriteLine("The list after RemoveLast(): " + string.Join(", ", list.ToArray()));

            list.AddLast(5);

            Console.WriteLine("The list after AddLast(): " + string.Join(", ", list.ToArray()));

            Console.WriteLine("Elements of the list after ForEach():");

            list.ForEach(x => Console.WriteLine("-> " + x + " <-"));

            int countOfElements = list.Count;

            Console.WriteLine("The count of elements in the list is " + countOfElements);

            Console.WriteLine("Whole list: " + string.Join(", ", list.ToArray()));
        }
    }
}
