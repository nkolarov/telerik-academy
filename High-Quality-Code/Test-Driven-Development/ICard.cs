// ********************************
// <copyright file="ICard.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker
{
    /// <summary>
    /// Represents an ICard interface.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Gets the face.
        /// </summary>
        /// <value>The face.</value>
        CardFace Face { get; }

        /// <summary>
        /// Gets the suit.
        /// </summary>
        /// <value>The suit.</value>
        CardSuit Suit { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        string ToString();

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
        int CompareTo(object otherCard);
    }
}