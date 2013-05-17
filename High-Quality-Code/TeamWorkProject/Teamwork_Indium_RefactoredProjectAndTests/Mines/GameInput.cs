// ********************************
// <copyright file="GameInput.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines
{
    using System;
    using System.Linq;

    /// <summary>
    /// Game input in separate static class-game variables input is here
    /// </summary>
    public static class GameInput
    {
        /// <summary>
        /// ManageUserInput is asking the user to input coordinates in the int[,] gameField and responds accordingly.
        /// </summary>
        /// <param name="gameField">The matrix representing the game field.</param>
        /// <returns>Explosion state.</returns>
        
        /// <summary>
        /// X Coordinate(Row) from the input can be seen from anyone
        /// </summary>
        public static int RowCoordinate { private set; get; }
        /// <summary>
        /// Y Coordinate(Column) from the input can be seen from anyone
        /// </summary>
        public static int ColCoordinate { private set; get; }

        public static void ManageUserInput(int[,] gameField)
        {
            // Reset the coordinates value.
            bool isSelectingNextCoordinates = true;
            int fieldSize=gameField.GetLength(0);
            RowCoordinate = 0;
            ColCoordinate = 0;

            // Checks if the user input is correct for every single coordinates choosen.
            while (isSelectingNextCoordinates)
            {
                Console.Write("Please enter coordinates: ");

                string selectedCoordinates = Console.ReadLine();

                if (selectedCoordinates.Length == 3)
                {
                    if (char.IsWhiteSpace(selectedCoordinates, 1))
                    {
                        RowCoordinate = selectedCoordinates.ElementAt(0) - '0';
                        ColCoordinate = selectedCoordinates.ElementAt(2) - '0';
                        
                        bool isOutsideBattleField = (RowCoordinate < 0 || RowCoordinate > fieldSize 
                            || ColCoordinate < 0 || ColCoordinate > fieldSize);
                        if (isOutsideBattleField)
                        {
                            if (RowCoordinate > 10 || ColCoordinate > 10)
                            {
                                Console.WriteLine("Choose x and y coordinates, seperated by white space in correct format [Example:2 5]");
                            }
                            else
                            {
                                Console.WriteLine("Outside of Field Range");
                            }
                        }
                        else
                        {
                            isSelectingNextCoordinates = false;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Choose x and y coordinates, seperated by white space in correct format [Example:2 5]");
                }

                if (isSelectingNextCoordinates == false)
                {
                    if (gameField[RowCoordinate, ColCoordinate] <= 0)
                    {
                        isSelectingNextCoordinates = true;

                        Console.WriteLine("Empty Field! Choose another coordinates!");
                    }
                }
            }
        }
    }
}