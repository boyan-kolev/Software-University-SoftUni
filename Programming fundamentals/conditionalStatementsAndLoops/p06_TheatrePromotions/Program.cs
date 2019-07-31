using System;

namespace p06_TheatrePromotions
{
    class Program
    {
        static void Main(string[] args)
        {
            String typeOfDay = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            double sum = 0;
            switch (typeOfDay)
            {
                case "weekday":
                    if (age < 0 || age > 122)
                    {
                        sum = 0;
                    }
                    else if (age <= 18)
                    {
                        sum = 12;
                    }
                    else if (age <= 64)
                    {
                        sum = 18;
                    }
                    else 
                    {
                        sum = 12;
                    }
                    break;
                case "weekend":
                    if (age < 0 || age > 122)
                    {
                        sum = 0;
                    }
                    else if (age <= 18)
                    {
                        sum = 15;
                    }
                    else if (age <= 64)
                    {
                        sum = 20;
                    }
                    else 
                    {
                        sum = 15;
                    }
                    break;
                case "holiday":
                    if (age < 0 || age > 122)
                    {
                        sum = 0;
                    }
                    else if (age <= 18)
                    {
                        sum = 5;
                    }
                    else if (age <= 64)
                    {
                        sum = 12;
                    }
                    else 
                    {
                        sum = 10;
                    }
                    break;
            }
            if (sum == 0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{sum}$");
            }
        }
    }
}
