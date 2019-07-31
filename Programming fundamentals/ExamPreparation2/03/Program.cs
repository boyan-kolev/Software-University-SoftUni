using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attackPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();


            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                string paternCount = @"[starSTAR]";
                Regex regex = new Regex(paternCount);
                MatchCollection matchesCount = regex.Matches(message);
                int key = matchesCount.Count;

                message = string.Join("", message.Select(x => (char)((int)x - key)));

                string paternInfo = @"@([a-zA-Z]+)([^@:!\->]*):([0-9]+)([^@:!\->]*)!([AD])!([^@:!\->]*)->([0-9]+)";

                Regex regex1 = new Regex(paternInfo);
                MatchCollection matchesInfo = regex1.Matches(message);

                string planet = string.Empty;
                string population = string.Empty;
                string attackType = string.Empty;
                string solider = string.Empty;

                foreach (Match match in matchesInfo)
                {
                    planet = match.Groups[1].ToString();
                    population = match.Groups[3].ToString();
                    attackType = match.Groups[5].ToString();
                    solider = match.Groups[7].ToString();
                }

                if (planet == "" || population == "" || attackType == "" || solider == "")
                {
                    continue;
                }

                if ((solider != "") && (population != ""))
                {
                    if (attackType == "A")
                    {
                        attackPlanets.Add(planet);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planet);
                    }

                }

            }


            attackPlanets = attackPlanets.OrderBy(x => x).ToList();
            destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();

            Console.WriteLine($"Attacked planets: {attackPlanets.Count}");
            foreach (var attack in attackPlanets)
            {
                Console.WriteLine($"-> {attack}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var attack in destroyedPlanets)
            {
                Console.WriteLine($"-> {attack}");
            }
        }
    }
}
