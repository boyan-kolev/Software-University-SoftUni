using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            Season season = Enum.Parse<Season>(input[2]);
            Discount discount = Discount.None;

            if (input.Length == 4)
            {
                discount = Enum.Parse<Discount>(input[3]);
            }
            decimal totalPrice = PriceCalculator.CalculateTotalPrice
                (pricePerDay,
                numberOfDays,
                season, 
                discount);

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
