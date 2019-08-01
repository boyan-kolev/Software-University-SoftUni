namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];

            var args = inputParameters.Skip(1);

            string commandReflection = command;

            if (commandReflection == "Vehicle" || commandReflection == "Part")
            {
                commandReflection = "Add" + commandReflection;
            }

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == "TankManager");

            MethodInfo method = type.GetMethods().FirstOrDefault(x => x.Name == commandReflection);

            var result = method.Invoke(this.tankManager, new object[] { args.ToList() });



            //switch (command)
            //{
            //    case "Vehicle":
            //        result = this.tankManager.AddVehicle(inputParameters);
            //        break;
            //    case "Part":
            //        result = this.tankManager.AddPart(inputParameters);
            //        break;
            //    case "Inspect":
            //        result = this.tankManager.Inspect(inputParameters);
            //        break;
            //    case "Battle":
            //        result = this.tankManager.Battle(inputParameters);
            //        break;
            //    case "Terminate":
            //        result = this.tankManager.Terminate(inputParameters);
            //        break;
            //}

            return result.ToString();
        }
    }
}