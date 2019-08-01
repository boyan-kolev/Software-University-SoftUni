using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            stack.Push("Pesho");
            stack.Push("Pipi");
            stack.Push("Koko");
            stack.Push("Mimi");
            stack.Push("Gosho");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.IsEmpty());
        }
    }
}
