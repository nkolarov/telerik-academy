// ********************************
// <copyright file="PokerHandsCheckerTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test the <see cref="PokerHandsChecker" /> class.
    /// </summary>
    [TestClass]
    public class PokerHandsCheckerTests
    {        
        #region IsValid() Tests
        
        /// <summary>
        /// Tests if hand is valid with five different cards.
        /// </summary>
        [TestMethod]
        public void TestIsValidHandFiveDifferentCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = true;
            bool actual = checker.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests if hand is valid with five different cards.
        /// </summary>
        [TestMethod]
        public void TestIsValidEmptyHand()
        {
            IList<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is valid hand two non consecutive same cards.
        /// </summary>
        [TestMethod]
        public void TestIsValidHandTwoConsecutiveSameCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is valid hand two non consecutive same cards.
        /// </summary>
        [TestMethod]
        public void TestIsValidHandTwoNonConsecutiveSameCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests if hand is valid with only two different cards.
        /// </summary>
        [TestMethod]
        public void TestIsValidHandOnlyTwoDifferentCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is valid hand only two non consecutive same cards.
        /// </summary>
        [TestMethod]
        public void TestIsValidHandOnlyTwoSameCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is valid hand same cards different suit.
        /// </summary>
        [TestMethod]
        public void TestIsValidHandSameCardsDifferentSuit()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = true;
            bool actual = checker.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
        }

        #endregion
        
        #region IsFlush() Tests
        
        /// <summary>
        /// Tests the is flush five different cards.
        /// </summary>
        [TestMethod]
        public void TestIsFlushFiveDifferentCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is flush with five same suit cards.
        /// </summary>
        [TestMethod]
        public void TestIsFlushFiveSameSuitCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = true;
            bool actual = checker.IsFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is flush with an empty hand.
        /// </summary>
        [TestMethod]
        public void TestIsFlushEmtyHand()
        {
            IList<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is flush with repeating cards.
        /// </summary>
        [TestMethod]
        public void TestIsFlushRepeatingCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region ISFourOfAKind Tests
        
        /// <summary>
        /// Tests the IS four of a kind with four same cards.
        /// </summary>
        [TestMethod]
        public void TestISFourOfAKindSameCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = true;
            bool actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the IS four of a kind with empty hand.
        /// </summary>
        [TestMethod]
        public void TestISFourOfAKindEmptyHand()
        {
            IList<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the IS four of a kind with five same cards.
        /// </summary>
        [TestMethod]
        public void TestISFourOfAKindFiveSameCard()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the IS four of a kind with different cards.
        /// </summary>
        [TestMethod]
        public void TestISFourOfAKindDifferentCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the IS four of A kind seven cards.
        /// </summary>
        [TestMethod]
        public void TestISFourOfAKindSevenCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region IsStraightFlush() Tests
        
        /// <summary>
        /// Tests the is flush five different cards.
        /// </summary>
        [TestMethod]
        public void TestIsStraightFlushFiveDifferentCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is flush with five same suit cards.
        /// </summary>
        [TestMethod]
        public void TestIsStraightFlushFiveSameSuitCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is flush with an empty hand.
        /// </summary>
        [TestMethod]
        public void TestIsStraightFlushEmtyHand()
        {
            IList<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is flush with repeating cards.
        /// </summary>
        [TestMethod]
        public void TestIsStraightFlushRepeatingCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is flush with repeating cards.
        /// </summary>
        [TestMethod]
        public void TestIsStraightFlushCorrect()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = true;
            bool actual = checker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the is flush with repeating cards.
        /// </summary>
        [TestMethod]
        public void TestIsStraightFlushNonConsecutive()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            
            bool expected = false;
            bool actual = checker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}