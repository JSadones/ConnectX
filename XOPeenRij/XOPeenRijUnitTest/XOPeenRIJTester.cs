using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XOPeenRij;

namespace XOPeenRijUnitTest
{
    [TestClass]
    public class XOPeenRIJTester
    {
        [TestMethod]
        public void TestAanmaakSpel()
        {
            XOPeenRij spel = new XOPeenRIJ();
            Assert.IsTrue(spel.bestaat());
        }
    }
}
