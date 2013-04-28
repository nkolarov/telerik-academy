using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamingIdentifiers
{
    public class Minesweeper
    {
        private const int ROWS = 5;
        private const int COLUMNS = 10;

        public static void Main()
        {
            const int MAX_POINTS = 35;
            List<Score> topScoringPlayers = new List<Score>(6);
            int row = 0;
            int column = 0;
            int pointsCounter = 0;
            string command = string.Empty;
            char[,] gameField = GeneratePlayground();
            char[,] mines = InitializeMines();
            bool isNewGame = true;
            bool isVictory = false;
            bool exploded = false;
            
            do
            {
                if (isNewGame)
                {
                    StringBuilder welcomeMessage = new StringBuilder();
                    
                    welcomeMessage.AppendLine("Let`s play Minesweeper.");
                    welcomeMessage.AppendLine(string.Empty);
                    welcomeMessage.AppendLine("Avaiable Commands:");
                    welcomeMessage.AppendLine("top".PadRight(10) + "-> Show Ranking");
                    welcomeMessage.AppendLine("restart".PadRight(10) + "-> Start New Game");
                    welcomeMessage.AppendLine("exit".PadRight(10) + "-> Close Game");

                    Console.WriteLine(welcomeMessage.ToString());
                    PrintField(gameField);
                    isNewGame = false;
                }

                Console.WriteLine("Please enter your guess.");
                Console.WriteLine("Format: ROW COL Example: 0 0");

                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRanking(topScoringPlayers);
                        break;
                    case "restart":
                        gameField = GeneratePlayground();
                        mines = InitializeMines();
                        PrintField(gameField);
                        exploded = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                StoreCurrentMove(gameField, mines, row, column);
                                pointsCounter++;
                            }

                            if (pointsCounter == MAX_POINTS)
                            {
                                isVictory = true;
                            }
                            else
                            {
                                PrintField(gameField);
                            }
                        }
                        else
                        {
                            exploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid Command\n");
                        break;
                }

                if (exploded)
                {
                    PrintField(mines);
                    Console.WriteLine("\nBOOOMMM! You hit a mine! Your Score: {0}", pointsCounter);
                    Console.WriteLine("Please enter your nick name:");

                    string nickName = Console.ReadLine();
                    Score playerScore = new Score(nickName, pointsCounter);
                    if (topScoringPlayers.Count < 5)
                    {
                        topScoringPlayers.Add(playerScore);
                    }
                    else
                    {
                        for (int currentPlayer = 0; currentPlayer < topScoringPlayers.Count; currentPlayer++)
                        {
                            if (topScoringPlayers[currentPlayer].Points < playerScore.Points)
                            {
                                topScoringPlayers.Insert(currentPlayer, playerScore);
                                topScoringPlayers.RemoveAt(topScoringPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topScoringPlayers.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    topScoringPlayers.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    PrintRanking(topScoringPlayers);

                    gameField = GeneratePlayground();
                    mines = InitializeMines();
                    pointsCounter = 0;
                    exploded = false;
                    isNewGame = true;
                }

                if (isVictory)
                {
                    Console.WriteLine("\nCongratulations! You won!");
                    PrintField(mines);
                    Console.WriteLine("Please enter your nick name:");
                    string nickName = Console.ReadLine();
                    Score playerScore = new Score(nickName, pointsCounter);
                    topScoringPlayers.Add(playerScore);
                    PrintRanking(topScoringPlayers);
                    gameField = GeneratePlayground();
                    mines = InitializeMines();
                    pointsCounter = 0;
                    isVictory = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
        }

        private static void PrintRanking(List<Score> points)
        {
            Console.WriteLine();
            Console.WriteLine("Ranking:");

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ranking is empty!\n");
            }
        }

        private static void StoreCurrentMove(char[,] gamesField, char[,] mined, int currentRow, int currentColumn)
        {
            char minesCount = GetMinesCount(mined, currentRow, currentColumn);
            mined[currentRow, currentColumn] = minesCount;
            gamesField[currentRow, currentColumn] = minesCount;
        }

        private static void PrintField(char[,] board)
        {
            StringBuilder field = new StringBuilder();

            field.AppendLine(string.Empty);
            field.AppendLine("    0 1 2 3 4 5 6 7 8 9");
            field.AppendLine("   ---------------------");

            for (int row = 0; row < ROWS; row++)
            {
                field.AppendFormat("{0} | ", row);

                for (int col = 0; col < COLUMNS; col++)
                {
                    field.AppendFormat("{0} ", board[row, col]);
                }

                field.AppendLine("|");
            }

            field.AppendLine("   ---------------------");

            Console.WriteLine(field.ToString());
        }

        private static char[,] GeneratePlayground()
        {
            char[,] board = new char[ROWS, COLUMNS];

            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    board[row, column] = '?';
                }
            }

            return board;
        }

        private static char[,] InitializeMines()
        {
            char[,] gameField = new char[ROWS, COLUMNS];

            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    gameField[row, column] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();

            while (randomNumbers.Count < 15)
            {
                Random randomGenerator = new Random();

                int currentNumber = randomGenerator.Next(50);
                if (!randomNumbers.Contains(currentNumber))
                {
                    randomNumbers.Add(currentNumber);
                }
            }

            foreach (int randomNumber in randomNumbers)
            {
                int column = randomNumber / COLUMNS;
                int row = randomNumber % COLUMNS;

                if (row == 0 && randomNumber != 0)
                {
                    column--;
                    row = COLUMNS;
                }
                else
                {
                    row++;
                }

                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        //// Currently not used
        //private static void SetMinesCount(char[,] gameField)
        //{
        //    int columnCount = gameField.GetLength(0);
        //    int rowCount = gameField.GetLength(1);

        //    for (int col = 0; col < columnCount; col++)
        //    {
        //        for (int row = 0; row < rowCount; row++)
        //        {
        //            if (gameField[col, row] != '*')
        //            {
        //                char minesCounter = GetMinesCount(gameField, col, row);
        //                gameField[col, row] = minesCounter;
        //            }
        //        }
        //    }
        //}

        private static char GetMinesCount(char[,] mines, int row, int column)
        {
            int minesCounter = 0;

            if (row - 1 >= 0)
            {
                if (mines[row - 1, column] == '*')
                { 
                    minesCounter++; 
                }
            }

            if (row + 1 < ROWS)
            {
                if (mines[row + 1, column] == '*')
                { 
                    minesCounter++; 
                }
            }

            if (column - 1 >= 0)
            {
                if (mines[row, column - 1] == '*')
                { 
                    minesCounter++;
                }
            }

            if (column + 1 < COLUMNS)
            {
                if (mines[row, column + 1] == '*')
                { 
                    minesCounter++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (mines[row - 1, column - 1] == '*')
                { 
                    minesCounter++; 
                }
            }

            if ((row - 1 >= 0) && (column + 1 < COLUMNS))
            {
                if (mines[row - 1, column + 1] == '*')
                { 
                    minesCounter++; 
                }
            }

            if ((row + 1 < ROWS) && (column - 1 >= 0))
            {
                if (mines[row + 1, column - 1] == '*')
                { 
                    minesCounter++; 
                }
            }

            if ((row + 1 < ROWS) && (column + 1 < COLUMNS))
            {
                if (mines[row + 1, column + 1] == '*')
                { 
                    minesCounter++; 
                }
            }

            return char.Parse(minesCounter.ToString());
        }
    }
}