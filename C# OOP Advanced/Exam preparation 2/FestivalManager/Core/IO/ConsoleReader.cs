using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
    using System;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
