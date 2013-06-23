using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public class Problem : IProblemGenerator
    {        
        #region Private Fields
        
        private int numbersCount;
        private List<int> hiddenNumbers;
        private Random randGenerator;
        
        #endregion
        
        #region Constructors
        
        public Problem(int numbersCount)
        {
            this.NumbersCount = numbersCount;
            this.HiddenNumbers = new List<int>();
            this.RandGenerator = new Random();
            this.GenerateNewProblem(numbersCount);
        }
        
        #endregion
        
        #region Properties
        
        public int NumbersCount
        {
            get
            {
                return this.numbersCount;
            }
            
            set
            { // Digits count has to be between 3 and 6 (http://en.wikipedia.org/wiki/Bulls_and_cows)
                if ((value > 2) && (value < 7))
                {
                    this.numbersCount = value;
                }
                else
                {
                    throw new InvalidRangeException<int>("Digits count has to be between 3 and 6!", 3, 6);
                }
            }
        }
        
        public List<int> HiddenNumbers
        {
            get
            {
                return this.hiddenNumbers;
            }
            
            set
            {
                this.hiddenNumbers = value;
            }
        }
        
        public Random RandGenerator
        {
            get
            {
                return this.randGenerator;
            }
            
            set
            {
                this.randGenerator = value;
            }
        }
        
        #endregion
        
        #region Methods
            
        public void GenerateNewProblem(int count)
        {
            // Clear Old problem
            this.HiddenNumbers.Clear();
                
            for (int i = 0; i < count; i++)
            {
                do
                {
                    bool isUnique = true;
                    
                    // this.HiddenNumbers.Add(this.RandGenerator.Next(1, 10));
                    int next = this.RandGenerator.Next(1, 10);
                    for (int j = 0; j < i; j++)
                    {
                        if (next == this.HiddenNumbers[j])
                        {
                            isUnique = false;
                            next = this.RandGenerator.Next(1, 10);
                            break; // Not unique Leave for
                        }
                    }
                        
                    if (isUnique)
                    { // Unique Leave do{}while() 
                        this.HiddenNumbers.Add(next);
                        break;
                    }
                }
                while (true);
            }
        }

        #endregion
    }
}