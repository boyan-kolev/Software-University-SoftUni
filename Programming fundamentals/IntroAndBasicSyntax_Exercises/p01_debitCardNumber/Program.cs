using System;

namespace p01_debitCardNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"{firstNumber:d4} {secondNumber:d4} {thirdNumber:d4} {fourthNumber:d4}");
        }
    }
}
