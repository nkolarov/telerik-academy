using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public class Human : Player
    {
        public Human(string name) : base(name)
        {
        }

        public override void MakeGuess(Guess guess)
        {
            this.Guesses.Add(guess);
        }
    }
}