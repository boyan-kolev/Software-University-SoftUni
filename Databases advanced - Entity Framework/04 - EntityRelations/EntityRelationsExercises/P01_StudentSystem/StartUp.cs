namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Student> students = GenerateStudents();
            SeedStudents(students);
        }
        private static void SeedStudents(List<Student> students)
        {
            using (StudentSystemContext context = new StudentSystemContext())
            {
                context.Students.AddRange(students);

                context.SaveChanges();
            }
        }

        private static List<Student> GenerateStudents()
        {
            string[] firstNames =
            {
                "Pesho",
                "Boyan",
                "Valentin",
                "Misho",
                "Dicho",
                "Mariyan"
            };

            string[] lastNames =
            {
                "Manchev",
                "Kolev",
                "Petkov",
                "Dichev",
                "Mishev"
            };

            List<Student> students = new List<Student>();

            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    string name = $"{firstName} {lastName}";

                    Student student = new Student();
                    student.Name = name;

                    students.Add(student);
                }
            }

            return students;
        }
    }
}
