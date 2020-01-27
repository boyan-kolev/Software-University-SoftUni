﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02_Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");

            return price;
        }
    }
}
