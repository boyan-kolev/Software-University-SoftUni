namespace Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const int PrintCount = 2;
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input = Console.ReadLine();
            while (input != "END")
            {

                if (input == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    int[] elements = input.Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();

                    foreach (var element in elements)
                    {
                        stack.Push(element);
                    }

                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < PrintCount; i++)
            {
                Console.WriteLine(string.Join(Environment.NewLine, stack));
            }
        }
    }
}
