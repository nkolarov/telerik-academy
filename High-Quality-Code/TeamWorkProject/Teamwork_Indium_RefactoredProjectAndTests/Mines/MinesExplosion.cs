// ********************************
// <copyright file="MinesExplosion.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class for exploding the mines in brutal fashion.Class also checks the type of explosions
    /// </summary>
    public static class MinesExplosion
    {
        /// <summary>
        /// The method stores the number of the nearby mines in destroyedNearMinesCount
        /// </summary>
        /// <param name="gameField">The game field size</param>
        /// <param name="gameFieldSize">The range of the mine</param>
        /// <param name="xCoordinate">The x-coordinate.</param>
        /// <param name="yCoordinate">The y-coordinate.</param>
        /// <returns>int destroyedNearMinesCount - the </returns>
        public static int CheckForExplosion(int[,] gameField, int xCoordinate, int yCoordinate)
        {
            int gameFieldSize = gameField.GetLength(0);
            int[,] explosionDamageArea;

            // TODO make a new class for making the type of explosion
            explosionDamageArea = TypesOfExplosionsChoice.GetExplosion(gameField, xCoordinate, yCoordinate);

            int destroyedNearMinesCount = 0;

            for (int collumn = -2; collumn < 3; collumn++)
            {
                for (int row = -2; row < 3; row++)
                {
                    bool isInsideBattleField = xCoordinate + collumn >= 0 && xCoordinate + collumn < gameFieldSize &&
                                               yCoordinate + row >= 0 && yCoordinate + row < gameFieldSize;

                    if (isInsideBattleField)
                    {
                        if (explosionDamageArea[collumn + 2, row + 2] == 1)
                        {
                            if (gameField[xCoordinate + collumn, yCoordinate + row] > 0)
                            {
                                destroyedNearMinesCount++;
                            }

                            gameField[xCoordinate + collumn, yCoordinate + row] = -1;
                        }
                    }
                }
            }

            return destroyedNearMinesCount;
        }
    }
}