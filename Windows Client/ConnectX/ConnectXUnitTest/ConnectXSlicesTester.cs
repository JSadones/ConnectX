using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXSlicesTester
    {
        ConnectXSession gameInterface;

        [TestInitialize]
        public void setup()
        {
            gameInterface = new ConnectXSession();
        }

        [TestMethod]
        public void TestSlice1_1AskNames()
        {
            gameInterface = new ConnectXSession();

            gameInterface.setName(1, "Player 1");
            gameInterface.setName(2, "Player 2");

            Assert.IsTrue(gameInterface.getName(1) == "Player 1");
            Assert.IsTrue(gameInterface.getName(2) == "Player 2");
            Assert.IsFalse(gameInterface.getName(2) == "Player 1");
            
        }

        [TestMethod]
        public void TestSlice1_2StartGame()
        {
            gameInterface.newGame();

            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestSlice2_1CheckIfColumnIsNotFull()
        {
            gameInterface.newGame();
            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(1, 2);
            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(1, 2);
            gameInterface.insertToken(1, 1);

            Assert.IsFalse(gameInterface.isColumnFull(1));

            gameInterface.insertToken(1, 2);

            Assert.IsTrue(gameInterface.isColumnFull(1));
        }

        [TestMethod]
        public void TestSlice2_2SelectColumnAndInsertToken()
        {
            gameInterface.newGame();
            gameInterface.insertToken(1, 1);

            Assert.IsFalse(gameInterface.getToken(1,0) == 1);
        }

        [TestMethod]
        public void TestSlice2_3CheckIfGameIsWon()
        {
            gameInterface.newGame();
            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 2);
            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 2);
            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 2);

            Assert.IsFalse(gameInterface.isCurrentGameWon());

            gameInterface.insertToken(1, 1);

            Assert.IsTrue(gameInterface.isCurrentGameWon());
        }

        [TestMethod]
        public void TestSlice2_4IncrementScoreWinningPlayer()
        {
            // TODO: rename to incrementScorePlayer(int player)
            gameInterface.incrementScorePlayer(1);

            Assert.IsTrue(gameInterface.getScore(1) == 1);

            gameInterface.incrementScorePlayer(2);

            Assert.IsTrue(gameInterface.getScore(2) == 1);

            gameInterface.incrementScorePlayer(1);

            Assert.IsTrue(gameInterface.getScore(1) == 2);

            gameInterface.incrementScorePlayer(2);

            Assert.IsTrue(gameInterface.getScore(2) == 2);
        }

        [TestMethod]
        public void TestSlice2_5AskForNewGame()
        {
            // Komt nog
        }

        [TestMethod]
        public void TestSlice2_6PlayNewGame()
        {
            gameInterface.newGame();
            gameInterface.insertToken(1, 1);
            gameInterface.newGame();
            Assert.IsTrue(gameInterface.getToken(1, 0) == 0);
        }
		
        [TestMethod]
        public void TestSlice3_1ShowWinner()
        {
            gameInterface.newGame();
            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 2);
            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 2);
            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 2);
            gameInterface.insertToken(1, 1);
            gameInterface.isCurrentGameWon();
            Assert.IsTrue(gameInterface.getCurrentGameWonPlayer() == 1);
        }
    }
}
