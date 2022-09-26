namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var data = context.Prisoners
                .ToList()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => po.Officer)
                        .Select(o => new
                        {
                            OfficerName = o.FullName,
                            Department = o.Department.Name,
                        })
                        .OrderBy(x => x.OfficerName)
                        .ToList(),
                    TotalOfficerSalary = decimal.Parse((p.PrisonerOfficers
                        .Select(po => po.Officer.Salary)
                        .Sum()).ToString("F2")),
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            string result = JsonConvert.SerializeObject(data, Formatting.Indented);

            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var data = context.Prisoners
                .ToArray()
                .Where(p => names.Contains(p.FullName))
                .Select(p => new PrisonerExportModel()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new MailExportModel()
                        {
                            Description = new String(m.Description.ToCharArray().Reverse().ToArray())
                        })
                        .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();


            var xmlSerializer = new XmlSerializer(typeof(PrisonerExportModel[]), new XmlRootAttribute("Prisoners"));

            var ns = new XmlSerializerNamespaces();

            ns.Add(String.Empty, String.Empty);

            var sw = new StringWriter();

            xmlSerializer.Serialize(sw, data, ns);

            return sw.ToString();
        }
    }
}