using System;
using System.Text;

namespace _03_TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < banWords.Length; i++)
            {
                string asterisks = new string('*', banWords[i].Length);
                text = text.Replace(banWords[i], asterisks);
            }


            Console.WriteLine(text);
        }
    }
}
