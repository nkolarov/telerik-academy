using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Mines.Tests
{
    [TestClass]
    public class PrintGameBoardTests
    {
        [TestMethod]
        public void TestCorrectPrintedFieldSizeWithSix()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("6{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    PrintGameBoard.PrintField(GameBoardGenerator.GameField);
                    string result = sw.ToString();
                    Assert.IsTrue(result.Length == 202);//size of printed array without the string length of the GetBoardSize console writings
                }
            }
        }

        [TestMethod]
        public void TestCorrectPrintedFieldSizeWithOne()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("1{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    GameBoardGenerator.GetBoardSize();
                    PrintGameBoard.PrintField(GameBoardGenerator.GameField);
                    string result = sw.ToString();
                    Assert.IsTrue(result.Length ==92);
                }
            }
        }
    }
}
