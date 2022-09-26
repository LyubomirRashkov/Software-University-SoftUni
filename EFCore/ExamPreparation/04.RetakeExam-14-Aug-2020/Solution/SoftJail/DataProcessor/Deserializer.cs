namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentDtos = JsonConvert.DeserializeObject<IEnumerable<DepartmentImportModel>>(jsonString);

            var sb = new StringBuilder();

            var valids = new List<Department>();

            foreach (var depDto in departmentDtos)
            {
                if (!IsValid(depDto) || depDto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine("Invalid Data");

                    continue;
                }

                var department = new Department()
                {
                    Name = depDto.Name,
                };

                foreach (var cellDto in depDto.Cells)
                {
                    var cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow,
                    };

                    department.Cells.Add(cell);
                }

                valids.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(valids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerDtos = JsonConvert.DeserializeObject<IEnumerable<PrisonerImportModel>>(jsonString);

            var sb = new StringBuilder();

            var valids = new List<Prisoner>();

            foreach (var prDto in prisonerDtos)
            {
                if (!IsValid(prDto) || prDto.Mails.Any(m => !IsValid(m)))
                {
                    sb.AppendLine("Invalid Data");

                    continue;
                }

                var prisoner = new Prisoner()
                {
                    FullName = prDto.FullName,
                    Nickname = prDto.Nickname,
                    Age = prDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = prDto.Bail,
                    CellId = prDto.CellId,
                };

                DateTime? prisonerReleaseDate;

                if (String.IsNullOrWhiteSpace(prDto.ReleaseDate))
                {
                    prisonerReleaseDate = null;
                }
                else
                {
                    prisonerReleaseDate = DateTime.ParseExact(prDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                prisoner.ReleaseDate = prisonerReleaseDate;

                foreach (var mailDto in prDto.Mails)
                {
                    var mail = new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                    };

                    prisoner.Mails.Add(mail);
                }

                valids.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(valids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(OfficerImportModel[]), new XmlRootAttribute("Officers"));

            var officerDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as OfficerImportModel[];

            var valids = new List<Officer>();

            var sb = new StringBuilder();

            foreach (var offDto in officerDtos)
            {
                bool isPositionValid = Enum.TryParse(offDto.Position, out Position position);

                bool isWeaponValid = Enum.TryParse(offDto.Weapon, out Weapon weapon);

                if (!IsValid(offDto) 
                    || !isPositionValid 
                    || !isWeaponValid)
                {
                    sb.AppendLine("Invalid Data");

                    continue;
                }

                var officer = new Officer()
                {
                    FullName = offDto.Name,
                    Salary = offDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = offDto.DepartmentId,
                };

                foreach (var offPrDto in offDto.Prisoners)
                {
                    var officerPrisoner = new OfficerPrisoner()
                    {
                        PrisonerId = offPrDto.Id,
                    };

                    officer.OfficerPrisoners.Add(officerPrisoner);
                }

                valids.Add(officer);

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(valids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}