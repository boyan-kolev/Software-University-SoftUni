namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalController;
        private ISetController setController;

        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
        {
            this.festivalController = festivalController;
            this.setController = setController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch(TargetInvocationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            string end = this.festivalController.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var inputArgs = input.Split(" ");

            string command = inputArgs[0];
            string[] parameters = inputArgs.Skip(1).ToArray();

            string result = string.Empty;

            if (command == "LetsRock")
            {
                result = this.setController.PerformSets();
            }
            else
            {
                MethodInfo festivalcontrolfunction = this.festivalController.GetType()
                    .GetMethods()
                    .FirstOrDefault(x => x.Name == command);

                try
                {
                    result = (string)festivalcontrolfunction
                        .Invoke(this.festivalController, new object[] { parameters });
                }
                catch (TargetInvocationException ex)
                {
                    result = "ERROR: " + ex.InnerException.Message;
                }
                catch (Exception ex)
                {
                    result = "ERROR: " + ex.Message;
                }
            }

            return result;
        }
    }
}