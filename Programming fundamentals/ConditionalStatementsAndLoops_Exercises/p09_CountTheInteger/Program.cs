using System;

namespace p09_CountTheInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (count <= 100)
            {
            try
            {
                int number = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                break;
            }
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
