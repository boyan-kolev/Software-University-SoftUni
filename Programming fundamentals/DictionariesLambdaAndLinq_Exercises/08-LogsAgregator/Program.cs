using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_LogsAgregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNums = int.Parse(Console.ReadLine());

            var usersAndIp = new SortedDictionary<string, SortedDictionary<string, int>>();
            var usersDuration = new SortedDictionary<string, int>();

            for (int i = 0; i < countOfNums; i++)
            {
                string[] input = Console.ReadLine().Split();

                string ip = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);

                if (usersAndIp.ContainsKey(user) == false)
                {
                    usersAndIp.Add(user, new SortedDictionary<string, int>());
                    usersDuration.Add(user, 0);
                }

                if (usersAndIp[user].ContainsKey(ip) == false)
                {
                    usersAndIp[user].Add(ip, 0);
                }

                usersAndIp[user][ip] += duration;
                usersDuration[user] += duration;
            }


            foreach (var user in usersDuration)
            {
                List<string> ip = new List<string>();

                foreach (var kvp in usersAndIp[user.Key])
                {
                    ip.Add(kvp.Key);
                }

                string ipAddress = string.Join(", ", ip);

                Console.WriteLine($"{user.Key}: {user.Value} [{ipAddress}]");
            }
        }
    }
}
