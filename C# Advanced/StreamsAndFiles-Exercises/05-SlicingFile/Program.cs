using System;
using System.IO;

namespace _05_SlicingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = 0;
            using (FileStream sourceFile = new FileStream("../../../../sliceMe.mp4", FileMode.Open))
            {
                using (FileStream destinationDirectory = new FileStream("../../../new-sliceMe", FileMode.Create))
                {
                    Slice(sourceFile, destinationDirectory, parts);
                }
            }
        }

        private static void Slice(FileStream sourceFile, FileStream destinationDirectory, int parts)
        {
            sourceFile.
        }
    }
}
