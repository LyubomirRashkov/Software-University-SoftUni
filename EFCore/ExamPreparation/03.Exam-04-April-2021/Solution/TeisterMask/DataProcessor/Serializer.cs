namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var data = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Any())
                .Select(p => new ProjectExportModel()
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue
                                 ? "Yes"
                                 : "No",
                    Tasks = p.Tasks
                        .Select(t => new TaskExportModel()
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString(),
                        })
                        .OrderBy(x => x.Name)
                        .ToArray(),
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ProjectExportModel[]), new XmlRootAttribute("Projects"));

            var ns = new XmlSerializerNamespaces();

            ns.Add(String.Empty, String.Empty);

            var sw = new StringWriter();

            xmlSerializer.Serialize(sw, data, ns);

            return sw.ToString();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var data = context.Employees
                .ToList()
                .Where(e => e.EmployeesTasks.Select(et => et.Task).Any(t => t.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Select(et => et.Task)
                        .Where(t => t.OpenDate >= date)
                        .OrderByDescending(t => t.DueDate)
                        .ThenBy(t => t.Name)
                        .Select(t => new
                        {
                            TaskName = t.Name,
                            OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.LabelType.ToString(),
                            ExecutionType = t.ExecutionType.ToString(),
                        })
                        .ToList()
                })
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            string result = JsonConvert.SerializeObject(data, Formatting.Indented);

            return result;
        }
    }
}