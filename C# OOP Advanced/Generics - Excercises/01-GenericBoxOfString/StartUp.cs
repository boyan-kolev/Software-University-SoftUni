namespace GenericBoxOfString
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numOfLines; counter++)
            {
                Box<string> box = new Box<string>();
                box.Info = Console.ReadLine();
                Console.WriteLine(box);
            }
        }
    }
}
