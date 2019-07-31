using System;

namespace p04_Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            String month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());
            double priceForStudio = 0.0;
            double priceForDouble = 0.0;
            double priceForSuite = 0.0;

            switch (month)
            //May, June, July, August, September, October or December
            {
                case "May":
                case "October":                  
                        priceForStudio = 50;
                        priceForDouble = 65;
                        priceForSuite = 75;    
                    
                    if (nightsCount > 7)
                    {
                        priceForStudio = priceForStudio - (priceForStudio * 0.05);
                    }
                    break;
                case "June":
                case "September":
                        priceForStudio = 60;
                        priceForDouble = 72;
                        priceForSuite = 82;     
                    
                    if (nightsCount > 14)
                    {                    
                        priceForDouble = priceForDouble - (priceForDouble * 0.1);                   
                    }               
                    break;
                case "July":
                case "August":
                case "December":
                        priceForStudio = 68;
                        priceForDouble = 77;
                        priceForSuite = 89;       
                    
                    if (nightsCount > 14)
                    {
                        priceForSuite = priceForSuite - (priceForSuite * 0.15);
                    }                  
                    break;
            }

            double totalPriceStudio = priceForStudio * nightsCount;
            double totalPriceDouble = priceForDouble * nightsCount;
            double totalPriceSuite = priceForSuite * nightsCount;

            if (nightsCount > 7 && (month == "September" || month == "October"))
            {
                totalPriceStudio = totalPriceStudio - priceForStudio;
            }

            Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
            Console.WriteLine($"Double: {totalPriceDouble:f2} lv.");
            Console.WriteLine($"Suite: {totalPriceSuite:f2} lv.");
        }
    }
}
