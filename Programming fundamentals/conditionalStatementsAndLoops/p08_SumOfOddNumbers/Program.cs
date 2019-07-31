using System;

namespace p08_SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            int i = 1;

            while (count < numbers)
            {
                if ((i % 2 == 0) == false)
                {
                    Console.WriteLine(i);
                    count++;
                    sum += i;
                }
                i++;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
