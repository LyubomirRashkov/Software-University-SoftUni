using System;

namespace ImplementingCustomQueue
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(4);

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            queue.Enqueue(10);

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            queue.Enqueue(8);

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            queue.Enqueue(20);

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            queue.Enqueue(50);

            Console.WriteLine("Queue after Enqueue(): " + string.Join(", ", queue.ToArray()));

            int dequeued = queue.Dequeue();

            Console.WriteLine("The dequeued element with Dequeue() is " + dequeued);

            Console.WriteLine("The queue after Dequeue(): " + string.Join(", ", queue.ToArray()));

            int firstElement = queue.Peek();

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
