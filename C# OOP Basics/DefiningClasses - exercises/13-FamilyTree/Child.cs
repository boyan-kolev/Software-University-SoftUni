﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Child
    {
        private string name;
        private string birthday;

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
    }
}
