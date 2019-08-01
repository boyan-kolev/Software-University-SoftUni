using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Characters.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double ClericBaseHealth = 50;
        private const double ClericBaseArmor = 25;
        private const double ClericAbilityPoints = 40;
        public Cleric(string name, Faction faction) 
            : base(name, ClericBaseHealth, ClericBaseArmor, ClericAbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Faction != character.Faction)
                {
                    throw new InvalidOperationException("Cannot heal enemy character!");
                }

                character.Health += this.AbilityPoints;
            }
        }
    }
}
