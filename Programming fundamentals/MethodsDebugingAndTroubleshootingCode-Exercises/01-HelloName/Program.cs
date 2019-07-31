using System;

namespace _01_HelloName
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = Console.ReadLine();
            PrintName(name);
        }
        static void PrintName(String name)
        {
            Console.WriteLine("Hello, {0}!",name);
        }
    }
}
