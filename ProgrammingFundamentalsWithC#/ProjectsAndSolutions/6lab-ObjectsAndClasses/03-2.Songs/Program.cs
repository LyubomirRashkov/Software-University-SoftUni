using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_2.Songs
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
                List<Song> filteredSongs = songs
                    .Where(n => n.TypeList == playCommand)
                    .ToList();

                foreach (Song song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
