using StorageMaster.Core;
using System;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new StorageMaster());
            engine.Run();
        }
    }
}
