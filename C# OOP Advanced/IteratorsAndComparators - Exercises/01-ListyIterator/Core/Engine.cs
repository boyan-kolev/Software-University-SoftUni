namespace ListyIterators.Core
{
    using System;
    using System.Linq;
    public class Engine
    {
        private CommandInterpreter commandInterpreter;

        public void Run()
        {
            string[] elements = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();

            this.commandInterpreter = new CommandInterpreter(elements);

            string input = Console.ReadLine();
            while (input != "END")
            {
                try
                {
                    string[] inputArgs = input.Split();
                    commandInterpreter.InterpretCommand(inputArgs);

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
        }


    }
}
