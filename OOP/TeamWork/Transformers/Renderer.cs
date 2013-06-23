using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public static class Renderer
    {        
        #region Methods
        
        public static void DisplayMessage(OutputMessage message)
        {
            Console.WriteLine(message.ToDescription());
        }
        
        public static void DrawCowOrBull(CowOrBull animal)
        {
            Console.WriteLine(animal.ToDescription());
        }
        
        public static void PrintGameLogo()
        {
            Console.WriteLine(new string('=', 51));
            Renderer.DrawCowOrBull(CowOrBull.Bull);
            Renderer.DrawCowOrBull(CowOrBull.Cow);
            Renderer.DisplayMessage(OutputMessage.GameOn);
            Console.WriteLine(new string('=', 51));
            Console.WriteLine();
            Renderer.DisplayMessage(OutputMessage.ChooseLevel);
        }
        
        public static void PrintSummary(bool win)
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 51));
            Console.WriteLine(new string('=', 51));
            
            if (win)
            {
                Renderer.DisplayMessage(OutputMessage.YouWin);
            }
            else
            {
                Renderer.DisplayMessage(OutputMessage.YouLoose);
            }
            
            Console.WriteLine("Summary:");
            Console.WriteLine("Total Guesses: " + Scores.TotalGuesses);
            Console.WriteLine("Total Bulls: " + Scores.TotalBulls);
            Console.WriteLine("Total Cows: " + Scores.TotalCows);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        #endregion
    }
}