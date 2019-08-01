﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Pokemon
    {
        private string name;
        private string type;

        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Type}{Environment.NewLine}";
        }
    }
}
