using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Person
    {
        private string name;
        private string birthday;
        private List<Person> children;
        private List<Person> parents;

        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Children = new List<Person>();
            this.Parents = new List<Person>();
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public List<Person> Children
        {
            get { return children; }
            set { children = value; }
        }

        public List<Person> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

    }
}
