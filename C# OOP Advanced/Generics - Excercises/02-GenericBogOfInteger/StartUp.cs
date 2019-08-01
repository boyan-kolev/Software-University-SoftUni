namespace GenericBoxOfInteger
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numOfLines; counter++)
            {
                Box<int> box = new Box<int>();
                box.Info = int.Parse(Console.ReadLine());
                Console.WriteLine(box);
            }
        }
    }
}
