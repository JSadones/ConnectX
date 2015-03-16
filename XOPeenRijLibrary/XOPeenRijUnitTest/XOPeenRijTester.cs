using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XOPeenRijLibrary;

namespace XOPeenRijUnitTest
{
    [TestClass]
    public class XOPeenRijTester
    {
        [TestMethod]
        public void TestBestaatSpel()
        {
            XOPeenRij spel = new XOPeenRij();
            Assert.IsTrue(spel.bestaat());
        }
    }
}