// ********************************
// <copyright file="MinesExplosionTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class MinesExplosionTests
    {
        [TestMethod]
        public void TestFieldExplosion()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("1{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    int result=MinesExplosion.CheckForExplosion(GameBoardGenerator.GameField, 0, 0);
                    Assert.IsTrue(result > 0);
                }
            }
        }

        [TestMethod]
        public void TestBigFieldExplosion()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("10{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    int result = MinesExplosion.CheckForExplosion(GameBoardGenerator.GameField, 5,5);
                    Assert.IsTrue(result >= 2);
                }
            }
        }

    }
}