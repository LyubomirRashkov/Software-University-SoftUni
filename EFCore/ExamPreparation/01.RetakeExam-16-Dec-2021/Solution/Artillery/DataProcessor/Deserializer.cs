namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(CountryImportModel[]), new XmlRootAttribute("Countries"));

            var countryDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as CountryImportModel[];

            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var country = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize,
                };

                context.Countries.Add(country);

                sb.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ManufacturerImportModel[]), new XmlRootAttribute("Manufacturers"));

            var manufacturerDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as ManufacturerImportModel[];

            foreach (var manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var manufacturer = context.Manufacturers.FirstOrDefault(m => m.ManufacturerName == manufacturerDto.ManufacturerName);

                if (manufacturer != null)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                manufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded,
                };

                context.Manufacturers.Add(manufacturer);

                context.SaveChanges();

                string[] tokens = manufacturer.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string countryName = tokens[tokens.Length - 1];

                string townName = tokens[tokens.Length - 2];

                string foundedInfo = townName + ", " + countryName;

                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, foundedInfo));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ShellImportModel[]), new XmlRootAttribute("Shells"));

            var shellDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as ShellImportModel[];

            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var shell = new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber,
                };

                context.Shells.Add(shell);

                sb.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gunDtos = JsonConvert.DeserializeObject<IEnumerable<GunImportModel>>(jsonString);

            foreach (var gunDto in gunDtos)
            {
                bool isGunTypeValid = Enum.TryParse(gunDto.GunType, false, out GunType gunType);

                if (!IsValid(gunDto) || !isGunTypeValid)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var manufacturer = context.Manufacturers.FirstOrDefault(m => m.Id == gunDto.ManufacturerId);

                var shell = context.Shells.FirstOrDefault(s => s.Id == gunDto.ShellId);

                var gun = new Gun()
                {
                    Manufacturer = manufacturer,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = gunType,
                    Shell = shell,
                    CountriesGuns = gunDto.Countries.Select(x => new CountryGun()
                    {
                        Country = context.Countries.FirstOrDefault(c => c.Id == x.Id),
                    })
                    .ToList()
                };

                context.Guns.Add(gun);

                sb.AppendLine(String.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
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
