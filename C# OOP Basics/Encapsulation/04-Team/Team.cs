﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return firstTeam; }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return reserveTeam; }
        }


        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                this.firstTeam.Add(player);
            }
            else
            {
                this.reserveTeam.Add(player);
            }
        }

    }
}
