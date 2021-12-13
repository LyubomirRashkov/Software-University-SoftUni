using System;
using System.Collections.Generic;

namespace _03.Songs
{
    public class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>(numberOfSongs);

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] songData = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);

                string typeList = songData[0];
                string name = songData[1];
                string time = songData[2];

                Song song = new Song
                {
                    TypeList = typeList,
                    Name = name,
                    Time = time
                };

                songs.Add(song);
            }

            string playCommand = Console.ReadLine();

            if (playCommand == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == playCommand)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
