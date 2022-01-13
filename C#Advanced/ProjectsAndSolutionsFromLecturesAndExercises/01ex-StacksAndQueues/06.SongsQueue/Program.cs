using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queueOfSongs = new Queue<string>(songs);

            while (queueOfSongs.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    queueOfSongs.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueOfSongs));
                }
                else
                {
                    string songToAdd = command.Substring(4);

                    if (queueOfSongs.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        queueOfSongs.Enqueue(songToAdd);
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
