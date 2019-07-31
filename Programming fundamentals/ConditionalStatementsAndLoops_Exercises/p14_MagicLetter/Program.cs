using System;

namespace p14_MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char withoutLetter = char.Parse(Console.ReadLine());

            for (char i = firstLetter; i <= secondLetter; i++)
            {
                for (char j = firstLetter; j <= secondLetter; j++)
                {
                    for (char k = firstLetter; k <= secondLetter; k++)
                    {
                        if (i == withoutLetter || j == withoutLetter || k == withoutLetter)
                        {
                            continue;
                        }
                        Console.Write($"{i}{j}{k} ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
