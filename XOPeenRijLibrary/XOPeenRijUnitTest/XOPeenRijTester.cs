using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XOPeenRijLibrary;

namespace XOPeenRijUnitTest
{
    [TestClass]
    public class XOPeenRijTester
    {
        private XOPeenRij spel;

        [TestInitialize]
        public void setup()
        {
            spel = new XOPeenRij();
        }
        [TestMethod]
        public void TestBestaatSpel()
        {
            Assert.IsTrue(spel.bestaat());
        }

        [TestMethod]
        public void TestBestaatErEenRasterInHetSpel()
        {
            Assert.IsTrue(spel.rasterBestaat());
        }
    }
}