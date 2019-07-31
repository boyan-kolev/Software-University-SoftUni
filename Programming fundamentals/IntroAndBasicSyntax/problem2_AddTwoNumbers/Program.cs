using System;

namespace problem2_AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int sum = number1 + number2;

            Console.WriteLine($"{number1} + {number2} = {sum}");

        }
    }
}
