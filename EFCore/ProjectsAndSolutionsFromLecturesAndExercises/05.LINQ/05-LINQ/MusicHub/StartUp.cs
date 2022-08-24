namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var producer = context.Producers
                .Include(p => p.Albums)
                .ThenInclude(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .FirstOrDefault(p => p.Id == producerId);

            if (producer == null)
            {
                return $"There is no producer with the requred producerId({producerId})";
            }

            var albums = producer
                .Albums
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price,
                        Writer = s.Writer.Name
                    })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                  .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}")
                  .AppendLine($"-ProducerName: {album.ProducerName}")
                  .AppendLine("-Songs:");

                int counter = 0;

                foreach (var song in album.Songs)
                {
                    counter++;

                    sb.AppendLine($"---#{counter}")
                      .AppendLine($"---SongName: {song.SongName}")
                      .AppendLine($"---Price: {song.Price:F2}")
                      .AppendLine($"---Writer: {song.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsAboveDuration = context.Songs
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,
                    PerformerFullName = s.SongPerformers
                        .Select(sp => (sp.Performer.FirstName + " " + sp.Performer.LastName))
                        .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerFullName)
                .ToList();

            if (!songsAboveDuration.Any())
            {
                return $"There is no song with duration above the required duration({duration}s)";
            }

            StringBuilder sb = new StringBuilder();

            int counter = 0;

            foreach (var song in songsAboveDuration)
            {
                counter++;

                sb.AppendLine($"-Song #{counter}")
                  .AppendLine($"---SongName: {song.Name}")
                  .AppendLine($"---Writer: {song.WriterName}")
                  .AppendLine($"---Performer: {song.PerformerFullName}")
                  .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                  .AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
