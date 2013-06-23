using System;
using System.Collections.Generic;

namespace Transformers
{
    public interface IProblemGenerator
    {
        int NumbersCount { get; set; }

        List<int> HiddenNumbers { get; set; }

        Random RandGenerator { get; set; }

        void GenerateNewProblem(int numbersCount);
    }
}