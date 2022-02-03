using System;

namespace ImplementingCustomQueue
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomQueue<string> queue = new CustomQueue<string>();

            queue.Enqueue("Ivan");

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            queue.Enqueue("Peter");

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            queue.Enqueue("Maria");

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            queue.Enqueue("Anna");

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            queue.Enqueue("George");

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            string dequeued = queue.Dequeue();

            Console.WriteLine("The dequeued element with Dequeue() is " + dequeued);

            Console.WriteLine("The queue after Dequeue(): " + string.Join(", ", queue.ToArray()));

            string firstElement = queue.Peek();

            Console.WriteLine("The first element in the queue is " + firstElement);

            int countOfElements = queue.Count;

            Console.WriteLine("The count of elements in the queue is " + countOfElements);

            Console.WriteLine("Elements of the queue after ForEach():");

            queue.ForEach(x => Console.WriteLine("-> " + x + " <-"));

            queue.Clear();

            countOfElements = queue.Count;

            Console.WriteLine("The count of elements in the queue after Clear() is " + countOfElements);
        }
    }
}
