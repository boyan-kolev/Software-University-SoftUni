using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightSabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            int lightSabers10Percentage = (int)Math.Ceiling((10.0 * countOfStudents / 100));
            int needSabers = countOfStudents + lightSabers10Percentage;
            int freeBelts = (int)(countOfStudents / 6);
            int needBelts = countOfStudents - freeBelts;

            double priceSabers = needSabers * priceOfLightSabers;
            double priceOfRobess = countOfStudents * priceOfRobes;
            double priceOfBeltss = needBelts * priceOfBelts;

            double totalPrice = priceSabers + priceOfRobess + priceOfBeltss;

            double restOfMoney = money - totalPrice;

            if (restOfMoney >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - money):f2}lv more.");
            }
        }
    }
}
