using System;

namespace _05_BooleanVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputText = Console.ReadLine();
            bool isTrue = Convert.ToBoolean(inputText);
            if (isTrue)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
