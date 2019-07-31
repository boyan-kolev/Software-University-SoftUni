using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, string> emails = new Dictionary<string, string>();

            while ((input == "stop") == false)
            {
                string name = input;
                for (int i = 0; i < 2; i++)
                {

                    if (i == 0)
                    {
                        
                        if (emails.ContainsKey(input) == false)
                        {
                            emails.Add(input, "");
                        }
                    }
                    else
                    {
                        string str = input.TakeLast(2).ToString();
                        if ((str == "us") || (str == "uk"))
                        {
                            emails.Remove(name);
                        }
                        else
                        {
                            emails[name] = input;
                        }
                    }

                    input = Console.ReadLine();
                }
            }

            foreach (KeyValuePair<string,string> kvp in emails)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
