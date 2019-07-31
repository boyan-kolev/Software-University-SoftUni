using System;

namespace _06_StringAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            String word1 = "Hello";
            String word2 = "World";
            object text = word1 + " " + word2;
            String outputText = (String)text;
            Console.WriteLine(outputText);


        }
    }
}
