using BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    class Pet : IBirthable
    {
        private string birthdate;
        private string name;

        public Pet(string birthdate, string name)
        {
            this.Birthdate = birthdate;
            this.Name = name;
        }

        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
