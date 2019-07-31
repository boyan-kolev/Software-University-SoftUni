using System;

namespace _03_EnglishNameOfLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            String nameOfLastDigit = GetNameOfLastDigit(number);
            Console.WriteLine(nameOfLastDigit);
        }

        static String GetNameOfLastDigit(long number)
        {
            number = Math.Abs(number);
            long lastDigit = number % 10;
            String nameOfLastDig = String.Empty;
            switch (lastDigit)
            {
                case 0:
                    nameOfLastDig = "zero";
                    break;
                case 1:
                    nameOfLastDig = ("one");
                    break;
                case 2:
                    nameOfLastDig = ("two");
                    break;
                case 3:
                    nameOfLastDig = ("three");
                    break;
                case 4:
                    nameOfLastDig = ("four");
                    break;
                case 5:
                    nameOfLastDig = ("five");
                    break;
                case 6:
                    nameOfLastDig = ("six");
                    break;
                case 7:
                    nameOfLastDig = ("seven");
                    break;
                case 8:
                    nameOfLastDig = ("eight");
                    break;
                case 9:
                    nameOfLastDig = ("nine");
                    break;               
            }
            return nameOfLastDig;
        }
    }
}
