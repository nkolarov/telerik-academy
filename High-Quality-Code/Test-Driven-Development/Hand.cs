// ********************************
// <copyright file="Hand.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a Hand.
    /// </summary>
    public class Hand : IHand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hand" /> class.
        /// </summary>
        /// <param name="cards">The cards.</param>
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        /// <summary>
        /// Gets the cards.
        /// </summary>
        /// <value>The cards.</value>
        public IList<ICard> Cards { get; private set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            int cardCount = this.Cards.Count;
            string cardSeparator = ", ";

            if (cardCount != 0)
            {
                for (int i = 0; i < cardCount; i++)
                {
                    result.Append(this.Cards[i].ToString());
                    if (i < cardCount - 1)
                    {
                        result.Append(cardSeparator);
                    }
                }
            }

            return result.ToString();
        }
    }
}