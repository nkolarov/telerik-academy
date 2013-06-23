using System;
using System.Collections.Generic;

namespace Transformers
{
    public interface IGuess
    {
        List<int> GuessNumbers { get; }

        int GetBulls();

        int GetCows();
        
        void AppendTotalScores();
    }
}