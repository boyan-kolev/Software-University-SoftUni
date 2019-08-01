using System;
using System.Collections.Generic;
using System.Text;

namespace ManKind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                workHoursPerDay = value;
            }
        }

        private decimal GetSalaryPerHour()
        {
            decimal result = WeekSalary / (decimal)WorkHoursPerDay / 5;
            return result;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine($"Week Salary: {WeekSalary:f2}");
            stringBuilder.AppendLine($"Hours per day: {WorkHoursPerDay:f2}");
            stringBuilder.AppendLine($"Salary per hour: {this.GetSalaryPerHour():f2}");

            return stringBuilder.ToString();

        }

    }
}
