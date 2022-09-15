namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(PlayImportModel[]), new XmlRootAttribute("Plays"));

            var playDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as PlayImportModel[];

            var sb = new StringBuilder();

            foreach (var playDto in playDtos)
            {
                bool isTimeSpanValid = TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan duration);

                TimeSpan minDuration = new TimeSpan(1, 00, 00);

                bool isGenreValid = Enum.TryParse(playDto.Genre, out Genre genre);

                if (!IsValid(playDto) 
                    || !isTimeSpanValid 
                    || duration <= minDuration 
                    || !isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter,
                };

                context.Plays.Add(play);

                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, genre.ToString(), play.Rating));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(CastImportModel[]), new XmlRootAttribute("Casts"));

            var castDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as CastImportModel[];

            var sb = new StringBuilder();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    Play = context.Plays.FirstOrDefault(p => p.Id == castDto.PlayId),
                };

                context.Casts.Add(cast);

                string position = cast.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, position));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theatreDtos = JsonConvert.DeserializeObject<IEnumerable<TheatreImportModel>>(jsonString);

            var sb = new StringBuilder();

            foreach (var theatreDto in theatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                };

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        Play = context.Plays.FirstOrDefault(p => p.Id == ticketDto.PlayId),
                    };

                    theatre.Tickets.Add(ticket);
                }

                context.Theatres.Add(theatre);

                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
