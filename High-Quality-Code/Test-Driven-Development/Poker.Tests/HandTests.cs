// ********************************
// <copyright file="HandTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test the <see cref="Hand" /> class.
    /// </summary>
    [TestClass]
    public class HandTests
    {
        /// <summary>
        /// Tests a hand with five cards to string.
        /// </summary>
        [TestMethod]
        public void TestHandFiveCardsToString()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            Hand hand = new Hand(cards);

            string expected = "J♥, 10♦, 2♣, A♠, K♥";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests an empty hand to string.
        /// </summary>
        [TestMethod]
        public void TestHandEmptyToString()
        {
            IList<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);

            string expected = string.Empty;
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}