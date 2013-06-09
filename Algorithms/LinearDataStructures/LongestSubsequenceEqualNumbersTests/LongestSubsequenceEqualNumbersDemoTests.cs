// ********************************
// <copyright file="LongestSubsequenceEqualNumbersDemoTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace LongestSubsequenceEqualNumbersTests
{
    using System;
    using System.Collections.Generic;
    using LongestSubsequenceEqualNumbers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests LongestSubsequenceEqualNumbersDemo behavior.
    /// </summary>
    [TestClass]
    public class LongestSubsequenceEqualNumbersDemoTests
    {
        /// <summary>
        /// Tests with null input list.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullInputList()
        {
            LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(null);
        }

        /// <summary>
        /// Tests with empty input list.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyInputList()
        {
            List<int> sequence = new List<int>();
            LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
        }

        /// <summary>
        /// Tests with input list containing only one number.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OnlyOneNumber()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
        }

        /// <summary>
        /// Tests with input list containing only different numbers.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void DifferentNumbers()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(-1);
            sequence.Add(0);
            sequence.Add(5);
            sequence.Add(8);
            LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
        }

        /// <summary>
        /// Tests with input list containing one sequence.
        /// </summary>
        [TestMethod]
        public void OneSequence()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(1);
            var result = LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
            int expectedCount = 3;
            var actualCount = result.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Tests with input list containing two sequences. Second is longer.
        /// </summary>
        [TestMethod]
        public void TwoSequencesSecondLongest()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(2);
            var result = LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
            int expectedCount = 4;
            var actualCount = result.Count;
            int expectedNumber = 2;
            int actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        /// <summary>
        /// Tests with input list containing two sequences. First is longer.
        /// </summary>
        [TestMethod]
        public void TwoSequencesFirstLongest()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(2);
            var result = LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
            int expectedCount = 4;
            var actualCount = result.Count;
            int expectedNumber = 1;
            int actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        /// <summary>
        /// Tests with input list containing three sequences. First is longest.
        /// </summary>
        [TestMethod]
        public void ThreeSequencesFirstLongest()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(3);
            sequence.Add(3);
            var result = LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
            int expectedCount = 3;
            var actualCount = result.Count;
            int expectedNumber = 1;
            int actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        /// <summary>
        /// Tests with input list containing three sequences. Second is longest.
        /// </summary>
        [TestMethod]
        public void ThreeSequencesSecondLongest()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(3);
            sequence.Add(3);
            var result = LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
            int expectedCount = 3;
            var actualCount = result.Count;
            int expectedNumber = 2;
            int actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        /// <summary>
        /// Tests with input list containing three sequences. Third is longest.
        /// </summary>
        [TestMethod]
        public void ThreeSequencesLastLongest()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(3);
            sequence.Add(3);
            sequence.Add(3);
            var result = LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
            int expectedCount = 3;
            var actualCount = result.Count;
            int expectedNumber = 3;
            int actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        /// <summary>
        /// Tests with input list containing two equal sequences.
        /// </summary>
        [TestMethod]
        public void TwoEqualSequences()
        {
            // Return the last one with the given length.  Not specified by condition.
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(2);
            var result = LongestSubsequenceEqualNumbersDemo.GetLongestSubsequenceWithEqualNumbers(sequence);
            int expectedCount = 3;
            var actualCount = result.Count;
            int expectedNumber = 2;
            int actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }
    }
}