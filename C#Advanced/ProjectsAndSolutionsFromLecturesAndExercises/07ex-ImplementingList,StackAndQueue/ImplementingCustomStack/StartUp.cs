using System;

namespace ImplementingCustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            stack.Push(4);

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            stack.Push(10);

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            stack.Push(8);

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            stack.Push(20);

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            stack.Push(50);

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            int popped = stack.Pop();

            Console.WriteLine("The popped element with Pop() is " + popped);

            Console.WriteLine("The stack after Pop(): " + string.Join(", ", stack.ToArray()));

            int lastElement = stack.Peek();

            Console.WriteLine("The last element in the stack is " + lastElement);

            int countOfElements = stack.Count;

            Console.WriteLine("The count of elements in the stack is " + countOfElements);

            Console.WriteLine("Elements of the stack after ForEach():");

            stack.ForEach(x => Console.WriteLine("-> " + x + " <-"));
        }
    }
}
