using System;
using System.Collections.Generic;

namespace _07_BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int index = 0; index < parentheses.Length; index++)
            {
                switch (parentheses[index])
                {
                    case ')':
                        if (stack.Count == 0 || stack.Peek() != '(')
                        {
                            NotBalanced();
                        }
                        stack.Pop();
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Peek() != '{')
                        {
                            NotBalanced();
                        }
                        stack.Pop();
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Peek() != '[')
                        {
                            NotBalanced();
                        }
                        stack.Pop();
                        break;
                    default:
                        stack.Push(parentheses[index]);
                        break;
                }

            }
            if (stack.Count > 0)
            {
                NotBalanced();
            }

            Console.WriteLine("YES");
        }

        private static void NotBalanced()
        {
            Console.WriteLine("NO");
            Environment.Exit(0);
        }
    }
}
