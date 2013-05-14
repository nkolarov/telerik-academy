// ********************************
// <copyright file="PokerExample.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstrates Test Driven Development.
    /// </summary>
    public class PokerExample
    {
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsValidHand(hand));

            // Console.WriteLine(checker.IsOnePair(hand));
            // Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}