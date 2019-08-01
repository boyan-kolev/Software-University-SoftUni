using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal CalculateTotalPrice(decimal pricePerDay, int days, Season season, Discount discount)
        {
            decimal totalPrice = pricePerDay * days * (int)season;
            decimal priceWithDiscount = totalPrice - (totalPrice * (int)discount / 100.00m);

            return priceWithDiscount;
        }
    }
}
