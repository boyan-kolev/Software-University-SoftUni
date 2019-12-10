namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            return "f";
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            List<ExportEmpoyeeDto> empoyeesDtos = context.Employees
                .Where(x => x.EmployeesTasks.Any(f => f.Task.OpenDate >= date))
                .Select(x => new ExportEmpoyeeDto()
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks.Where(od => od.Task.OpenDate >= date).Select(z => new ExportTaskDto()
                    {
                        TaskName = z.Task.Name,
                        OpenDate = z.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = z.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        ExecutionType = ((ExecutionType)z.Task.ExecutionType).ToString(),
                        LabelType = ((LabelType)z.Task.LabelType).ToString()
                    })
                    .OrderByDescending(f => DateTime.ParseExact(f.DueDate, "d", CultureInfo.InvariantCulture))
                    .ThenBy(n => n.TaskName)
                    .ToList()
                })
                .OrderByDescending(a => a.Tasks.Count)
                .ThenBy(u => u.Username)
                .Take(10)
                .ToList();

            string json = JsonConvert.SerializeObject(empoyeesDtos, Formatting.Indented);


            return json;
        }
    }
}