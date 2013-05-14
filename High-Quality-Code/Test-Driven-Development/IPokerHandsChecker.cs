// ********************************
// <copyright file="IPokerHandsChecker.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker
{
    /// <summary>
    /// Interface for checking poker hands as defined in http://en.wikipedia.org/wiki/List_of_poker_hands.
    /// </summary>
    public interface IPokerHandsChecker
    {
        /// <summary>
        /// Determines whether [is valid hand] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is valid hand.</returns>
        bool IsValidHand(IHand hand);

        /// <summary>
        /// Determines whether [is straight flush] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is straight flush.</returns>
        bool IsStraightFlush(IHand hand);

        /// <summary>
        /// Determines whether [is four of a kind] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is four of a kind</returns>
        bool IsFourOfAKind(IHand hand);

        /// <summary>
        /// Determines whether [is full house] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is full house</returns>
        bool IsFullHouse(IHand hand);

        /// <summary>
        /// Determines whether the specified hand is flush.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is flush.</returns>
        bool IsFlush(IHand hand);

        /// <summary>
        /// Determines whether the specified hand is straight.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is straight.</returns>
        bool IsStraight(IHand hand);

        /// <summary>
        /// Determines whether [is three of a kind] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is three of a kind.</returns>
        bool IsThreeOfAKind(IHand hand);

        /// <summary>
        /// Determines whether [is two pair] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is is two pair.</returns>
        bool IsTwoPair(IHand hand);

        /// <summary>
        /// Determines whether [is one pair] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is one pair.</returns>
        bool IsOnePair(IHand hand);

        /// <summary>
        /// Determines whether [is high card] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is high card.</returns>
        bool IsHighCard(IHand hand);

        /// <summary>
        /// Compares the hands.
        /// </summary>
        /// <param name="firstHand">The first hand.</param>
        /// <param name="secondHand">The second hand.</param>
        /// <returns>Result from comparison.</returns>
        int CompareHands(IHand firstHand, IHand secondHand);
    }
}
