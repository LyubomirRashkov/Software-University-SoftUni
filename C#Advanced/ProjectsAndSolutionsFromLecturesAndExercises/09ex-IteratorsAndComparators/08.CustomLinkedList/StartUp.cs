using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.AddFirst("Stoyan");

            Console.WriteLine("List after AddFirst(): " + string.Join(", ", list.ToArray()));

            list.AddFirst("Ivan");

            Console.WriteLine("List after AddFirst(): " + string.Join(", ", list.ToArray()));

            list.AddFirst("Peter");

            Console.WriteLine("List after AddFirst(): " + string.Join(", ", list.ToArray()));

            list.AddLast("George");

            Console.WriteLine("List after AddLast(): " + string.Join(", ", list.ToArray()));

            list.AddFirst("Anna");

            Console.WriteLine("List after AddFirst(): " + string.Join(", ", list.ToArray()));

            list.AddLast("Maria");

            Console.WriteLine("List after AddLast(): " + string.Join(", ", list.ToArray()));

            string removed = list.RemoveFirst();

            Console.WriteLine("The removed element with RemoveFirst() is " + removed);

            Console.WriteLine("The list after RemoveFirst(): " + string.Join(", ", list.ToArray()));

            removed = list.RemoveLast();

            Console.WriteLine("The removed element with RemoveLast() is " + removed);

            Console.WriteLine("The list after RemoveLast(): " + string.Join(", ", list.ToArray()));

            list.AddLast("Mimi");

            Console.WriteLine("The list after AddLast(): " + string.Join(", ", list.ToArray()));

            Console.WriteLine("Elements of the list after ForEach():");

            list.ForEach(x => Console.WriteLine("-> " + x + " <-"));

            int countOfElements = list.Count;

            Console.WriteLine("The count of elements in the list is " + countOfElements);

            Console.WriteLine("Whole list: " + string.Join(", ", list.ToArray()));

            Console.WriteLine("Elements in the list in foreach loop:");

            foreach (var item in list)
            {
                Console.WriteLine($"===> {item} <===");
            }
        }
    }
}
