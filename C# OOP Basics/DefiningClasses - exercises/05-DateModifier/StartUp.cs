using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            double differenceDays = dateModifier.DifferenceBetweenTwoDates(firstDate, secondDate);

            Console.WriteLine(differenceDays);
        }
    }
}
