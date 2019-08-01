namespace ListyIterators
{
    using System;
    public class CommandInterpreter
    {
        private ListyIterator<string> listyIterator;
        public CommandInterpreter(string[] elements)
        {
            this.listyIterator = new ListyIterator<string>(elements);
        }
        public void InterpretCommand(string[] inputArgs)
        {
            switch (inputArgs[0])
            {
                case "Move":
                    bool IsMoved = this.listyIterator.Move();
                    Console.WriteLine(IsMoved);
                    break;
                case "HasNext":
                    bool isHasNext = this.listyIterator.HasNext();
                    Console.WriteLine(isHasNext);
                    break;
                case "Print":
                    this.listyIterator.Print();
                    break;
                case "PrintAll":
                    Console.WriteLine(string.Join(" ", this.listyIterator));
                    break;
            }
        }
    }
}
