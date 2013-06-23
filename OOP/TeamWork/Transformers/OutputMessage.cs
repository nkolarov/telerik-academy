using System;
using System.ComponentModel;

namespace Transformers
{
    /// <summary>
    /// Represents Output 
    /// </summary>
    public enum OutputMessage
    {
        /// <summary>
        /// Represents EndMessage for Win.
        /// </summary>
        [Description("Congratulations! You Win!")]
        YouWin,

        /// <summary>
        /// Represents EndMessage for loose.
        /// </summary>
        [Description("Congratulations! You Loose!")]
        YouLoose,

        /// <summary>
        /// Represents Hello Message
        /// </summary>
        [Description("Cows & Bulls C# Console game by Transformers 2013")]
        GameOn,

        /// <summary>
        /// Represents NextGuess Message
        /// </summary>
        [Description("Write suggestion:")]
        NextGuess,

        /// <summary>
        /// Represents Choose Level Message
        /// </summary>
        [Description("How many digits have the number (betwen 3 and 6):")]
        ChooseLevel
    }
}