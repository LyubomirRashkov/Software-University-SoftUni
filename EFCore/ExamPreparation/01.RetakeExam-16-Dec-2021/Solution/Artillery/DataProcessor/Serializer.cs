
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var data = context.Shells
                .ToList()
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range",
                        })
                        .OrderByDescending(x => x.GunWeight),
                })
                .OrderBy(x => x.ShellWeight)
                .ToList();

            string result = JsonConvert.SerializeObject(data, Formatting.Indented);

            return result;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var data = context.Guns
                .ToArray()
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new GunExportModel()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                        .Select(cg => cg.Country)
                        .Where(c => c.ArmySize > 4500000)
                        .Select(c => new CountryExportModel()
                        {
                            Country = c.CountryName,
                            ArmySize = c.ArmySize,
                        })
                        .OrderBy(x => x.ArmySize)
                        .ToArray(),
                })
                .OrderBy(x => x.BarrelLength)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GunExportModel[]), new XmlRootAttribute("Guns"));

            var ns = new XmlSerializerNamespaces();

            ns.Add(String.Empty, String.Empty);

            var sw = new StringWriter();

            xmlSerializer.Serialize(sw, data, ns);

            return sw.ToString();
        }
    }
}
