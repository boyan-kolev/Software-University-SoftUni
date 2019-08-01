using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfUsers = int.Parse(Console.ReadLine());
            List<string> userNames = new List<string>();

            for (int counter = 0; counter < numberOfUsers; counter++)
            {
                string userName = Console.ReadLine();
                userNames.Add(userName);
            }

            userNames.Distinct();

            Console.WriteLine(string.Join(Environment.NewLine, userNames));
        }
    }
}
