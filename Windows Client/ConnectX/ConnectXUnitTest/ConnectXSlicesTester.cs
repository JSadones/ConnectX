using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXSlicesTester
    {
        ConnectXInterface gameInterface;

        [TestInitialize]
        public void setup()
        {
        }

        [TestMethod]
        public void TestSlice1_1NamenOpvragen()
        {
            string naamSpeler1 = "Speler 1";
            string naamSpeler2 = "Speler 2";

            gameInterface = new ConnectXInterface(naamSpeler1, naamSpeler2);

            Assert.IsTrue(gameInterface.getName(1) == "Speler 1");
            Assert.IsTrue(gameInterface.getName(2) == "Speler 2");
            Assert.IsFalse(gameInterface.getName(2) == "Speler 1");
        }

        [TestMethod]
        public void TestSlice1_2NamenOpvragen()
        {
            string naamSpeler1 = "Speler 1";
            string naamSpeler2 = "Speler 2";

            gameInterface = new ConnectXInterface(naamSpeler1, naamSpeler2);

            Assert.IsTrue(gameInterface.getName(1) == "Speler 1");
            Assert.IsTrue(gameInterface.getName(2) == "Speler 2");
            Assert.IsFalse(gameInterface.getName(2) == "Speler 1");
        }
    }
}
