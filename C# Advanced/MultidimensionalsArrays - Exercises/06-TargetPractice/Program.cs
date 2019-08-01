using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int columns = sizes[1];

            string snake = Console.ReadLine();
            char[,] stairs = new char[rows, columns];
            int[] tokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            stairs = FillMatrix(stairs, snake);
            stairs = FireShot(tokens, stairs);
            stairs = FallDownSnakes(stairs);

            PrintMatrix(stairs);


        }

        private static void PrintMatrix(char[,] stairs)
        {
            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int column = 0; column < stairs.GetLength(1); column++)
                {
                    Console.Write(stairs[row, column]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] FallDownSnakes(char[,] stairs)
        {
            for (int column = stairs.GetLength(1) - 1; column >= 0; column--)
            {
                int emptyRows = 0;

                for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
                {
                    if (stairs[row, column] == ' ')
                    {
                        emptyRows++;
                    }
                    else if (stairs[row, column] != ' ' && emptyRows > 0)
                    {
                        stairs[emptyRows + row, column] = stairs[row, column];
                        stairs[row, column] = ' ';
                    }
                }
            }
            return stairs;
        }

        private static char[,] FireShot(int[] tokens, char[,] stairs)
        {
            int rowTarget = tokens[0];
            int columnTarget = tokens[1];
            int radius = tokens[2];

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int column = 0; column < stairs.GetLength(1); column++)
                {
                    int a = rowTarget - row;
                    int b = columnTarget - column;

                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance <= radius)
                    {
                        stairs[row, column] = ' ';
                    }

                }
            }
            return stairs;
        }

        private static char[,] FillMatrix(char[,] stairs, string snake)
        {
            bool isGoingLeft = true;
            int snakeCounter = 0;

            for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
            {
                int index = isGoingLeft ? stairs.GetLength(1) - 1 : 0;
                int increment = isGoingLeft ? -1 : 1;

                for (int column = 0; column < stairs.GetLength(1); column++)
                {
                    if (snakeCounter == snake.Length)
                    {
                        snakeCounter = 0;
                    }

                    stairs[row, index] = snake[snakeCounter];
                    index += increment;
                    snakeCounter++;
                }

                isGoingLeft = !isGoingLeft;
            }

            return stairs;
        }
    }
}
