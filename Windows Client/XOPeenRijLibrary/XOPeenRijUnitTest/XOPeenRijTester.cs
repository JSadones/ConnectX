using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XOPeenRijLibrary;

namespace XOPeenRijUnitTest
{
    [TestClass]
    public class XOPeenRijTester
    {
        private XOPeenRij game;
        private XOPeenRij gameWithVerticalWonRaster;
        private XOPeenRij gameWith45DegreeStartingAtColumn0WonRaster;
        private XOPeenRij gameWithNotWonRaster;
        private XOPeenRij gameWithFullRaster;
        private XOPeenRij gameWithOneTokenBeforeFullRaster;

        [TestInitialize]
        public void setup()
        {
            // Empty game
            game = new XOPeenRij();

            // Game in raster where 4 in a row can be found
            gameWithVerticalWonRaster = new XOPeenRij();
            gameWithVerticalWonRaster.insertToken(0, 1);
            gameWithVerticalWonRaster.insertToken(0, 1);
            gameWithVerticalWonRaster.insertToken(0, 1);
            gameWithVerticalWonRaster.insertToken(0, 1);

            gameWith45DegreeStartingAtColumn0WonRaster = new XOPeenRij();
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(0, 1);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(1, 2);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(1, 1);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(2, 2);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(2, 2);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(2, 1);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(3, 2);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(3, 2);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(3, 2);
            gameWith45DegreeStartingAtColumn0WonRaster.insertToken(3, 1);
            
            // Game in raster where 4 in a row can almost be found (3 in a row)
            gameWithNotWonRaster = new XOPeenRij();
            gameWithNotWonRaster.insertToken(0, 1);
            gameWithNotWonRaster.insertToken(0, 1);
            gameWithNotWonRaster.insertToken(0, 1);


            // Game with full raster
            gameWithFullRaster = new XOPeenRij();
            gameWithFullRaster.insertToken(0, 1);
            gameWithFullRaster.insertToken(0, 2);
            gameWithFullRaster.insertToken(0, 1);
            gameWithFullRaster.insertToken(0, 2);
            gameWithFullRaster.insertToken(0, 1);
            gameWithFullRaster.insertToken(0, 2);
            gameWithFullRaster.insertToken(1, 1);
            gameWithFullRaster.insertToken(1, 2);
            gameWithFullRaster.insertToken(1, 1);
            gameWithFullRaster.insertToken(1, 2);
            gameWithFullRaster.insertToken(1, 1);
            gameWithFullRaster.insertToken(1, 2);
            gameWithFullRaster.insertToken(2, 1);
            gameWithFullRaster.insertToken(2, 2);
            gameWithFullRaster.insertToken(2, 1);
            gameWithFullRaster.insertToken(2, 2);
            gameWithFullRaster.insertToken(2, 1);
            gameWithFullRaster.insertToken(2, 2);
            gameWithFullRaster.insertToken(3, 1);
            gameWithFullRaster.insertToken(3, 2);
            gameWithFullRaster.insertToken(3, 1);
            gameWithFullRaster.insertToken(3, 2);
            gameWithFullRaster.insertToken(3, 1);
            gameWithFullRaster.insertToken(3, 2);
            gameWithFullRaster.insertToken(4, 1);
            gameWithFullRaster.insertToken(4, 2);
            gameWithFullRaster.insertToken(4, 1);
            gameWithFullRaster.insertToken(4, 2);
            gameWithFullRaster.insertToken(4, 1);
            gameWithFullRaster.insertToken(4, 2);
            gameWithFullRaster.insertToken(5, 1);
            gameWithFullRaster.insertToken(5, 2);
            gameWithFullRaster.insertToken(5, 1);
            gameWithFullRaster.insertToken(5, 2);
            gameWithFullRaster.insertToken(5, 1);
            gameWithFullRaster.insertToken(5, 2);
            gameWithFullRaster.insertToken(6, 1);
            gameWithFullRaster.insertToken(6, 2);
            gameWithFullRaster.insertToken(6, 1);
            gameWithFullRaster.insertToken(6, 2);
            gameWithFullRaster.insertToken(6, 1);
            gameWithFullRaster.insertToken(6, 2);


            // Game with almost full raster
            gameWithOneTokenBeforeFullRaster = new XOPeenRij();
            gameWithOneTokenBeforeFullRaster.insertToken(0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 2);
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
            gameWithFullRaster.insertToken(0, 1);
            Assert.IsFalse(gameWithFullRaster.hasNotCrashed());
        }

        [TestMethod]
        public void TestIsRasterFullWhenRasterIsFull()
        {
            Assert.IsTrue(gameWithFullRaster.rasterIsFull());
        }

        [TestMethod]
        public void TestIsRasterFullWhenRasterIsNotFull()
        {
            Assert.IsFalse(gameWithOneTokenBeforeFullRaster.rasterIsFull());
        }

        [TestMethod]
        public void TestGivenNotWonGameIfIsNotWonYet()
        {
            Assert.IsFalse(gameWithNotWonRaster.isWon());
        }

        [TestMethod]
        public void TestGivenVerticalWonGameIfIsWon()
        {
            Assert.IsTrue(gameWithVerticalWonRaster.isWonVertical());
        }

        [TestMethod]
        public void TestGiven45DegreeWonGameIfIsWon()
        {
            Assert.IsTrue(gameWith45DegreeStartingAtColumn0WonRaster.isWonDiagonal());
        }

        [TestMethod]
        public void TestNewGameWithParameters()
        {
            // New game with 10 rows, 12 columns, tokenStreak of 7
            XOPeenRij gameWithParameters = new XOPeenRij(10,12,7);

            Assert.IsTrue(gameWith45DegreeStartingAtColumn0WonRaster.getRows() == 10);
            Assert.IsTrue(gameWith45DegreeStartingAtColumn0WonRaster.getColumns() == 12);
            Assert.IsTrue(gameWith45DegreeStartingAtColumn0WonRaster.getStreakToReach() == 7);
        }

        [TestMethod]
        public void TestTurnByAI()
        {


            // Spel met een net niet vol raster
            XOPeenRij gameWithOneTokenBeforeFullRasterForAI = new XOPeenRij();
            gameWithOneTokenBeforeFullRasterForAI.insertToken(0, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(0, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(0, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(0, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(0, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(0, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(1, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(1, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(1, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(1, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(1, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(1, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(2, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(2, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(2, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(2, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(2, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(2, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(3, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(3, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(3, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(3, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(3, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(3, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(4, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(4, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(4, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(4, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(4, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(4, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(5, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(5, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(5, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(5, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(5, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(5, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(6, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(6, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(6, 1);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(6, 2);
            gameWithOneTokenBeforeFullRasterForAI.insertToken(6, 2);
            // Let AI Determine Spot To Put Token
            gameWithOneTokenBeforeFullRasterForAI.insertTokenByAI();

            Assert.IsTrue(gameWithOneTokenBeforeFullRasterForAI.rasterIsFull());
        }

    }
}