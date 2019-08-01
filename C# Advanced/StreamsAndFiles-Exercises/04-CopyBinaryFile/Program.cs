using System;
using System.IO;

namespace _04_CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using(FileStream sourceFile = new FileStream("../../../../copyMe.png", FileMode.Open))
            {
                using (FileStream destinationFile = new FileStream("../../../new-copyMe.png", FileMode.Create))
                {
                    for (int i = 0; i < sourceFile.Length; i++)
                    {
                        destinationFile.WriteByte((byte)sourceFile.ReadByte());
                    }
                }
            }
        }
    }
}
