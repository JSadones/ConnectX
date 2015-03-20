﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXInterfaceTester {
        ConnectXInterface gameInterface;

        [TestInitialize]
        public void setup() {
            gameInterface = new ConnectXInterface();
        }

        [TestMethod]
        public void TestNewGameStarted() {
            gameInterface.newGame();
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestGetScorePlayer1() {
            gameInterface.incrementScorePlayer(1);
            // Parameter == player number
            Assert.IsTrue(gameInterface.getScore(1) == 1);
        }

        [TestMethod]
        public void TestGetOverallWonPlayer()
        {
            gameInterface.incrementScorePlayer(1);
            gameInterface.incrementScorePlayer(2);
            // Parameter == player number
            Assert.IsTrue(gameInterface.getOverallWonPlayer() == 0);
            gameInterface.incrementScorePlayer(1);
            Assert.IsTrue(gameInterface.getOverallWonPlayer() == 1);
            gameInterface.incrementScorePlayer(2);
            gameInterface.incrementScorePlayer(2);
            Assert.IsTrue(gameInterface.getOverallWonPlayer() == 2);
        }

        [TestMethod]
        public void TestNewGame2HumanPlayersWith9RowsAnd11Columns() {
            gameInterface.newGame(2, 9, 11);
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestNewGame2HumanPlayersWith9RowsAnd5Streak() {
            gameInterface.newGame(2, 9, 11, 5);
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestNewGame1HumanPlayerWith9RowsAnd11Columns() {
            gameInterface.newGame(1, 9, 11);
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestResetGame() {
            gameInterface.newGame(2, 9, 11);
            gameInterface.incrementScorePlayer(1);
            gameInterface.incrementScorePlayer(2);
            Assert.IsTrue(gameInterface.gameRunning());
            gameInterface.reset();
			Assert.IsFalse(gameInterface.gameRunning());
            Assert.IsTrue(gameInterface.getScore(1) == 0);
            Assert.IsTrue(gameInterface.getScore(2) == 0);

        }
		
        [TestMethod]
        public void TestCurrentGameWon() {
            gameInterface.newGame();
            
            Assert.IsTrue(gameInterface.isCurrentGameWon() == false);

            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 2);

            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(3, 2);

            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(4, 2);

            gameInterface.insertToken(1, 1);

			Assert.IsTrue(gameInterface.isCurrentGameWon() == true);

        }

        public void TestGetPlayerAtPlay() {
            // Parameter == player number
            Assert.IsTrue(gameInterface.getPlayerAtPlay() == 1);
        }

        [TestMethod]
        public void TestInsertTokenInColumn2ByPlayer1() {
            gameInterface.newGame();
            
            // insertToken returns true if token is successfully inserted
            Assert.IsTrue(gameInterface.insertToken(2,1));
            // return false if it is not his turn
            Assert.IsTrue(gameInterface.insertToken(2, 2));
        }
	}
}
