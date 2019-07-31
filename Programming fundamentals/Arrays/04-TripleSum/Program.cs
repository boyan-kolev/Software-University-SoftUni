using System;
using System.Linq;

namespace _04_TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            String numbersAsStr = Console.ReadLine();
            long[] numbers = numbersAsStr.Split(' ')
                .Select(x => long.Parse(x))
                .ToArray();

            bool isTriples = true;
            for (int a = 0; a < numbers.Length; a++)
            {

                for (int b = a + 1; b < numbers.Length; b++)
                {

                    for (int c = 0; c < numbers.Length; c++)
                    {
                        if (numbers[a] + numbers[b] == numbers[c])
                        {
                            Console.WriteLine($"{numbers[a]} + {numbers[b]} == {numbers[c]}");
                            isTriples = false;
                            
                        }
                    }

                }
            }

            if (isTriples)
            {
                Console.WriteLine("No");
            }
        }
    }
}

