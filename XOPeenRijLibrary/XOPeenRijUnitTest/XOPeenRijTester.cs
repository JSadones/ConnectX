using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XOPeenRijLibrary;

namespace XOPeenRijUnitTest
{
    [TestClass]
    public class XOPeenRijTester
    {
        public void setup()
        {
            XOPeenRij spel = new XOPeenRij();
        }
        [TestMethod]
        public void TestBestaatSpel()
        {
            Assert.IsTrue(spel.bestaat());
        }

        public void TestBestaatErEenRasterInHetSpel()
        {
            Assert.IsTrue(spel.rasterBestaat());
        }
    }
}