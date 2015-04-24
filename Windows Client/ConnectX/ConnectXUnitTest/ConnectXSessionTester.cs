using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXSessionTester {
        ConnectXSession gameInterface;
		ConnectXSession gameInterface10Rows14Columns;
		ConnectXSession gameInterface10Rows14Columns5Streak;

        [TestInitialize]
        public void setup() {
            gameInterface = new ConnectXSession();
			gameInterface10Rows14Columns = new ConnectXSession(10, 14);
			gameInterface10Rows14Columns5Streak = new ConnectXSession(10, 14, 5);

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
        public void TestCurrentGameWon() {
            gameInterface.newGame();
            
            Assert.IsTrue(gameInterface.isCurrentGameWon() == false);

            gameInterface.checkIfWon(1, 1);
            gameInterface.checkIfWon(2, 2);

            gameInterface.checkIfWon(1, 1);
            gameInterface.checkIfWon(3, 2);

            gameInterface.checkIfWon(1, 1);
            gameInterface.checkIfWon(4, 2);

            gameInterface.checkIfWon(1, 1);

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
            Assert.IsTrue(gameInterface.checkIfWon(2,1));
            // return false if it is not his turn
            Assert.IsTrue(gameInterface.checkIfWon(2, 2));
        }

        [TestMethod]
        public void TestInsertTokenByUserAndThenByAIAndThenByUserAndCheckIfTurnsAreRespected()
        {
            gameInterface.newGame();


            Assert.IsTrue(gameInterface.checkIfWon(2, 1));
            Assert.IsFalse(gameInterface.checkIfWon(2, 1));

            Assert.IsTrue(gameInterface.insertTokenByAI());
            Assert.IsFalse(gameInterface.insertTokenByAI());

            Assert.IsTrue(gameInterface.checkIfWon(2, 1));

        }
	}
}
