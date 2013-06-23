using System;
using System.ComponentModel;

namespace Transformers
{
    /// <summary>
    /// Types of Answers
    /// </summary>
    public enum CowOrBull
    {
        /// <summary>
        /// Represent Bull: Right number at right position
        /// </summary>
        [Description("         (___)\n         (o o)\n  /-------\\ /\n / | BULL||O\n*  ||,---||\n   ^^    ^^")]
        Bull = 0,

        /// <summary>
        /// Represents Cow: Right number at wrong position
        /// </summary>
        [Description("         \\__/\n         (uu)\n  /-------\\/\n / | COW ||\n*  ||----||\n   ~~    ~~")]
        Cow = 1
    }
}