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
        public void TestGetScorePlayer1()
        {
            gameInterface.setScorePlayer1(1);
            // Parameter == player number
            Assert.IsTrue(gameInterface.getScore(1) == 1);
        }
    }
}
