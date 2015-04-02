using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXWebServerTester
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] prefixes = { "http://localhost:8080/index/" };

            //ConnectXLibrary.WebServer.SimpleListenerExample(prefixes);
        }
    }
}
