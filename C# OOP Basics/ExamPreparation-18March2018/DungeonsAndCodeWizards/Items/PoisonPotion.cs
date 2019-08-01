using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class PoisonPotion : Item
    {
        private const int PoisonPotionWeight = 5;
        public PoisonPotion() 
            : base(PoisonPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
