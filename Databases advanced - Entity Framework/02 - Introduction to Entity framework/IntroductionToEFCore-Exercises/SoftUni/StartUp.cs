using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                //string result = GetEmployeesFullInformation(context);
                //Console.WriteLine(result);

                //string result = GetEmployeesWithSalaryOver50000(context);
                //Console.WriteLine(result);

                //string result = GetEmployeesFromResearchAndDevelopment(context);
                //Console.WriteLine(result);

                //string result = AddNewAddressToEmployee(context);
                //Console.WriteLine(result);

                //string result = GetEmployeesInPeriod(context);
                //Console.WriteLine(result);

                //string result = GetAddressesByTown(context);
                //Console.WriteLine(result);

                //string result = GetEmployee147(context);
                //Console.WriteLine(result);

                //string result = GetDepartmentsWithMoreThan5Employees(context);
                //Console.WriteLine(result);

                //string result = GetLatestProjects(context);
                //Console.WriteLine(result);

                //string result = IncreaseSalaries(context);
                //Console.WriteLine(result);

                //string result = GetEmployeesByFirstNameStartingWithSa(context);
                //Console.WriteLine(result);

                //string result = DeleteProjectById(context);
                //Console.WriteLine(result);

                string result = RemoveTown(context);
                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .Where(d => d.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.Name} - ${emp.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            Employee nakov = context.Employees
                .FirstOrDefault(l => l.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            List<string> employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine(emp);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                    .ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FullName} - Manager: {emp.ManagerName}");

                foreach (var project in emp.Projects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = project.EndDate.HasValue 
                        ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }


            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    CountOfEmployees = a.Employees.Count(),
                    TownName = a.Town.Name,
                    AddressText = a.AddressText
                })
                .OrderByDescending(e => e.CountOfEmployees)
                .ThenBy(t => t.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.CountOfEmployees} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep => ep.Project.Name)
                    .OrderBy(x => x)
                    .ToList()
                })
                .FirstOrDefault();


            return $"{employee.FirstName} {employee.LastName} - {employee.JobTitle}{Environment.NewLine}{string.Join(Environment.NewLine, employee.Projects)}";
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(ec => ec.Employees.Count)
                .ThenBy(dn => dn.Name)
                .Select(d => new
                {
                    departmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        EmpFirstName = e.FirstName,
                        EmpLastName = e.LastName,
                        empJobTitle = e.JobTitle
                    })
                    .OrderBy(fn => fn.EmpFirstName)
                    .ThenBy(ln => ln.EmpLastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.departmentName} - {department.ManagerFirstName}  {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmpFirstName} {employee.EmpLastName} - {employee.empJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }


            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            context.Employees
                .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                .Contains(e.Department.Name))
                .ToList()
                .ForEach(e => e.Salary *= 1.12M);

            context.SaveChanges();

            var employees = context.Employees
                .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                .Contains(e.Department.Name))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(fn => fn.FirstName)
                .ThenBy(ln => ln.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employess = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "Sa%"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employess)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            Project project = context.Projects
                .FirstOrDefault(p => p.ProjectId == 2);

            List<EmployeeProject> employeeProject = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(employeeProject);
            context.Projects.Remove(project);

            context.SaveChanges();

            List<string> projects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, projects);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            List<Employee> employees = context.Employees
                .Where(x => x.Address.Town.Name == "Seattle")
                .ToList();

            List<Address> addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            List<Town> towns = context.Towns
                .Where(t => t.Name == "Seattle")
                .ToList();

            foreach (var emp in employees)
            {
                emp.AddressId = null;
            }

            context.Addresses.RemoveRange(addresses);
            context.Towns.RemoveRange(towns);

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";

        }
    }
}
