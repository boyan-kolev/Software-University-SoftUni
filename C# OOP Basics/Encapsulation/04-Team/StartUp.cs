using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Team team = new Team("Bobi");

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                decimal salary = decimal.Parse(input[3]);

                Person person = new Person(firstName, lastName, age, salary);
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team have {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players.");
        }
    }
}
