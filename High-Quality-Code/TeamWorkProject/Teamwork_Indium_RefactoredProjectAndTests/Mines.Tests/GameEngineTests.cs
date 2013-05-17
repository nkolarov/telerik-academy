// ********************************
// <copyright file="GameEngineTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class GameEngineTests
    {

        [TestMethod]
        public void TestInitiateGame()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("1{0}0 0{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameEngine.InitiateGame();
                   
                    string output = sw.ToString();
                    string expectedresult = "Welcome to \"Battle Field\" game.\r\nEnter battle field size between 1 and 10:   0\r\n  --\r\n0|5 \r\nPlease enter coordinates:   0\r\n  --\r\n0|X \r\nMines Blowed this round: 1\r\nCongratulations you won the game in 1 moves\r\n";
                    Assert.AreEqual(expectedresult.Length, output.Length);

                }
            }
        }
        
    }
}