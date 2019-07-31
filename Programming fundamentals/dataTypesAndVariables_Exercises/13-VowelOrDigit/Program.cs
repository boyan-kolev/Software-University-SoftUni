using System;

namespace _13_VowelOrDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            switch (symbol)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                case 'y':
                    Console.WriteLine("vowel");
                    break;
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                    Console.WriteLine("digit");
                    break;
                default:
                    Console.WriteLine("other");
                    break;

            }
        }
    }
}
