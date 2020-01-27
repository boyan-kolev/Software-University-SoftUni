using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Template
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("baking the the Whole Wheat Bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Whole Wheat Bread.");
        }
    }
}
