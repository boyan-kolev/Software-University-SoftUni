using System;
using System.Collections.Generic;

namespace _04_MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int index = 0; index < input.Length; index++)
            {
                if (input[index] == '(')
                {
                    stack.Push(index);
                }
                else if (input[index] == ')')
                {
                    int startIndex = stack.Pop();
                    int length = index - startIndex + 1;
                    string subExpression = input.Substring(startIndex, length);

                    Console.WriteLine(subExpression);
                }

            }

        }
    }
}
