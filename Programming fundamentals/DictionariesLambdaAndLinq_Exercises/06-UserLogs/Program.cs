using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] {' ' , '='}, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "end")
                {
                    break;
                }

                string ip = input[1];
                string user = input[5];


                if (users.ContainsKey(user) == false)
                {
                    users.Add(user, new Dictionary<string, int>());
                }

                if (users[user].ContainsKey(ip) == false)
                {
                    users[user].Add(ip, 0);
                }

                users[user][ip]++;
            }

            users = users.OrderBy(key => key.Key).ToDictionary(key =>key.Key ,value => value.Value);

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}:");
                List<string> logs = new List<string>();
                foreach (var log in user.Value)
                {
                    logs.Add(log.Key + " => " + log.Value);
                }

                Console.WriteLine(string.Join(", ", logs) + ".");

            }
        }
    }
}
