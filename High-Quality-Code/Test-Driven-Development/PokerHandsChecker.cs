// ********************************
// <copyright file="PokerHandsChecker.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Stores functionality for checking hands.
    /// </summary>
    public class PokerHandsChecker : IPokerHandsChecker
    {
        /// <summary>
        /// Determines whether [is valid hand] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if valid.</returns>
        public bool IsValidHand(IHand hand)
        {
            IList<ICard> cards = hand.Cards;
            if (cards.Count != 5 || this.HasRepeatedCards(cards))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether [is straight flush] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is straight flush.</returns>
        public bool IsStraightFlush(IHand hand)
        {
            if (this.IsValidHand(hand) && this.HaveSameSuit(hand))
            {
                IList<ICard> orderedCards = this.OrderHand(hand).Cards;
                for (int i = 0; i < orderedCards.Count - 1; i++)
                {
                    if (orderedCards[i].CompareTo(orderedCards[i + 1]) != -1)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether [is four of a kind] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is four of a kind</returns>
        public bool IsFourOfAKind(IHand hand)
        {
            if (this.IsValidHand(hand))
            {
                IHand orderedHand = this.OrderHand(hand);
                IList<ICard> orderedCards = orderedHand.Cards;
                ICard currentCard = null;
                int count = 0;

                for (int i = 0; i < orderedCards.Count; i++)
                {
                    if (currentCard == null)
                    {
                        currentCard = orderedCards[i];
                        count++;
                    }
                    else if (currentCard.Face == orderedCards[i].Face)
                    {
                        count++;
                        if (count == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        currentCard = orderedCards[i];
                        count = 0;
                    }
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Determines whether [is full house] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is full house.</returns>
        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the specified hand is flush.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is flush.</returns>
        public bool IsFlush(IHand hand)
        {
            if (this.IsValidHand(hand) && this.HaveSameSuit(hand) && !this.IsStraightFlush(hand))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified hand is straight.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is straight.</returns>
        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [is three of A kind] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is three of a kind.</returns>
        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [is two pair] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is two pair.</returns>
        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [is one pair] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is one pair.</returns>
        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [is high card] [the specified hand].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if is high card.</returns>
        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Compares two hands.
        /// </summary>
        /// <param name="firstHand">The first hand.</param>
        /// <param name="secondHand">The second hand.</param>
        /// <returns>Result of comparison.</returns>
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [has repeated cards] [the specified cards].
        /// </summary>
        /// <param name="cards">The cards.</param>
        /// <returns>True if the hand has repeated cards.</returns>
        private bool HasRepeatedCards(IList<ICard> cards)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                ICard current = cards[i];
                
                for (int j = i + 1; j < cards.Count; j++)
                {
                    ICard next = cards[j];
                    if (current.CompareTo(next) == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the hand consist of cards with same suit.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>True if the hand consist of cards with same suit.</returns>
        private bool HaveSameSuit(IHand hand)
        {
            if (this.IsValidHand(hand))
            {
                IList<ICard> cards = hand.Cards;

                for (int i = 0; i < cards.Count - 1; i++)
                {
                    if (cards[i].Suit != cards[i + 1].Suit)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Orders the hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>A new ordered hand.</returns>
        private IHand OrderHand(IHand hand)
        {
            IList<ICard> orderedCards = new List<ICard>();
            IList<ICard> cards = hand.Cards.ToList();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var weakestCard = cards.Min();
                orderedCards.Add(weakestCard);
                cards.Remove(weakestCard);
            }

            IHand orderedHand = new Hand(orderedCards);
            return orderedHand;
        }
    }
}