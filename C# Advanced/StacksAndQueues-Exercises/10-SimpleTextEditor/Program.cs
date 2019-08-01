using System;
using System.Collections.Generic;
using System.Text;

namespace _10_SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());
            Stack<string> stackOfSteps = new Stack<string>();
            StringBuilder text = new StringBuilder();
            stackOfSteps.Push("");

            for (int command = 0; command < numOfCommands; command++)
            {
                string[] input = Console.ReadLine().Split();
                string typeOfCommand = input[0];
                if (typeOfCommand == "1")
                {
                    stackOfSteps.Push(text.ToString());
                    string currText = input[1];
                    text.Append(currText);
                }
                else if (typeOfCommand == "2")
                {
                    stackOfSteps.Push(text.ToString());
                    int index = int.Parse(input[1]);
                    text.Remove(text.Length - index, index);
                }
                else if (typeOfCommand == "3")
                {
                    int index = int.Parse(input[1]);
                    char element = text[index - 1];
                    Console.WriteLine(element);
                }
                else if (typeOfCommand == "4")
                {
                    string undoText = stackOfSteps.Pop();
                    text.Clear();
                    text.Append(undoText);

                }
            }
        }
    }
}
