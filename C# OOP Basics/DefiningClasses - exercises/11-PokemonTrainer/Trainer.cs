using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        
        public Trainer(string name)
        {
            this.Pokemons = new List<Pokemon>();
            this.Name = name;
            this.NumberOfBadges = 0;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumberOfBadges
        {
            get { return numberOfBadges; }
            set { numberOfBadges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }

        public void AddBadges()
        {
            this.NumberOfBadges++;
        }

        public void ReduceHealth()
        {
            foreach (Pokemon pokemon in this.Pokemons)
            {
                pokemon.Health -= 10;
            }

            this.Pokemons = this.Pokemons.Where(p => p.Health > 0).ToList();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}