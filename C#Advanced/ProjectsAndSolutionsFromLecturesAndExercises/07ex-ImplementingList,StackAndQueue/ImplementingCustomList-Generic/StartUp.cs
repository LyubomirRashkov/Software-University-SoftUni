using System;

namespace ImplementingCustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomList<string> list = new CustomList<string>();

            list.Add("George");

            Console.WriteLine("List after Add(): " + string.Join(", ", list.ToArray()));

            list.Add("Peter");

            Console.WriteLine("List after Add(): " + string.Join(", ", list.ToArray()));

            list.Add("Anna");

            Console.WriteLine("List after Add(): " + string.Join(", ", list.ToArray()));

            string removed = list.RemoveAt(1);

            Console.WriteLine("The removed element with RemoveAt() is " + removed);

            Console.WriteLine("The list after RemoveAt(): " + string.Join(", ", list.ToArray()));

            bool doesContain = list.Contains("George");

            Console.WriteLine($"Does list contains the required element? {doesContain}");

            doesContain = list.Contains("Maria");

            Console.WriteLine($"Does list contains the required element? {doesContain}");

            list.Swap(0, 1);

            Console.WriteLine("The list after Swap(): " + string.Join(", ", list.ToArray()));

            int countOfElements = list.Count;

            Console.WriteLine("The count of elements in the list is " + countOfElements);
        }
    }
}
