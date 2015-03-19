using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXInterfaceTester
    {
        ConnectXInterface gameInterface;

        [TestInitialize]
        public void setup() {
            gameInterface = new ConnectXInterface();
        }

        [TestMethod]
        public void TestNewGameStarted() {
            Assert.IsFalse(gameInterface.gameRunning());
            gameInterface.newGame();
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestGetScorePlayer1() {
            gameInterface.setScorePlayer(1);
            // Parameter == player number
            Assert.IsTrue(gameInterface.getScore(1) == 1);
        }

        [TestMethod]
        public void TestNewGame2HumanPlayersWith9RowsAnd11Columns() {
            Assert.IsFalse(gameInterface.gameRunning());
            gameInterface.newGame(2, 9, 11);
            Assert.IsTrue(gameInterface.gameRunning());
        }

<<<<<<< HEAD
		[TestMethod]
=======
        [TestMethod]
        public void TestNewGame2HumanPlayersWith9RowsAnd5Streak() {
            Assert.IsFalse(gameInterface.gameRunning());
            gameInterface.newGame(2, 9, 11,5);
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestNewGame1HumanPlayerWith9RowsAnd11Columns()
        {
            Assert.IsFalse(gameInterface.gameRunning());
            gameInterface.newGame(1, 9, 11);
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestResetGame()
        {
            gameInterface.newGame(2, 9, 11);
            gameInterface.setScorePlayer(1);
            gameInterface.setScorePlayer(2);
            Assert.IsTrue(gameInterface.gameRunning());
            gameInterface.reset();
            Assert.IsFalse(gameInterface.gameRunning());
            Assert.IsTrue(gameInterface.getScore(1) == 0);
            Assert.IsTrue(gameInterface.getScore(2) == 0);

        }

        [TestMethod]
        public void TestCurrentGameWon() {
            gameInterface.newGame();
            
            Assert.IsTrue(gameInterface.isCurrentGameWon == false);

            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 2);

            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 3);

            gameInterface.insertToken(1, 1);
            gameInterface.insertToken(2, 4);

            gameInterface.insertToken(1, 1);

            Assert.IsTrue(gameInterface.isCurrentGameWon == true);

        }

        [TestMethod]
        public void TestFinishOverallGame() {
            Assert.IsTrue(gameInterface.isFinished == false);
            gameInterface.finish();
            Assert.IsTrue(gameInterface.isFinished == true);

        }

<<<<<<< Updated upstream
        [TestMethod]
<<<<<<< Updated upstream
>>>>>>> 5a2d9398649518b684d7112f323799d6de8d1fd3
        public void TestGetPlayerAtPlay()
        {
=======
        public void TestGetPlayerAtPlay() {
>>>>>>> Stashed changes
=======
        public void TestGetPlayerAtPlay() {
>>>>>>> Stashed changes
=======
=======
>>>>>>> Stashed changes
        public void TestGetPlayerAtPlay() {
            gameInterface.setPlayerAtPlay(1);
            // Parameter == player number
            Assert.IsTrue(gameInterface.getPlayerAtPlay() == 1);
        }
		
        [TestMethod]
<<<<<<< HEAD
       public void TestInsertTokenInColumn2ByPlayer1() {
			gameInterface.newGame();
			gameInterface.setPlayerAtPlay(1);
=======
        public void TestInsertTokenInColumn2ByPlayer1() {
            gameInterface.setPlayerAtPlay(1);
>>>>>>> 5a2d9398649518b684d7112f323799d6de8d1fd3
            
            // insertToken returns true if token is successfully inserted
            Assert.IsTrue(gameInterface.insertToken(2,1));
            // return false if it is not his turn
            Assert.IsFalse(gameInterface.insertToken(2, 2));
        }
	   
	}
}
