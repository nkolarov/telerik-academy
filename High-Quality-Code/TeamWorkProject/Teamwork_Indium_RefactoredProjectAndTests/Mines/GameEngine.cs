// ********************************
// <copyright file="GameEngine.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents the game engine.
    /// </summary>
    public static class GameEngine
    {
        /// <summary>
        /// Initiates the game.
        /// </summary>
        public static void InitiateGame()
        {
            GameBoardGenerator.GetBoardSize();

            PrintGameBoard.PrintField(GameBoardGenerator.GameField);

            CheckForVictory(GameBoardGenerator.MinesNumber, GameBoardGenerator.GameField);
        }

        /// <summary>
        /// Checks for victory.
        /// </summary>
        /// <param name="totalMinesNumber">The total mines number.</param>
        /// <param name="gameField">The game field.</param>
        /// <param name="fieldSize">Size of the field.</param>
        private static void CheckForVictory(int totalMinesNumber, int[,] gameField)
        {
            int totalNumberOfMoves = 0;

            while (totalMinesNumber > 0)
            {
                GameInput.ManageUserInput(gameField);
                int blownMinesThisRound = MinesExplosion.CheckForExplosion(gameField,GameInput.RowCoordinate, GameInput.ColCoordinate);
                totalMinesNumber -= blownMinesThisRound;
                PrintGameBoard.PrintField(gameField);
                Console.WriteLine("Mines Blowed this round: {0}", blownMinesThisRound);
                totalNumberOfMoves++;
            }

            Console.WriteLine("Congratulations you won the game in {0} moves", totalNumberOfMoves);
        }
    }
}