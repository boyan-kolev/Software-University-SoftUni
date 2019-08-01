using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Parent
    {
        private string name;
        private string bithday;

        public Parent(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Birthday
        {
            get { return bithday; }
            set { bithday = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}{Environment.NewLine}";
        }
    }
}
