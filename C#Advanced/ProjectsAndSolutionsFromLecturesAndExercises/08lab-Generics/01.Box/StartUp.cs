using System;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            Console.WriteLine(box.Count);

            box.Add(1);
            box.Add(2);
            box.Add(3);

            Console.WriteLine(box.Count);

            Console.WriteLine(box.Remove());

            Console.WriteLine(box.Count);

            box.Add(4);
            box.Add(5);

            Console.WriteLine(box.Count);

            Console.WriteLine(box.Remove());

            Console.WriteLine(box.Count);
        }
    }
}
