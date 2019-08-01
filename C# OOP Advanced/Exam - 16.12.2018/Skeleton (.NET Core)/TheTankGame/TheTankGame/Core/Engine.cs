namespace TheTankGame.Core
{
    using System;
    using System.Collections;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            //TODO try catch !!!
            string input = this.reader.ReadLine();

            while (isRunning)
            {
                string[] parameters = input.Split();
                string result = this.commandInterpreter.ProcessInput(parameters);

                this.writer.WriteLine(result);

                if (parameters[0] == "Terminate")
                {
                    isRunning = false;
                }
                else
                {
                    input = this.reader.ReadLine();
                }

            }


        }
    }
}