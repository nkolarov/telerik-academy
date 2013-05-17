// ********************************
// <copyright file="PrintGameBoard.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Made a static class PrintGameField with static method PrintField from class Battlefield
    /// </summary>
    public static class PrintGameBoard
    {
        /// <summary>
        /// Prints the game field.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="matrixSize">Size of the matrix.</param>
        public static void PrintField(int[,] matrix)
        {
            string buffer = GenerateField(matrix, matrix.GetLength(0));
            Console.Write(buffer);
        }

        /// <summary>
        /// Generates the game field.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="matrixSize">Size of the matrix.</param>
        /// <returns>The generated field.</returns>
        private static string GenerateField(int[,] matrix, int matrixSize)
        {
            StringBuilder buffer = new StringBuilder();

            // Prints first row
            buffer.Append(" ");
            for (int i = 0; i < matrixSize; i++)
            {
                buffer.Append(" " + i);
            }

            buffer.AppendLine();

            // Prints second row
            buffer.Append("  ");
            for (int i = 0; i < matrixSize * 2; i++)
            {
                buffer.Append("-");
            }

            // Prints the game field.
            buffer.AppendLine();
            for (int row = 0; row < matrixSize; row++)
            {
                buffer.Append(row);
                buffer.Append("|");
                for (int col = 0; col < matrixSize; col++)
                {
                    char currentCharacter = GetCharacter(matrix, row, col);
                    buffer.Append(currentCharacter);
                    buffer.Append(" ");
                }

                buffer.AppendLine();
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Gets a character from matrix by given row and col.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <returns>The character.</returns>
        private static char GetCharacter(int[,] matrix, int row, int col)
        {
            char currentCharacter;
            switch (matrix[row, col])
            {
                case 0:
                    currentCharacter = '-';
                    break;
                case -1:
                    currentCharacter = 'X';
                    break;
                default:
                    currentCharacter = (char)('0' + matrix[row, col]);
                    break;
            }

            return currentCharacter;
        }
    }
}