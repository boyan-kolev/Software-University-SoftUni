namespace CustomListIterator
{
    using System;
    public class CommandInterpreter
    {
        private ICustomList<string> customList;

        public CommandInterpreter()
        {
            this.customList = new CustomList<string>();
        }

        public void InterpretCommand(string[] inputArgs)
        {
            switch (inputArgs[0])
            {
                case "Add":
                    this.customList.Add(inputArgs[1]);
                    break;
                case "Remove":
                    int index = int.Parse(inputArgs[1]);
                    this.customList.Remove(index);
                    break;
                case "Contains":
                    bool isExistElement = this.customList.Contains(inputArgs[1]);
                    Console.WriteLine(isExistElement);
                    break;
                case "Swap":
                    int index1 = int.Parse(inputArgs[1]);
                    int index2 = int.Parse(inputArgs[2]);
                    this.customList.Swap(index1, index2);
                    break;
                case "Greater":
                    int countGreaterElements = this.customList.CountGreaterThan(inputArgs[1]);
                    Console.WriteLine(countGreaterElements);
                    break;
                case "Max":
                    string maxElement = this.customList.Max();
                    Console.WriteLine(maxElement);
                    break;
                case "Min":
                    string minElement = this.customList.Min();
                    Console.WriteLine(minElement);
                    break;
                case "Sort":
                    this.customList.Sort();
                    break;
                case "Print":
                    foreach (var item in this.customList)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
