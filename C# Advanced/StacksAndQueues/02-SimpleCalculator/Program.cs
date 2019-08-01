using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>(input);


            while (stack.Count > 2)
            {
                int leftOperand = int.Parse(stack.Pop());
                string @operator = stack.Pop();
                int rightOperand = int.Parse(stack.Pop());

                switch (@operator)
                {
                    case "+":
                        stack.Push((leftOperand + rightOperand).ToString());
                        break;
                    case "-":
                        stack.Push((leftOperand - rightOperand).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
