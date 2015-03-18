using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace XOPeenRijUnitTest
{
    [TestClass]
    public class ConnectXInterfaceTester
    {
        XOPeenRijInterface gameInterface;

        [TestInitialize]
        public void setup() {
            gameInterface = new XOPeenRijInterface();
        }

        [TestMethod]
        public void TestNewGameStarted() {
            Assert.IsFalse(gameInterface.gameRunning());
            gameInterface.newGame();
            Assert.IsTrue(gameInterface.gameRunning());
        }
    }
}