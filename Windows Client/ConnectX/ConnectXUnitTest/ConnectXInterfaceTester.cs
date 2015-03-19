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
        public void TestNewGame2HumanPlayersWith9RowsAnd11Columns()
        {
            Assert.IsFalse(gameInterface.gameRunning());
            gameInterface.newGame(2, 9, 11);
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestGetPlayerAtPlay()
        {
            gameInterface.setPlayerAtPlay(1);
            // Parameter == player number
            Assert.IsTrue(gameInterface.getPlayerAtPlay() == 1);
        }

        [TestMethod]
        public void TestInsertTokenInColumn2ByPlayer1()
        {
            gameInterface.setPlayerAtPlay(1);
            
            // insertToken returns true if token is successfully inserted
            Assert.IsTrue(gameInterface.insertToken(2,1));
            // return false if it is not his turn
            Assert.IsFalse(gameInterface.insertToken(2, 2));
        }
    }
}
