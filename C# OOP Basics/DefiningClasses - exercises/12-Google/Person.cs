using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Person
    {
        private string name;
        private Company company;
        private Car car;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Child> children;

        public Person(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public Company Company
        {
            get { return company; }
            set { company = value; }
        }
        
        public Car Car
        {
            get { return car; }
            set { car = value; }
        }
        
        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public List<Parent> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Child> Children
        {
            get { return children; }
            set { children = value; }
        }

        public override string ToString()
        {
            return $"{this.Name}{Environment.NewLine}Company:{Environment.NewLine}" +
                $"{this.Company}Car:{Environment.NewLine}" +
                $"{this.Car}Pokemon:{Environment.NewLine}" +
                $"{string.Join("", this.Pokemons)}Parents:{Environment.NewLine}" +
                $"{string.Join("", this.Parents)}Children:{Environment.NewLine}" +
                $"{string.Join("", this.Children)}";
        }
    }
}
