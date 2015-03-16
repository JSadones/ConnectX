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
            // Insert token for column 0 for player 1
            game.insertToken(0, 1);
            Assert.IsFalse(game.isRasterInitializedWithZeros());
        }

        [TestMethod]
        public void TestInsertTokenInRasterInFullColumn()
        {
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(0, 1);
            Assert.IsFalse(game.hasNotCrashed());
        }
        [TestMethod]
        public void TestIsRasterFullWhenRasterIsFull()
        {
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(1, 1);
            game.insertToken(1, 2);
            game.insertToken(1, 1);
            game.insertToken(1, 2);
            game.insertToken(1, 1);
            game.insertToken(1, 2);
            game.insertToken(2, 1);
            game.insertToken(2, 2);
            game.insertToken(2, 1);
            game.insertToken(2, 2);
            game.insertToken(2, 1);
            game.insertToken(2, 2);
            game.insertToken(3, 1);
            game.insertToken(3, 2);
            game.insertToken(3, 1);
            game.insertToken(3, 2);
            game.insertToken(3, 1);
            game.insertToken(3, 2);
            game.insertToken(4, 1);
            game.insertToken(4, 2);
            game.insertToken(4, 1);
            game.insertToken(4, 2);
            game.insertToken(4, 1);
            game.insertToken(4, 2);
            game.insertToken(5, 1);
            game.insertToken(5, 2);
            game.insertToken(5, 1);
            game.insertToken(5, 2);
            game.insertToken(5, 1);
            game.insertToken(5, 2);
            game.insertToken(6, 1);
            game.insertToken(6, 2);
            game.insertToken(6, 1);
            game.insertToken(6, 2);
            game.insertToken(6, 1);
            game.insertToken(6, 2);

            Assert.IsTrue(game.rasterIsFull());
        }
        [TestMethod]
        public void TestIsRasterFullWhenRasterIsNotFull()
        {
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(0, 1);
            game.insertToken(0, 2);
            game.insertToken(1, 1);
            game.insertToken(1, 2);
            game.insertToken(1, 1);
            game.insertToken(1, 2);
            game.insertToken(1, 1);
            game.insertToken(1, 2);
            game.insertToken(2, 1);
            game.insertToken(2, 2);
            game.insertToken(2, 1);
            game.insertToken(2, 2);
            game.insertToken(2, 1);
            game.insertToken(2, 2);
            game.insertToken(3, 1);
            game.insertToken(3, 2);
            game.insertToken(3, 1);
            game.insertToken(3, 2);
            game.insertToken(3, 1);
            game.insertToken(3, 2);
            game.insertToken(4, 1);
            game.insertToken(4, 2);
            game.insertToken(4, 1);
            game.insertToken(4, 2);
            game.insertToken(4, 1);
            game.insertToken(4, 2);
            game.insertToken(5, 1);
            game.insertToken(5, 2);
            game.insertToken(5, 1);
            game.insertToken(5, 2);
            game.insertToken(5, 1);
            game.insertToken(5, 2);
            game.insertToken(6, 1);
            game.insertToken(6, 2);
            game.insertToken(6, 1);
            game.insertToken(6, 2);
            game.insertToken(6, 2);

            Assert.IsFalse(game.rasterIsFull());
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

        [TestMethod]
        public void TestGivenNonCompletedGameIfIsNotWonYet()
        {
            game.insertToken(0, 1);
            game.insertToken(0, 1);
            game.insertToken(0, 1);
            Assert.IsFalse(game.isWon());
        }
        [TestMethod]
        public void TestGivenVerticalCompletedGameIfIsWon()
        {
            game.insertToken(0, 1);
            game.insertToken(0, 1);
            game.insertToken(0, 1);
            game.insertToken(0, 1);
            Assert.IsTrue(game.isWon());
        }
    }
}