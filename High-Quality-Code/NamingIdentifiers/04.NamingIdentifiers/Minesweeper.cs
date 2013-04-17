using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamingIdentifiers
{
    public class Minesweeper
    {
        private const int Rows = 5;
        private const int Columns = 10;

        public static void Main()
        {
            string command = string.Empty;
            char[,] gameField = GeneratePlayground();
            char[,] mines = InitializeMines();
            int pointsCounter = 0;
            bool exploded = false;
            List<Score> topScoringPlayers = new List<Score>(6);
            int row = 0;
            int column = 0;
            bool startGame = true;
            const int MaxPoints = 35;
            bool victory = false;

            do
            {
                if (startGame)
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
                    startGame = false;
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
                        startGame = false;
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

                            if (MaxPoints == pointsCounter)
                            {
                                victory = true;
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

                    string niknejm = Console.ReadLine();
                    Score t = new Score(niknejm, pointsCounter);
                    if (topScoringPlayers.Count < 5)
                    {
                        topScoringPlayers.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < topScoringPlayers.Count; i++)
                        {
                            if (topScoringPlayers[i].Points < t.Points)
                            {
                                topScoringPlayers.Insert(i, t);
                                topScoringPlayers.RemoveAt(topScoringPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topScoringPlayers.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    topScoringPlayers.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    PrintRanking(topScoringPlayers);

                    gameField = GeneratePlayground();
                    mines = InitializeMines();
                    pointsCounter = 0;
                    exploded = false;
                    startGame = true;
                }

                if (victory)
                {
                    Console.WriteLine("\nCongratulations! You win!");
                    PrintField(mines);
                    Console.WriteLine("Please enter your nick name:");
                    string imeee = Console.ReadLine();
                    Score to4kii = new Score(imeee, pointsCounter);
                    topScoringPlayers.Add(to4kii);
                    PrintRanking(topScoringPlayers);
                    gameField = GeneratePlayground();
                    mines = InitializeMines();
                    pointsCounter = 0;
                    victory = false;
                    startGame = true;
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

            for (int row = 0; row < Rows; row++)
            {
                field.AppendFormat("{0} | ", row);

                for (int col = 0; col < Columns; col++)
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
            char[,] board = new char[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] InitializeMines()
        {
            char[,] gameField = new char[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    gameField[i, j] = '-';
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
                int column = randomNumber / Columns;
                int row = randomNumber % Columns;

                if (row == 0 && randomNumber != 0)
                {
                    column--;
                    row = Columns;
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

            if (row + 1 < Rows)
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

            if (column + 1 < Columns)
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

            if ((row - 1 >= 0) && (column + 1 < Columns))
            {
                if (mines[row - 1, column + 1] == '*')
                { 
                    minesCounter++; 
                }
            }

            if ((row + 1 < Rows) && (column - 1 >= 0))
            {
                if (mines[row + 1, column - 1] == '*')
                { 
                    minesCounter++; 
                }
            }

            if ((row + 1 < Rows) && (column + 1 < Columns))
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