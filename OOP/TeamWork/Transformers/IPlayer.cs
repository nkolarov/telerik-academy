using System;
using System.Collections.Generic;

namespace Transformers
{
    public interface IPlayer
    {
        string PlayerName { get; set; }

        decimal Score { get; set; }

        decimal CalcScore(int totalGuesses, int totalCows, int totalBulls);

        void MakeGuess(Guess guess);
    }
}