using System;

namespace ImplementingCustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            stack.Push("George");

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            stack.Push("Anna");

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            stack.Push("Peter");

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            stack.Push("Ivan");

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            stack.Push("Maria");

            Console.WriteLine("Stack after Push(): " + string.Join(", ", stack.ToArray()));

            string popped = stack.Pop();

            Console.WriteLine("The popped element with Pop() is " + popped);

            Console.WriteLine("The stack after Pop(): " + string.Join(", ", stack.ToArray()));

            string lastElement = stack.Peek();

            Console.WriteLine("The last element in the stack is " + lastElement);

            int countOfElements = stack.Count;

            Console.WriteLine("The count of elements in the stack is " + countOfElements);

            Console.WriteLine("Elements of the stack after ForEach():");

            stack.ForEach(x => Console.WriteLine("-> " + x + " <-"));
        }
    }
}
