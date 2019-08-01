
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        /// <summary>
        /// This is a buyer name !
        /// </summary>
        string Name { get; }

        /// <summary>
        /// This is an amount of purhased food !
        /// </summary>
        int Food { get; }

        /// <summary>
        /// This method increase amount of purhased food !
        /// </summary>
        void BuyFood();
    }
}
