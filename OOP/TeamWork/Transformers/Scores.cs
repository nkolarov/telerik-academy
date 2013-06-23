using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public struct Scores
    {
        /// <summary>
        /// Used to store the count of all guesses, cows and bulls during game.
        /// </summary>        
        #region Constructor
        
        static Scores() 
        {
            TotalGuesses = 0;
            TotalBulls = 0;
            TotalCows = 0;
        }
        
        #endregion

        #region Properties

        public static int TotalCows { get; set; }
        
        public static int TotalBulls { get; set; }
        
        public static int TotalGuesses { get; set; }

        #endregion
    }
}