using System;

namespace ManKind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputStudent = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstNameStudent = inputStudent[0];
            string lastNameStudent = inputStudent[1];
            string facultyNumber = inputStudent[2];

            string[] inputWorker = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstNameWorker = inputWorker[0];
            string lastNameWorker = inputWorker[1];
            decimal weekSalary = decimal.Parse(inputWorker[2]);
            double workHoursPerDay = double.Parse(inputWorker[3]);

            try
            {
                Student student = new Student(firstNameStudent, lastNameStudent, facultyNumber);
                Worker worker = new Worker(firstNameWorker, lastNameWorker, weekSalary, workHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
