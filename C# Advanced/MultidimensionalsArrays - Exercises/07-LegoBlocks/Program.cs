using System;
using System.Linq;

namespace _07_LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int[][] firstBlocks = new int[numberOfRows][];
            int[][] secondBlocks = new int[numberOfRows][];

            firstBlocks = FillJagedArray(firstBlocks);
            secondBlocks = FillJagedArray(secondBlocks);

            secondBlocks = ReverseJagedArray(secondBlocks);

            int[][] matchedBlocks = new int[numberOfRows][];
            matchedBlocks = JoinArrays(matchedBlocks, firstBlocks, secondBlocks);

            int columnLength = matchedBlocks[0].Length;
            bool isMatched = true;

            for (int row = 1; row < matchedBlocks.Length; row++)
            {
                if (columnLength != matchedBlocks[row].Length)
                {
                    isMatched = false;
                }

                columnLength = matchedBlocks[row].Length;
            }

            if (isMatched)
            {
                for (int row = 0; row < matchedBlocks.Length; row++)
                {
                    Console.WriteLine("[" + string.Join(", ", matchedBlocks[row]) + "]");
                }
            }
            else
            {
                int counterCell = 0;
                for (int row = 0; row < matchedBlocks.Length; row++)
                {
                    counterCell += matchedBlocks[row].Length;
                }

                Console.WriteLine($"The total number of cells is: {counterCell}");
            }
        }

        private static int[][] JoinArrays(int[][] matchedBlocks, int[][] firstBlocks, int[][] secondBlocks)
        {
            for (int row = 0; row < matchedBlocks.Length; row++)
            {
                int columnLength = firstBlocks[row].Length + secondBlocks[row].Length;
                matchedBlocks[row] = new int[columnLength];

                for (int column = 0; column < firstBlocks[row].Length; column++)
                {
                    matchedBlocks[row][column] = firstBlocks[row][column];
                }

                int columnCounter = 0;

                for (int column = firstBlocks[row].Length; column < matchedBlocks[row].Length; column++)
                {
                    matchedBlocks[row][column] = secondBlocks[row][columnCounter];
                    columnCounter++;
                }
            }

            return matchedBlocks;
        }

        private static int[][] ReverseJagedArray(int[][] jagedArray)
        {
            for (int row = 0; row < jagedArray.Length; row++)
            {
                for (int column = 0; column < jagedArray[row].Length / 2; column++)
                {
                    int temp = jagedArray[row][column];
                    jagedArray[row][column] = jagedArray[row][jagedArray[row].Length - column - 1];
                    jagedArray[row][jagedArray[row].Length - column - 1] = temp;
                }
            }

            return jagedArray;
        }

        private static int[][] FillJagedArray(int[][] jagedArray)
        {
            for (int row = 0; row < jagedArray.Length; row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jagedArray[row] = new int[currRow.Length];

                for (int column = 0; column < jagedArray[row].Length; column++)
                {
                    jagedArray[row][column] = currRow[column];
                }
            }

            return jagedArray;
        }
    }
}
