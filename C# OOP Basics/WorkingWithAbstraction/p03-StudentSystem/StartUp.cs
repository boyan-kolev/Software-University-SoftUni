using System;

namespace StudentSystem
{
    class StartUp
    {
        static StudentSystem studentSystem;
        static void Main(string[] args)
        {
            studentSystem = new StudentSystem();
            while (true)
            {
                ParseCommand();
            }
        }
        private static void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            if (args[0] == "Create")
            {
                studentSystem.CreateStudent(args);
            }
            else if (args[0] == "Show")
            {
                studentSystem.ShowStudent(args);

            }
            else if (args[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }
}
