namespace GenericCountMethodStrings
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int counter = 0; counter < numOfLines; counter++)
            {
                string item = Console.ReadLine();
                box.Items.Add(item);
            }

            string element = Console.ReadLine();

            int countOfGreaterElement = box.CompareWithElement(element);

            Console.WriteLine(countOfGreaterElement);
        }
    }
}
