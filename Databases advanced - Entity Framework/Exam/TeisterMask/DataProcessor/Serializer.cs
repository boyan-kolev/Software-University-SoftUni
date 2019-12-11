namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.DataProcessor.ImportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            List<ExportProjectDto> projectsDtos = context.Projects
                .Where(x => x.Tasks.Any())
                .Select(x => new ExportProjectDto()
                {
                    Name = x.Name,
                    TaskCount = x.Tasks.Count,
                    HasEndDate = x.DueDate != null ? "Yes" : "No",
                    Tasks = x.Tasks.Select(t => new ExportCustomTaskDto()
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(n => n.Name)
                    .ToArray()
                })
                .OrderByDescending(tc => tc.TaskCount)
                .ThenBy(n => n.Name)
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportProjectDto>),
                new XmlRootAttribute("Projects"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, projectsDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            List<ExportEmpoyeeDto> empoyeesDtos = context.Employees
                .Where(x => x.EmployeesTasks.Any(f => f.Task.OpenDate >= date))
                .OrderByDescending(a => a.EmployeesTasks.Count(x => x.Task.OpenDate >= date))
                .ThenBy(u => u.Username)
                .Select(x => new ExportEmpoyeeDto()
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks.Where(od => od.Task.OpenDate >= date).Select(z => new ExportTaskDto()
                    {
                        TaskName = z.Task.Name,
                        OpenDate = z.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = z.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        ExecutionType = z.Task.ExecutionType.ToString(),
                        LabelType = z.Task.LabelType.ToString()
                    })
                    .OrderByDescending(f => DateTime.ParseExact(f.DueDate, "d", CultureInfo.InvariantCulture))
                    .ThenBy(n => n.TaskName)
                    .ToList()
                })
                .Take(10)
                .ToList();

            string json = JsonConvert.SerializeObject(empoyeesDtos, Formatting.Indented);

            return json;
        }
    }
}