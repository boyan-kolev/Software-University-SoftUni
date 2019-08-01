using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split();
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = trainers.Where(x => x.Name == trainerName).FirstOrDefault();

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                trainer.AddPokemon(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                Tournament(input, trainers);
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }

        }

        private static void Tournament(string element, List<Trainer> trainers)
        {
            foreach (Trainer trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == element))
                {
                    trainer.AddBadges();
                }
                else
                {
                    trainer.ReduceHealth();
                }
            }
        }
    }
}
