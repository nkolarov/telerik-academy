// ********************************
// <copyright file="TypesOfExplosionsChoice.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines
{
    using System;
    using System.Linq;

    /// <summary>
    /// Putting the type of explosions and its choice in static class
    /// </summary>
    public static class TypesOfExplosionsChoice
    {
        /// <summary>
        /// Represents explosion level one.
        /// </summary>
        private static readonly int[,] explosionLevelOne =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

        /// <summary>
        /// Represents explosion level two.
        /// </summary>
        private static readonly int[,] explosionLevelTwo =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

        /// <summary>
        /// Represents explosion level three.
        /// </summary>
        private static readonly int[,] explosionLevelThree =
        {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };

        /// <summary>
        /// Represents explosion level four.
        /// </summary>
        private static readonly int[,] explosionLevelFour =
        {
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 }
        };

        /// <summary>
        /// Represents explosion level five.
        /// </summary>
        private static readonly int[,] explosionLevelFive =
        {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };

        /// <summary>
        /// Gets the explosion by given row and col.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <returns>The corresponding explosion.</returns>
        public static int[,] GetExplosion(int[,] matrix, int row, int col)
        {
            // zadava ni koi vid bomba imame
            switch (matrix[row, col]) 
            {
                case 1:
                    return explosionLevelOne;
                case 2:
                    return explosionLevelTwo;
                case 3:
                    return explosionLevelThree;
                case 4:
                    return explosionLevelFour;
                default:
                    return explosionLevelFive;
            }
        }
    }
}