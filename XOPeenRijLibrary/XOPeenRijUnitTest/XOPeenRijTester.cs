using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XOPeenRijLibrary;

namespace XOPeenRijUnitTest
{
    [TestClass]
    public class XOPeenRijTester
    {
        private XOPeenRij game;

        [TestInitialize]
        public void setup()
        {
            game = new XOPeenRij();
        }
        [TestMethod]
        public void TestGameExists()
        {
            Assert.IsTrue(game.exists());
        }

        [TestMethod]
        public void TestRasterExists()
        {
            Assert.IsTrue(game.rasterExists());
        }

        [TestMethod]
        public void TestIsRasterInitializedWithZeros()
        {
            Assert.IsTrue(game.isRasterInitializedWithZeros());
        }

        [TestMethod]
        public void TestInsertTokenInRasterAndAssertThatRasterIsNotZero()
        {
            // Insert token in kolom 0 voor speler 1
            game.insertToken(0, 1);
            Assert.IsFalse(game.isRasterInitializedWithZeros());
        }

        [TestMethod]
        public void TestIsWon()
        {
            game.setWon(true);
            Assert.IsTrue(game.isWon());
        }

        [TestMethod]
        public void TestIsNotWon()
        {
            game.setWon(false);
            Assert.IsTrue(game.isNotWon());
        }

        [TestMethod]
        public void TestTrueIsWonAndFalseIsNotWon()
        {
            game.setWon(true);
            Assert.IsTrue(game.isWon());
            Assert.IsFalse(game.isNotWon());
        }
    }
}