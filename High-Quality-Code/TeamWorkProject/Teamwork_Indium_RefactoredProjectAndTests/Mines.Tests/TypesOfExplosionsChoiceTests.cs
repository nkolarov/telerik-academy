// ********************************
// <copyright file="TypesOfExplosionsChoiceTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Mines.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TypesOfExplosionsChoiceTests
    {
        [TestMethod]
        public void TestMinesExplosionTwo()
        {
            int[,] testArray = new int[5, 5];
            testArray[2, 2] = 2;
            int[,] returnedExplosion = TypesOfExplosionsChoice.GetExplosion(testArray, 2, 2);
            int counterMinesTwo = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (returnedExplosion[i, j] > 0)
                    {
                        counterMinesTwo++;
                    }
                }
            }
            Assert.IsTrue(counterMinesTwo ==9);
        }

        [TestMethod]
        public void TestMinesExplosionOne()
        {
            int[,] testArray = new int[5, 5];
            testArray[2, 2] = 1;
            int[,] returnedExplosion = TypesOfExplosionsChoice.GetExplosion(testArray, 2, 2);
            int counterMinesOne = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (returnedExplosion[i, j] > 0)
                    {
                        counterMinesOne++;
                    }
                }
            }
            Assert.IsTrue(counterMinesOne ==5);
        }

        [TestMethod]
        public void TestMinesExplosionThree()
        {
            int[,] testArray = new int[5, 5];
            testArray[2, 2] = 3;
            int[,] returnedExplosion = TypesOfExplosionsChoice.GetExplosion(testArray, 2, 2);
            int counterMinesThree = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (returnedExplosion[i, j] > 0)
                    {
                        counterMinesThree++;
                    }
                }
            }
            Assert.IsTrue(counterMinesThree ==13);
        }

        [TestMethod]
        public void TestMinesExplosionFour()
        {
            int[,] testArray = new int[5, 5];
            testArray[2, 2] = 4;
            int[,] returnedExplosion = TypesOfExplosionsChoice.GetExplosion(testArray, 2, 2);
            int counterMinesFour = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (returnedExplosion[i, j] > 0)
                    {
                        counterMinesFour++;
                    }
                }
            }
            Assert.IsTrue(counterMinesFour ==21);
        }

        [TestMethod]
        public void TestMinesExplosionFive()
        {
            int[,] testArray = new int[5, 5];
            testArray[2, 2] = 5;
            int[,] returnedExplosion = TypesOfExplosionsChoice.GetExplosion(testArray, 2, 2);
            int counterMinesFive = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (returnedExplosion[i, j] > 0)
                    {
                        counterMinesFive++;
                    }
                }
            }
            Assert.IsTrue(counterMinesFive == 25);
        }

       
    }
}
