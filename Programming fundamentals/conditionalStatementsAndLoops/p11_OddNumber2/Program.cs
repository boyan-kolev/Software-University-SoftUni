using System;

namespace p11_OddNumber2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (number % 2 == 0)
                    {
                        Console.WriteLine("Please write an odd number.");
                        number = int.Parse(Console.ReadLine());
                    }
                }


            }
            number = Math.Abs(number);
            Console.WriteLine($"The number is: {number}");
        }
    }
}
