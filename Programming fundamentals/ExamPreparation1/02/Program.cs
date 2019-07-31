using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = string.Empty;
            int count = 0;
            bool isStart = false;
            int nums = 0;
            int equal = 0;
            List<string> total = new List<string>();

            while (true)
            {
                string input1 = Console.ReadLine();
                if (input1 == "Visual Studio crash")
                {
                    break;
                }
                string[]input = input1.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < input.Length; i++)
                {
               

                    if (input[i] == "32656")
                    {
                        isStart = true;
                    }

                    if (isStart)
                    {
                        count++;
                    }

                    if (count == 5)
                    {
                        nums = int.Parse(input[i]);
                    }


                    if (equal == nums && equal != 0)
                    {
                        total.Add(message);
                        message = string.Empty;
                        count = 0;
                        nums = 0;
                        equal = 0;
                    }

                    if (count == 7)
                    {
                        isStart = false;
                        int num = int.Parse(input[i]);
                        char character = (char)num;
                        string text = character.ToString();
                        message += text;
                        equal++;

                    }

                }

            }


            Console.WriteLine(string.Join(Environment.NewLine, total));
        }
    }
}
