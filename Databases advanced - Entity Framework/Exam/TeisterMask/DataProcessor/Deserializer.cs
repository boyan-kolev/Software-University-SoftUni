namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using System.Text;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]),
                new XmlRootAttribute("Projects"));

            ImportProjectDto[] projectsDtos;

            using (StringReader reader = new StringReader(xmlString))
            {
                projectsDtos = (ImportProjectDto[])xmlSerializer.Deserialize(reader);
            }

            List<Project> projects = new List<Project>();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in projectsDtos)
            {
                DateTime openDate;
                DateTime dueDate = new DateTime();

                bool isValidOpenDate = DateTime.TryParseExact(dto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                bool isValidDueDate;

                if (string.IsNullOrEmpty(dto.DueDate))
                {
                    isValidDueDate = true;
                }
                else
                {
                    isValidDueDate = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate);
                }



                if (IsValid(dto) && isValidOpenDate && isValidDueDate)
                {
                    List<Task> tasks = new List<Task>();

                    foreach (var taskDto in dto.Tasks)
                    {
                        DateTime taskOpenDate;
                        DateTime taskDueDate;

                        bool isValidTaskOpenDate = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                        bool isValidTaskDueDate = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                        ExecutionType executionType;
                        LabelType labelType;

                        bool isValidExecutionType = Enum.TryParse<ExecutionType>(taskDto.ExecutionType, out executionType);
                        bool isValidLabelType = Enum.TryParse<LabelType>(taskDto.LabelType, out labelType);

                        bool isValidProjectTaskDueDate = string.IsNullOrEmpty(dto.DueDate) ? true : taskDueDate <= dueDate;
                        bool isValidProjectTaskOpenDate = taskOpenDate >= openDate;

                        if (IsValid(taskDto) && isValidTaskOpenDate && isValidTaskDueDate
                            && isValidExecutionType && isValidExecutionType
                            && isValidProjectTaskDueDate && isValidProjectTaskOpenDate)
                        {
                            Task task = new Task()
                            {
                                Name = taskDto.Name,
                                OpenDate = taskOpenDate,
                                DueDate = taskDueDate,
                                ExecutionType = executionType,
                                LabelType = labelType
                            };

                            tasks.Add(task);
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                        Console.WriteLine();
                    }

                    Project project = new Project()
                    {
                        Name = dto.Name,
                        OpenDate = openDate,
                        DueDate = string.IsNullOrEmpty(dto.DueDate) ? (DateTime?)null : dueDate,
                        Tasks = tasks
                    };

                    projects.Add(project);
                    context.Tasks.AddRange(tasks);

                    sb.AppendLine($"Successfully imported project - {project.Name} with {tasks.Count} tasks.");

                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            List<ImportEmployeeDto> employeesDtos = JsonConvert.DeserializeObject<List<ImportEmployeeDto>>(jsonString);
            StringBuilder sb = new StringBuilder();

            foreach (var dto in employeesDtos)
            {
                Employee employee;

                if (IsValid(dto))
                {
                    employee = new Employee()
                    {
                        Username = dto.Username,
                        Email = dto.Email,
                        Phone = dto.Phone
                    };

                    context.Add(employee);


                    int[] tasksIds = dto.Tasks
                        .Distinct()
                        .ToArray();

                    List<EmployeeTask> employeesTasks = new List<EmployeeTask>();

                    foreach (var taskId in tasksIds)
                    {
                        if (context.Tasks.Any(x => x.Id == taskId))
                        {
                            EmployeeTask employeeTask = new EmployeeTask()
                            {
                                EmployeeId = employee.Id,
                                TaskId = taskId
                            };

                            employeesTasks.Add(employeeTask);
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }

                    }

                    context.EmployeesTasks.AddRange(employeesTasks);

                    sb.AppendLine($"Successfully imported employee - {employee.Username} with {employeesTasks.Count} tasks.");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }

            }

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