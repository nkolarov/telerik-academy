// ********************************
// <copyright file="CardTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test the <see cref="Card" /> class.
    /// </summary>
    [TestClass]
    public class CardTests
    {        
        #region ToString() Tests
        
        /// <summary>
        /// Tests the card ace spades to string.
        /// </summary>
        [TestMethod]
        public void TestCardAceSpadesToString()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card two clubs to string.
        /// </summary>
        [TestMethod]
        public void TestCardTwoClubsToString()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expected = "2♣";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card ten diamonds to string.
        /// </summary>
        [TestMethod]
        public void TestCardTenDiamondsToString()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "10♦";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card jack hearts to string.
        /// </summary>
        [TestMethod]
        public void TestCardJackHeartsToString()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Hearts);
            string expected = "J♥";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region CompareTo() Tests
        
        /// <summary>
        /// Tests the card compare of ace with jack.
        /// </summary>
        [TestMethod]
        public void TestCardCompareAceWithJack()
        {
            Card ace = new Card(CardFace.Ace, CardSuit.Hearts);
            Card jack = new Card(CardFace.Jack, CardSuit.Hearts);
        
            int expected = 3;
            int actual = ace.CompareTo(jack);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card compare two with jack.
        /// </summary>
        [TestMethod]
        public void TestCardCompareTwoWithJack()
        {
            Card jack = new Card(CardFace.Jack, CardSuit.Hearts);
            Card two = new Card(CardFace.Two, CardSuit.Hearts);
        
            int expected = -9;
            int actual = two.CompareTo(jack);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card compare ace hearts with ace hearts.
        /// </summary>
        [TestMethod]
        public void TestCardCompareAceHeartsWithAceHearts()
        {
            Card aceHearts = new Card(CardFace.Ace, CardSuit.Hearts);
            Card anotherAceHearts = new Card(CardFace.Ace, CardSuit.Hearts);
        
            int expected = 0;
            int actual = aceHearts.CompareTo(anotherAceHearts);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card compare ace hearts with ace clubs.
        /// </summary>
        [TestMethod]
        public void TestCardCompareAceHeartsWithAceClubs()
        {
            Card aceHearts = new Card(CardFace.Ace, CardSuit.Hearts);
            Card aceClubs = new Card(CardFace.Ace, CardSuit.Clubs);
        
            int expected = 2;
            int actual = aceHearts.CompareTo(aceClubs);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card compare jack clubs with jack hearts.
        /// </summary>
        [TestMethod]
        public void TestCardCompareJackClubsWithJackHearts()
        {
            Card jackClubs = new Card(CardFace.Jack, CardSuit.Clubs);
            Card jackHearts = new Card(CardFace.Jack, CardSuit.Hearts);
        
            int expected = -2;
            int actual = jackClubs.CompareTo(jackHearts);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card compare jack hearts with king clubs.
        /// </summary>
        [TestMethod]
        public void TestCardCompareJackHeartsWithKingClubs()
        {
            Card jackHearts = new Card(CardFace.Jack, CardSuit.Hearts);
            Card kingClubs = new Card(CardFace.King, CardSuit.Clubs);
        
            int expected = -2;
            int actual = jackHearts.CompareTo(kingClubs);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Tests the card compare jack hearts with king clubs.
        /// </summary>
        [TestMethod]
        public void TestCardCompareKingClubsWithJackHearts()
        {
            Card kingClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card jackHearts = new Card(CardFace.Jack, CardSuit.Hearts);
        
            int expected = 2;
            int actual = kingClubs.CompareTo(jackHearts);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}