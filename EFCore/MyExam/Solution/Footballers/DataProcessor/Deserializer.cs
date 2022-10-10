namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(CoachImportModel[]), new XmlRootAttribute("Coaches"));

            var coachDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as CoachImportModel[];

            var valids = new List<Coach>();

            var sb = new StringBuilder();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto)
                    || String.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                foreach (var footballerDto in coachDto.Footballers)
                {
                    bool isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startdate);

                    bool isEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

                    if (!IsValid(footballerDto)
                        || !isStartDateValid
                        || !isEndDateValid
                        || startdate > endDate)
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    var footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = startdate,
                        ContractEndDate = endDate,
                        PositionType = (PositionType)footballerDto.PositionType,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                    };

                    coach.Footballers.Add(footballer);
                }

                valids.Add(coach);

                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(valids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamDtos = JsonConvert.DeserializeObject<IEnumerable<TeamImportModel>>(jsonString);

            var sb = new StringBuilder();

            var valids = new List<Team>();

            foreach (var teamDto in teamDtos)
            {
                bool isTrophiesValid = int.TryParse(teamDto.Trophies, out int trophies);

                if (!IsValid(teamDto)
                    || !isTrophiesValid
                    || trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = trophies,
                };

                foreach (var footballer in teamDto.Footballers)
                {
                    var footballerDb = context.Footballers.FirstOrDefault(f => f.Id == footballer);

                    if (footballerDb == null)
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    var teamFootballer = new TeamFootballer()
                    {
                        FootballerId = footballer,
                    };

                    team.TeamsFootballers.Add(teamFootballer);
                }

                valids.Add(team);

                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(valids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
