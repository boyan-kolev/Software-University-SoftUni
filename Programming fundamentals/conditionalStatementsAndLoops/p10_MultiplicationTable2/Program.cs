using System;

namespace p10_MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier <= 10)
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine($"{integer} X {i} = {integer * i}");
                }

            }
            else
            {
                Console.WriteLine($"{integer} X {multiplier} = {integer * multiplier}");
            }

;
        }
    }
}
