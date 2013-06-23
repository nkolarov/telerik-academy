using System;
using System.Collections.Generic;
using System.Text;

namespace Transformers
{
    public class Transformers
    { // TODO Implement Loose
        
        #region Properties

        public static Problem CurrentProblem { get; private set; }

        public static StringBuilder Matrix { get; set; }

        public static string NewSuggestion { get; set; }

        public static Input CurrentGuess { get; set; }

        public static bool Check { get; set; }

        public static bool Win { get; set; }

        public static List<int> Result { get; set; }

        public static int CountSuggestion { get; set; }

        public static Human Pesho { get; set; }

        public static Guess CurrentSuggest { get; set; }

        #endregion
        
        public static void GameEvents_GameInitialized(object sender, EventArgs eventArgs)
        {
            Play();
        }
        
        public static void GameEvents_GameFinished(object sender, EventArgs eventArgs)
        {
            Renderer.PrintSummary(Win);
        }
        
        public static void Initialize()
        {
            // Initialize Game
            // Print logo
            // Renderer.PrintGameLogo();
            try
            {
                Renderer.PrintGameLogo();
                CurrentProblem = new Problem(int.Parse(Console.ReadLine()));
                Matrix = new StringBuilder();
                NewSuggestion = new string('*', CurrentProblem.NumbersCount);
                Result = new List<int>();
                Pesho = new Human("Pesho");
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public static void Play()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 3);
            Console.Clear();
            Matrix.Append("| ");
            
            for (int i = 0; i < CurrentProblem.NumbersCount; i++)
            {
                Matrix.Append(NewSuggestion[i]);
                Matrix.Append(" | ");
            }
            
            if (Scores.TotalGuesses == 0)
            {
                Matrix.Append(" Bulls | Cows |");
            }
            
            if (CurrentSuggest != null)
            {
                Matrix.Append("   " + CurrentSuggest.GetBulls() + "   |   " + CurrentSuggest.GetCows() + "  |");
            }

            Matrix.AppendLine();
            
            for (int i = 1; i < (CurrentProblem.NumbersCount * 4) + 2 + 16; i++)
            {
                Matrix.Append('-');
            }
            
            Matrix.AppendLine();
            Console.WriteLine(Matrix.ToString());

            Console.WriteLine("Write suggestion: ");
            
            // Read and parse input
            string input = Console.ReadLine();
            NewSuggestion = input;
            
            try
            {
                // Read and check input
                // Get List<int>
                CurrentGuess = new Input(input, CurrentProblem.NumbersCount);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidDigitsCountException e)
            {
                Console.WriteLine(e.Message); 
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }


            Result = JudgeSystem.CheckResult(CurrentProblem.HiddenNumbers, CurrentGuess.NewGuess);

            // Create new guess
            CurrentSuggest = new Guess(CurrentGuess.NewGuess, Result.FindAll(x => (x == 0)).Count, Result.FindAll(x => (x == 1)).Count);
            
            // Save guess to Pesho`s list
            Pesho.MakeGuess(CurrentSuggest);
            
            Check = true;
            if (CurrentSuggest.Bulls != CurrentProblem.NumbersCount)
            {
                Check = false;
            }
            else
            {
                Win = true;
            }
        }
        
        public static void Main()
        {
            GameEvents start = new GameEvents();
            start.GameInitialized += new EventHandler(GameEvents_GameInitialized);
            
            GameEvents finish = new GameEvents();
            finish.GameFinished += new EventHandler(GameEvents_GameFinished);

            Initialize();
            
            do
            {
                // Play();
                start.EventOnGameInitialized();
            }
            while (!Check);
            
            // Renderer.PrintSummary(Win);
            // END GAME
            finish.EventOnGameFinished();
        }
    }
}