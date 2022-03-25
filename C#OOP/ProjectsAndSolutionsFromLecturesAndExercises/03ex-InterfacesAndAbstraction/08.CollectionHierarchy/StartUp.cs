using _08.CollectionHierarchy.Interfaces;
using _08.CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            List<IAddable> addables = new List<IAddable>();

            AddCollection addCollection = new AddCollection();
            addables.Add(addCollection);

            List<IRemoveable> removeables = new List<IRemoveable>();

            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            addables.Add(addRemoveCollection);
            removeables.Add(addRemoveCollection);

            MyList myList = new MyList();
            addables.Add(myList);
            removeables.Add(myList);

            string[] inputStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (IAddable collection in addables)
            {
                List<int> indices = new List<int>();

                foreach (string element in inputStrings)
                {
                    indices.Add(collection.Add(element));
                }

                Console.WriteLine(string.Join(' ', indices));
            }

            int countOfRemoveOperations = int.Parse(Console.ReadLine());

            foreach (IRemoveable collection in removeables)
            {
                List<string> removedElements = new List<string>();

                for (int i = 0; i < countOfRemoveOperations; i++)
                {
                    removedElements.Add(collection.Remove());
                }

                Console.WriteLine(string.Join(' ', removedElements));
            }
        }
    }
}
