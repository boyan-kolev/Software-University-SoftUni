using System;

namespace p05_WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            String word = Console.ReadLine();
            if (word.EndsWith("y"))
            {
                word = word.Remove(word.Length - 1);
                Console.WriteLine(word + "ies");
                return;
            }
            //o, ch, s, sh, x or z 
            if (word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("s") || word.EndsWith("sh") || word.EndsWith("x") || word.EndsWith("z"))
            {
                Console.WriteLine(word + "es");
                return;
            }
            else
            {
                Console.WriteLine(word + "s");
            }
        }
    }
}
