using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public class Input
    {        
        #region private Fields
        
        private string strNewGuess;
        private List<int> newGuess;
        
        #endregion

        #region Constructors
        
        public Input(string guess, int numbersCount)
        {
            this.strNewGuess = guess;
            if (CheckInput(guess))
            {
                this.newGuess = ConvertInput(guess, numbersCount);
            }
            else
            {
                throw new InvalidRangeException<int>("Numbers must be unique", 0, 9);
            }
        }
        
        #endregion
        
        #region Properties  
        
        public List<int> NewGuess
        {
            get
            {
                return this.newGuess;
            }
            
            set
            {
                this.newGuess = value;
            }
        }
        
        public string StrNewGuess
        {
            get
            {
                return this.strNewGuess;
            }
            
            set
            {
                this.strNewGuess = value;
            }
        }
        
        #endregion
        
        #region Methods
        
        public static List<int> ConvertInput(string strNewGuess, int numbersCount)
        {
            if (CheckInput(strNewGuess))
            {
                List<int> list = new List<int>();
                if (strNewGuess.Count() == numbersCount)
                { // How to evoke? List<int> guess = Input.ConvertInput("1234", Problem.NumbersCount);
                    for (int i = 0; i < numbersCount; i++)
                    {
                        if ((strNewGuess[i] > 47) && (strNewGuess[i] < 58))
                        {
                            list.Add((int)(strNewGuess[i] - 48));
                        }
                        else
                        { // Exception if the guess contains other symbols than digits
                            throw new ArgumentOutOfRangeException("The guess is not valid!"); 
                        }
                    }
                }
                else
                { // Exception will be used
                    throw new InvalidDigitsCountException("Digits count is different than expected!", numbersCount);
                }
            
                return list;
            }
            else
            {
                throw new InvalidRangeException<int>("Numbers must be unique", 0, 9);
            }
        }
        
        public static bool CheckInput(string guess)
        { // Check for unique input numbers
            for (int i = 0; i < guess.Length; i++)
            {
                int curr = int.Parse(guess[i].ToString());
                
                for (int j = i + 1; j < guess.Length; j++)
                {
                    if (int.Parse(guess[j].ToString()) == curr)
                    {
                        return false;
                    }
                }
            }
        
            return true;
        }

        #endregion
    }
}