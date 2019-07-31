using System;

namespace p12_NumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            Console.WriteLine("It is a number.");
        }
    }
}
