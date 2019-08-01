namespace CustomListSorter.Core
{
    using System;
    public class Engine
    {
        private CommandInterpreter CommandInterpreter;

        public Engine()
        {
            this.CommandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();
                this.CommandInterpreter.InterpretCommand(inputArgs);

                input = Console.ReadLine();
            }
        }
    }
}
