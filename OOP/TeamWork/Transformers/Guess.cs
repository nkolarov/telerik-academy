using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public class Guess : IGuess
    {         
        #region Fields

        private List<int> guessNumbers;
        
        #endregion
        
        #region Constructor
        
        public Guess(List<int> guess, int bull, int cow)
        {
            this.GuessNumbers = new List<int>(guess);
            this.Bulls = bull;
            this.Cows = cow;
            this.AppendTotalScores();
        }
        
        #endregion
        
        #region Properties
        
        public int Cows { get;  private set; }
        
        public int Bulls { get;  private set; }
            
        public List<int> GuessNumbers
        {
            get
            {
                return this.guessNumbers;
            }
                
            set
            {
                this.guessNumbers = value;
            }
        }
        
        #endregion
        
        #region Methods
            
        public int GetBulls()
        {
            return this.Bulls;
        }
            
        public int GetCows()
        {
            return this.Cows;
        }
            
        public void AppendTotalScores()
        {
            Scores.TotalBulls += this.GetBulls();
            Scores.TotalCows += this.GetCows();
            Scores.TotalGuesses += 1;
        }

        #endregion
    }
}