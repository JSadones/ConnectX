using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXInterfaceTester {
        ConnectXInterface gameInterface;
		ConnectXInterface gameInterface10Rows14Columns;
		ConnectXInterface gameInterface10Rows14Columns5Streak;

        [TestInitialize]
        public void setup() {
            gameInterface = new ConnectXInterface();
			gameInterface10Rows14Columns = new ConnectXInterface(10, 14);
			gameInterface10Rows14Columns5Streak = new ConnectXInterface(10, 14, 5);

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
        public void TestNewGame2HumanPlayersWith10RowsAnd14Columns() {
            gameInterface.newGame();
            Assert.IsTrue(gameInterface10Rows14Columns.gameRunning());
        }

        [TestMethod]
        public void TestNewGameWith10Rows14ColumnsAnd5Streak() {
			gameInterface10Rows14Columns5Streak.newGame();
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestNewGameWith10RowsAnd14Columns() {
			gameInterface10Rows14Columns.newGame();
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestResetGame() {
			gameInterface10Rows14Columns.newGame();
			gameInterface10Rows14Columns.incrementScorePlayer(1);
			gameInterface10Rows14Columns.incrementScorePlayer(2);
			Assert.IsTrue(gameInterface10Rows14Columns.gameRunning());
			gameInterface10Rows14Columns.reset();
			Assert.IsFalse(gameInterface10Rows14Columns.gameRunning());
			Assert.IsTrue(gameInterface10Rows14Columns.getScore(1) == 0);
			Assert.IsTrue(gameInterface10Rows14Columns.getScore(2) == 0);

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
