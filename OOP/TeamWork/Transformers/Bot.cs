using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public class Bot : Player
    {
        public Bot(string name) : base(name)
        {
        }
        
        public override decimal CalcScore(int totalGuesses, int totalCows, int totalBulls)
        {
            // Bots cannot "score"
            return 0;
        }

        public override void MakeGuess(Guess guess)
        {
            // Implement bot guesses
        }
    }
}