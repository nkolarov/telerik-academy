// ********************************
// <copyright file="GameFieldGeneratorTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class GameFieldGeneratorTests
    {
        //TODO add test for checking input and correct values of fields after inpuy
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
            "The game field is not yet created")]
        public void TestIfGameFieldIsEmptyWhenNotCalled()
        {
            Assert.IsTrue(GameBoardGenerator.GameField.Length == 0);
        }

        [TestMethod]
        public void TestIfMineNumberIsZeroWhenNotCalled()
        {
            Assert.AreEqual(GameBoardGenerator.MinesNumber, 0);
        }

        [TestMethod]
        public void TestIfCorrectNumbersOfMinesAreCreated()
        {
            PrivateType privateType = new PrivateType(typeof(GameBoardGenerator));
            var fieldSize = 1;
            int startRandomRange = ((15 * fieldSize * fieldSize) / 100) + 1;
            int endRandomRange = ((30 * fieldSize * fieldSize) / 100) + 1;
            int randomCheck = (int)privateType.InvokeStatic("RandomGenerator", startRandomRange, endRandomRange);
            Assert.IsTrue(randomCheck >= 1);
        }

        [TestMethod]
        public void TestUserInputCorrectFieldSize()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("5{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    Assert.AreEqual(GameBoardGenerator.GameField.Length, 25);
                }
            }
        }

        [TestMethod]
        public void TestUserInputMinesNumberWithTen()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("10{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    Assert.IsTrue(GameBoardGenerator.MinesNumber >= 15 && GameBoardGenerator.MinesNumber <= 31);
                }
            }
        }

        [TestMethod]
        public void TestUserInputMinesNumberWithOne()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("1{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    Assert.IsTrue(GameBoardGenerator.MinesNumber >= 1);
                }
            }
        }

        [TestMethod]
        public void TestUserInputWithOutOfRangeParameters()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("11{0}2{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    string expectedResult = "Welcome to \"Battle Field\" game.\r\nEnter battle field size between 1 and 10: Size must be between 1 and 10 \nInput new size:";
                    Assert.AreEqual<string>(expectedResult, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void TestUserInputWithOutOfStringParameter()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("ssssd{0}2{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    string expectedResult = "Welcome to \"Battle Field\" game.\r\nEnter battle field size between 1 and 10: Size must be between 1 and 10 \nInput new size:";
                    Assert.AreEqual<string>(expectedResult, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void TestUserInputWithDoubleParameters()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("5.5{0}2{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    string expectedResult = "Welcome to \"Battle Field\" game.\r\nEnter battle field size between 1 and 10: Size must be between 1 and 10 \nInput new size:";
                    Assert.AreEqual<string>(expectedResult, sw.ToString());
                }
            }
        }
    }
}