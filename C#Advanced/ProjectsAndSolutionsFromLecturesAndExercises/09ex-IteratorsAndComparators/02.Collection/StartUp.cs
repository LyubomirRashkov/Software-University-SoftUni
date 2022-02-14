using System;
using System.Linq;

namespace Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                string[] inputInfo = inputLine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = inputInfo[0];

                if (command == "Create")
                {
                    string[] inputElements = inputInfo.Skip(1).ToArray();

                    listyIterator = new ListyIterator<string>(inputElements);
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "Print")
                {
                    listyIterator.Print();
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ", listyIterator));
                }
            }
        }
    }
}
