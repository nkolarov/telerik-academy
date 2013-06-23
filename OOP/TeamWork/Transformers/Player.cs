using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public abstract class Player : IPlayer
    {        
        #region Private Fields
        
        private string playerName;
        private decimal score;

        #endregion

        #region Constructors
        
        public Player(string name)
        {
            this.PlayerName = name;
            this.Score = 0m;
            this.Guesses = new List<Guess>();
        }

        #endregion

        #region Properties
        
        public List<Guess> Guesses { get; set; }
        
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            
            set
            {
                this.playerName = value;
            }
        }
        
        public decimal Score
        {
            get
            {
                return this.score;
            }
            
            set
            {
                this.score = value;
            }
        }
        
        #endregion

        #region Methods
        
        public virtual decimal CalcScore(int totalGuesses, int totalCows, int totalBulls)
        {
            decimal score;
            score = ((decimal)totalCows * 5m + (decimal)totalBulls * 10m) / (decimal)totalGuesses;
            return score;
        }
        
        public abstract void MakeGuess(Guess guess);

        #endregion
    }
}