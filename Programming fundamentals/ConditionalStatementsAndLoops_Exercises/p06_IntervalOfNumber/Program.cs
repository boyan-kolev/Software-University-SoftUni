using System;

namespace p06_IntervalOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            int minNumber = Math.Min(number1, number2);
            int maxNumber = Math.Max(number1, number2);

            for (int i = minNumber; i <= maxNumber; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}
