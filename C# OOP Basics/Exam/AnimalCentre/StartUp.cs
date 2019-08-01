using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            AnimalCentre animalCentre = new AnimalCentre();
            Dictionary<string, List<string>> adoptedAnimals = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = input.Split();
                    if (tokens[0] == "RegisterAnimal")
                    {
                        string type = tokens[1];
                        string name = tokens[2];
                        int energy = int.Parse(tokens[3]);
                        int happiness = int.Parse(tokens[3]);
                        int procedureTime = int.Parse(tokens[3]);

                        string result = animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                        Console.WriteLine(result);
                    }
                    else if (tokens[0] == "Chip")
                    {
                        string name = tokens[1];
                        int procedureTime = int.Parse(tokens[2]);
                        string result = animalCentre.Chip(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    else if (tokens[0] == "Vaccinate")
                    {
                        string name = tokens[1];
                        int procedureTime = int.Parse(tokens[2]);
                        string result = animalCentre.Vaccinate(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    else if (tokens[0] == "Fitness")
                    {
                        string name = tokens[1];
                        int procedureTime = int.Parse(tokens[2]);
                        string result = animalCentre.Fitness(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    else if (tokens[0] == "Play")
                    {
                        string name = tokens[1];
                        int procedureTime = int.Parse(tokens[2]);
                        string result = animalCentre.Play(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    else if (tokens[0] == "DentalCare")
                    {
                        string name = tokens[1];
                        int procedureTime = int.Parse(tokens[2]);
                        string result = animalCentre.DentalCare(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    else if (tokens[0] == "NailTrim")
                    {
                        string name = tokens[1];
                        int procedureTime = int.Parse(tokens[2]);
                        string result = animalCentre.NailTrim(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    else if (tokens[0] == "Adopt")
                    {

                        string animalName = tokens[1];
                        string owner = tokens[2];
                        string result = animalCentre.Adopt(animalName, owner);
                        Console.WriteLine(result);

                        if (adoptedAnimals.ContainsKey(owner) == false)
                        {
                            adoptedAnimals.Add(owner, new List<string>());
                        }

                        adoptedAnimals[owner].Add(animalName);

                    }
                    else if (tokens[0] == "History")
                    {
                        string procedureType = tokens[1];
                        string result = animalCentre.History(procedureType);
                        Console.WriteLine(result);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("ArgumentException: " + ae.Message);
                }
            }

            foreach (var animal in adoptedAnimals.OrderBy(x => x.Key))
            {
                Console.WriteLine($"--Owner: {animal.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(" ", animal.Value)}");
            }
        }
    }
}
