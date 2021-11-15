using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantedBook = Console.ReadLine();
            string currentBook = Console.ReadLine();

            int counter = 0;

            while (currentBook != "No More Books")
            {
                if (currentBook == wantedBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }

                counter += 1;
                currentBook = Console.ReadLine();
            }

            if (currentBook == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
