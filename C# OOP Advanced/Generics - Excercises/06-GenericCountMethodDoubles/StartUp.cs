namespace GenericCountMethodDoubles
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int counter = 0; counter < numOfLines; counter++)
            {
                double item = double.Parse(Console.ReadLine());
                box.Items.Add(item);
            }

            double element = double.Parse(Console.ReadLine());

            int countOfGreaterElement = box.CompareWithElement(element);

            Console.WriteLine(countOfGreaterElement);
        }
    }
}
