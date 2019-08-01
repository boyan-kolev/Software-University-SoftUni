using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Rubik_sMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<List<int>> matrix = new List<List<int>>();
            int counterValue = 1;

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                matrix.Add(new List<int>());
                for (int columns = 0; columns < rowsAndColumns[1]; columns++)
                {
                    matrix[rows].Add(counterValue);
                    counterValue++;
                }

            }


            int countOfCommands = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < countOfCommands; counter++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[1];

                if (command == "up")
                {
                    int columnIndex = int.Parse(input[0]);
                    Queue<int> column = new Queue<int>(rowsAndColumns[0]);

                    for (int counterRows = 0; counterRows < rowsAndColumns[0]; counterRows++)
                    {
                        column.Enqueue(matrix[counterRows][columnIndex]);
                    }

                    int moves = int.Parse(input[2]);

                    for (int counterMoves = 0; counterMoves < moves % matrix.Count; counterMoves++)
                    {
                        column.Enqueue(column.Dequeue());
                    }

                    for (int counterRows = 0; counterRows < rowsAndColumns[0]; counterRows++)
                    {
                        matrix[counterRows][columnIndex] = column.Dequeue();
                    }
                }
                else if (command == "down")
                {
                    int columnIndex = int.Parse(input[0]);
                    Queue<int> column = new Queue<int>(rowsAndColumns[0]);

                    for (int counterRows = rowsAndColumns[0] - 1; counterRows >= 0; counterRows--)
                    {
                        column.Enqueue(matrix[counterRows][columnIndex]);
                    }

                    int moves = int.Parse(input[2]);

                    for (int counterMoves = (moves % matrix.Count) - 1; counterMoves >= 0; counterMoves--)
                    {
                        column.Enqueue(column.Dequeue());
                    }

                    for (int counterRows = rowsAndColumns[0] - 1; counterRows >= 0; counterRows--)
                    {
                        matrix[counterRows][columnIndex] = column.Dequeue();
                    }
                }
                else if (command == "left")
                {
                    int rowIndex = int.Parse(input[0]);
                    int moves = int.Parse(input[2]);

                    for (int counterMoves = 0; counterMoves < moves % matrix[rowIndex].Count; counterMoves++)
                    {
                        int tempValue = matrix[rowIndex][0];
                        matrix[rowIndex].RemoveAt(0);
                        matrix[rowIndex].Add(tempValue);
                    }
                }
                else if (command == "right")
                {
                    int rowIndex = int.Parse(input[0]);
                    int moves = int.Parse(input[2]);

                    for (int counterMoves = 0; counterMoves < moves % matrix[rowIndex].Count; counterMoves++)
                    {
                        int tempValue = matrix[rowIndex][matrix[rowIndex].Count - 1];
                        matrix[rowIndex].RemoveAt(matrix[rowIndex].Count - 1);
                        matrix[rowIndex].Insert(0, tempValue);
                    }
                }
            }

            counterValue = 1;

            for (int rows = 0; rows < matrix.Count; rows++)
            {
                for (int columns = 0; columns < matrix[rows].Count; columns++)
                {
                    if (matrix[rows][columns] != counterValue)
                    {
                        for (int counterRows = rows; counterRows < matrix.Count; counterRows++)
                        {
                            for (int counterColumns = 0; counterColumns < matrix[counterRows].Count; counterColumns++)
                            {
                                if (matrix[counterRows][counterColumns] == counterValue)
                                {
                                    matrix[counterRows][counterColumns] = matrix[rows][columns];
                                    matrix[rows][columns] = counterValue;
                                    Console.WriteLine($"Swap ({rows}, {columns}) with ({counterRows}, {counterColumns})");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }

                    counterValue++;
                }
            }

        }
    }
}
