namespace GenericSwapMethodInteger
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int counter = 0; counter < numOfLines; counter++)
            {
                int item = int.Parse(Console.ReadLine());
                box.Items.Add(item);
            }

            string[] indexes = Console.ReadLine().Split();
            int index1 = int.Parse(indexes[0]);
            int index2 = int.Parse(indexes[1]);

            box.SwapTwoItems(index1, index2);

            Console.WriteLine(box);
        }
    }
}
