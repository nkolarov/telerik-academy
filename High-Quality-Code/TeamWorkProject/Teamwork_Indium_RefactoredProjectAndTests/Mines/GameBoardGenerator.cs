// ********************************
// <copyright file="GameBoardGenerator.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents the game field generator.
    /// </summary>
    public static class GameBoardGenerator
    {
        /// <summary>
        /// Stores the game field.
        /// </summary>
        private static int[,] gameField;

        /// <summary>
        /// Gets the game field.
        /// </summary>
        /// <value>The game field.</value>
        public static int[,] GameField
        {
            get
            {
                if (gameField.Length == 0)
                {
                    throw new NullReferenceException("The game field is not yet created");
                }
                else
                {
                    return gameField;
                }
            }
        }

        /// <summary>
        /// Gets the mines number.
        /// </summary>
        /// <value>The mines number.</value>
        public static int MinesNumber { get; private set; }

        /// <summary>
        /// Reads the size of the board.
        /// </summary>
        public static void GetBoardSize()
        {
            Console.WriteLine("Welcome to \"Battle Field\" game.");
            Console.Write("Enter battle field size between 1 and 10: ");
            int fieldSize;
            int.TryParse(Console.ReadLine(), out fieldSize);
            while (fieldSize < 1 || fieldSize > 10)
            {
                Console.Write("Size must be between 1 and 10 \nInput new size:");
                int.TryParse(Console.ReadLine(), out fieldSize);
            }

            CreateGameBoard(fieldSize);
        }

        /// <summary>
        /// Represents a generator for random numbers.
        /// </summary>
        /// <param name="startRange">The start range.</param>
        /// <param name="endRange">The end range.</param>
        /// <returns>A random number.</returns>
        private static int RandomGenerator(int startRange, int endRange)
        {
            Random randomNumber = new Random();
            int result = randomNumber.Next(startRange, endRange);
            return result;
        }

        /// <summary>
        /// Creates the game board.
        /// </summary>
        /// <param name="boardSize">Size of the board.</param>
        private static void CreateGameBoard(int boardSize)
        {
            int startRandomRange = ((15 * boardSize * boardSize) / 100) + 1;
            int endRandomRange = ((30 * boardSize * boardSize) / 100) + 1;
            MinesNumber = RandomGenerator(startRandomRange, endRandomRange);

            gameField = new int[boardSize, boardSize];

            // Randomizing the positions of the mines on the field
            for (int i = 0; i < MinesNumber; i++) 
            {
                int x = RandomGenerator(0, boardSize);
                int y = RandomGenerator(0, boardSize);
                while (gameField[x, y] != 0)
                {
                    x = RandomGenerator(0, boardSize);
                    y = RandomGenerator(0, boardSize);
                }

                gameField[x, y] = RandomGenerator(1, 6);
            }
        }
    }
}