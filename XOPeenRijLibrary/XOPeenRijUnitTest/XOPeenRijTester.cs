﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XOPeenRijLibrary;

namespace XOPeenRijUnitTest
{
    [TestClass]
    public class XOPeenRijTester
    {
        private XOPeenRij game;

        [TestInitialize]
        public void setup()
        {
            game = new XOPeenRij();
        }
        [TestMethod]
        public void testGameExists()
        {
            Assert.IsTrue(game.exists());
        }

        [TestMethod]
        public void TestRasterExists()
        {
            Assert.IsTrue(game.rasterExists());
        }

        [TestMethod]
        public void TestIsWon()
        {
            Assert.IsTrue(game.isWon());
        }
    }
}