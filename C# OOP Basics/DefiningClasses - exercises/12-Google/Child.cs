﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Child
    {
        private string name;
        private string birthday;

        public Child(string name, string birthday)
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
            get { return birthday; }
            set { birthday = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}{Environment.NewLine}";
        }
    }
}
