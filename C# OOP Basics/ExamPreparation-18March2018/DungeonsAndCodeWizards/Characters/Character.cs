using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;
        private double restHealMultiplier;


        protected Character
            (string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;

            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            set { baseHealth = value; }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                health = value;
            }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            set { baseArmor = value; }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                armor = value;
            }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }

        public Faction Faction
        {
            get { return faction; }
            private set { faction = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public virtual double RestHealMultiplier
        {
            get { return restHealMultiplier; }
            private set { restHealMultiplier = value; }
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            double currHitPoints = 0;
            bool isFlag = true;

            if (this.Armor > 0)
            {
                currHitPoints = this.Armor - hitPoints;
                this.Armor -= hitPoints;
                isFlag = false;
            }

            if (currHitPoints < 0)
            {
                currHitPoints = Math.Abs(currHitPoints);
                this.Health -= currHitPoints;
            }

            if (isFlag)
            {
                this.Health -= hitPoints;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            if (this.IsAlive)
            {
                this.Health += this.BaseHealth * this.RestHealMultiplier;
            }
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.ReceiveItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
        }
    }
}
