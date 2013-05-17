// ********************************
// <copyright file="GameInputTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class GameInputTests
    {
        [TestMethod]
        public void TestUserInputOutsideOfField()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("8{0}9 9{0}3 3{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    GameInput.ManageUserInput(GameBoardGenerator.GameField);
                    string output = sw.ToString();
                    string expectedresult ="Welcome to \"Battle Field\" game. \nEnter battle field size between 1 and 10: Please enter coordinates: Outside of Field Range  Please enter coordinates: ";
                    Assert.AreEqual(expectedresult.Length, output.Length);

                }
            }
        }

        [TestMethod]
        public void TestUserInputIncorrectFormat()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("8{0}ssss{0}4 4{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    GameInput.ManageUserInput(GameBoardGenerator.GameField);
                    string output = sw.ToString();
                    string expectedresult = "Welcome to \"Battle Field\" game.\r\nEnter battle field size between 1 and 10: Please enter coordinates: Choose x and y coordinates, seperated by white space in correct format [Example:2 5]\r\nPlease enter coordinates: ";
                    Assert.AreEqual(expectedresult.Length, output.Length);

                }
            }
        }

        [TestMethod]
        public void TestUserInputIncorrectFormatLength2()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("8{0}ss{0}4 4{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    GameInput.ManageUserInput(GameBoardGenerator.GameField);
                    string output = sw.ToString();
                    string expectedresult = "Welcome to \"Battle Field\" game.\r\nEnter battle field size between 1 and 10: Please enter coordinates: Choose x and y coordinates, seperated by white space in correct format [Example:2 5]\r\nPlease enter coordinates: ";
                    Assert.AreEqual(expectedresult.Length, output.Length);

                }
            }
        }

        [TestMethod]
        public void TestUserInputCorrectCoordinates()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("10{0}5 5{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    GameInput.ManageUserInput(GameBoardGenerator.GameField);
                    Assert.IsTrue(GameInput.ColCoordinate==5 && GameInput.RowCoordinate==5);
                }
            }
        }


       
    }
}