namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var data = context.Coaches
                .ToArray()
                .Where(c => c.Footballers.Any())
                .Select(c => new CoachExportModel()
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers
                        .Select(f => new FootballerExportModel()
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString(),
                        })
                        .OrderBy(x => x.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CoachExportModel[]), new XmlRootAttribute("Coaches"));

            var ns = new XmlSerializerNamespaces();

            ns.Add(String.Empty, String.Empty);

            var sw = new StringWriter();

            xmlSerializer.Serialize(sw, data, ns);

            return sw.ToString();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var data = context.Teams
                .ToList()
                .Where(t => t.TeamsFootballers.Select(tf => tf.Footballer).Any(f => f.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .Select(tf => tf.Footballer)
                        .Where(f => f.ContractStartDate >= date)
                        .OrderByDescending(f => f.ContractEndDate)
                        .ThenBy(f => f.Name)
                        .Select(f => new
                        {
                            FootballerName = f.Name,
                            ContractStartDate = f.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = f.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = f.BestSkillType.ToString(),
                            PositionType = f.PositionType.ToString(),
                        })
                        .ToList()
                })
                .OrderByDescending(x => x.Footballers.Count)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToList();

            string result = JsonConvert.SerializeObject(data, Formatting.Indented);

            return result;
        }
    }
}
