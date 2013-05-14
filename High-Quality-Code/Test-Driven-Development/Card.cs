// ********************************
// <copyright file="Card.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker
{
    using System;

    /// <summary>
    /// Represents a card.
    /// </summary>
    public class Card : ICard, IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Card" /> class.
        /// </summary>
        /// <param name="face">The face.</param>
        /// <param name="suit">The suit.</param>
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        /// <summary>
        /// Gets the face.
        /// </summary>
        /// <value>The face.</value>
        public CardFace Face { get; private set; }

        /// <summary>
        /// Gets the suit.
        /// </summary>
        /// <value>The suit.</value>
        public CardSuit Suit { get; private set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            string cardSuit = this.GetCardSuitAsString();
            string cardFace = this.GetCardFaceAsString();
            string result = cardFace + cardSuit;
            return result;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and
        /// returns an integer that indicates whether the current instance precedes, follows,
        /// or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="otherCard">An object of type Card to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared.
        /// The return value has these meanings: Value Meaning Less than zero This instance
        /// precedes <paramref name="otherCard" /> in the sort order. Zero This instance occurs
        /// in the same position in the sort order as <paramref name="otherCard" />. Greater than
        /// zero This instance follows <paramref name="otherCard" /> in the sort order.
        /// </returns>
        public int CompareTo(object otherCard)
        {
            Card inputCard = otherCard as Card;

            if (this.Face != inputCard.Face)
            {
                return (int)this.Face - (int)inputCard.Face;
            }

            if (this.Suit != inputCard.Suit)
            {
                return (int)this.Suit - (int)inputCard.Suit;
            }

            return 0;
        }

        /// <summary>
        /// Gets the card face as string.
        /// </summary>
        /// <returns>The card face as string.</returns>
        private string GetCardFaceAsString()
        {
            string cardFace = string.Empty;
            int cardFaceAsInt = (int)this.Face;
            if (cardFaceAsInt <= 10)
            {
                cardFace = cardFaceAsInt.ToString();
            }
            else
            {
                cardFace = this.Face.ToString().Substring(0, 1);
            }

            return cardFace;
        }

        /// <summary>
        /// Gets the card suit as string.
        /// </summary>
        /// <returns>The card suit as string.</returns>
        private string GetCardSuitAsString()
        {
            string cardSuit = string.Empty;
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    cardSuit = "♣";
                    break;
                case CardSuit.Diamonds:
                    cardSuit = "♦";
                    break;
                case CardSuit.Hearts:
                    cardSuit = "♥";
                    break;
                case CardSuit.Spades:
                    cardSuit = "♠";
                    break;
                default:
                    throw new ArgumentException("Unknown suit: " + this.Suit);
            }

            return cardSuit;
        }
    }
}