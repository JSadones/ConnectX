using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXTester
    {
        private ConnectX game;
        private ConnectX gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon;
        private ConnectX gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon;
		private ConnectX gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon;
        private ConnectX gameWith45DegreeStartingAtColumn0Row0WonRaster;
		private ConnectX gameWith45DegreeStartingAtColumn0Row1WonRaster;
		private ConnectX gameWith135DegreeStartingAtColumn0Row0WonRaster;
		private ConnectX gameWith135DegreeStartingAtColumnXRow1WonRaster;
        private ConnectX gameWithNotWonRaster;
        private ConnectX gameWithFullRaster;
        private ConnectX gameWithOneTokenBeforeFullRaster;
		private ConnectX gameWithout45Degree;

        [TestInitialize]
        public void setup() {
            // Empty game
            game = new ConnectX();

            // Game in raster where 4 in a row can be found vertically
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon = new ConnectX();
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);

            // Game in raster where 4 in a row can be found vertically, and let game check if it is won
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon = new ConnectX();
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 1);
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 1);
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 1);
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 1);
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.isWon();

			//Game in raster where 4 in a row can be found horizontally
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon = new ConnectX();
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(1, 1);
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(2, 1);
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(3, 1);

			// Game in raster where diagonal 45° can be found starting from column 0 row 0
            gameWith45DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 1);

			// Game in raster where diagonal 45° can be found starting from column 0 row 1
			gameWith45DegreeStartingAtColumn0Row1WonRaster = new ConnectX();
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(0, 1);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(0, 2);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 1);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 2);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 2);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 1);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 2);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 1);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 2);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 1);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 1);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2);
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2);

			// #####DEBUG#####
			// Game in raster without diagonal 45° where game is won anyway. 
			gameWithout45Degree = new ConnectX();
			gameWithout45Degree.insertToken(0, 1);
			gameWithout45Degree.insertToken(0, 2);
			gameWithout45Degree.insertToken(0, 1);
			gameWithout45Degree.insertToken(0, 2);
			gameWithout45Degree.insertToken(1, 2);
			gameWithout45Degree.insertToken(1, 1);
			gameWithout45Degree.insertToken(1, 1);
			gameWithout45Degree.insertToken(1, 1);
			gameWithout45Degree.insertToken(2, 1);
			gameWithout45Degree.insertToken(2, 2);
			gameWithout45Degree.insertToken(2, 2);
			gameWithout45Degree.insertToken(2, 2);
			gameWithout45Degree.insertToken(2, 1);
			gameWithout45Degree.insertToken(3, 2);
			gameWithout45Degree.insertToken(3, 1);
			gameWithout45Degree.insertToken(3, 1);
			gameWithout45Degree.insertToken(3, 2);
			gameWithout45Degree.insertToken(4, 1);
			gameWithout45Degree.insertToken(4, 2);
			gameWithout45Degree.insertToken(4, 2);
			gameWithout45Degree.insertToken(4, 1);
			gameWithout45Degree.insertToken(5, 2);
			gameWithout45Degree.insertToken(5, 1);
			gameWithout45Degree.insertToken(5, 1);
			gameWithout45Degree.insertToken(5, 2);
			gameWithout45Degree.insertToken(6, 1);
			gameWithout45Degree.insertToken(6, 2);
			gameWithout45Degree.insertToken(6, 2);
			gameWithout45Degree.insertToken(6, 1);


			// Game in raster where diagonal 135° can be found starting from column 0 row 0
			gameWith135DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2);
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);

			// Game in raster where diagonal 135° can be found starting from column x row 1
			gameWith135DegreeStartingAtColumnXRow1WonRaster = new ConnectX();
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(6, 2);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(6, 2);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 2);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 1);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 2);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 1);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 2);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 1);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 2);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 1);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 1);
			gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2);


            // Game in raster where 4 in a row can almost be found (3 in a row)
            gameWithNotWonRaster = new ConnectX();
            gameWithNotWonRaster.insertToken(0, 1);
            gameWithNotWonRaster.insertToken(0, 1);
            gameWithNotWonRaster.insertToken(0, 1);


            // Game with full raster
            gameWithFullRaster = new ConnectX();
            gameWithFullRaster.insertToken(0, 1);
            gameWithFullRaster.insertToken(0, 2);
            gameWithFullRaster.insertToken(0, 1);
            gameWithFullRaster.insertToken(0, 2);
            gameWithFullRaster.insertToken(0, 1);
            gameWithFullRaster.insertToken(0, 2);
            gameWithFullRaster.insertToken(1, 1);
            gameWithFullRaster.insertToken(1, 2);
            gameWithFullRaster.insertToken(1, 1);
            gameWithFullRaster.insertToken(1, 2);
            gameWithFullRaster.insertToken(1, 1);
            gameWithFullRaster.insertToken(1, 2);
            gameWithFullRaster.insertToken(2, 1);
            gameWithFullRaster.insertToken(2, 2);
            gameWithFullRaster.insertToken(2, 1);
            gameWithFullRaster.insertToken(2, 2);
            gameWithFullRaster.insertToken(2, 1);
            gameWithFullRaster.insertToken(2, 2);
            gameWithFullRaster.insertToken(3, 1);
            gameWithFullRaster.insertToken(3, 2);
            gameWithFullRaster.insertToken(3, 1);
            gameWithFullRaster.insertToken(3, 2);
            gameWithFullRaster.insertToken(3, 1);
            gameWithFullRaster.insertToken(3, 2);
            gameWithFullRaster.insertToken(4, 1);
            gameWithFullRaster.insertToken(4, 2);
            gameWithFullRaster.insertToken(4, 1);
            gameWithFullRaster.insertToken(4, 2);
            gameWithFullRaster.insertToken(4, 1);
            gameWithFullRaster.insertToken(4, 2);
            gameWithFullRaster.insertToken(5, 1);
            gameWithFullRaster.insertToken(5, 2);
            gameWithFullRaster.insertToken(5, 1);
            gameWithFullRaster.insertToken(5, 2);
            gameWithFullRaster.insertToken(5, 1);
            gameWithFullRaster.insertToken(5, 2);
            gameWithFullRaster.insertToken(6, 1);
            gameWithFullRaster.insertToken(6, 2);
            gameWithFullRaster.insertToken(6, 1);
            gameWithFullRaster.insertToken(6, 2);
            gameWithFullRaster.insertToken(6, 1);
            gameWithFullRaster.insertToken(6, 2);


            // Game with almost full raster
            gameWithOneTokenBeforeFullRaster = new ConnectX();
            gameWithOneTokenBeforeFullRaster.insertToken(0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 2);
        }

        [TestMethod]
        public void TestGameExists() {
            Assert.IsTrue(game.exists());
        }

        [TestMethod]
        public void TestRasterExists() {
            Assert.IsTrue(game.rasterExists());
        }

        [TestMethod]
        public void TestIsRasterInitializedWithZeros() {
            Assert.IsTrue(game.isRasterInitializedWithZeros());
        }

        [TestMethod]
        public void TestInsertTokenInRasterAndAssertThatRasterIsNotZero() {
            // Insert token for column 0 for player 1
            game.insertToken(0, 1);
            Assert.IsFalse(game.isRasterInitializedWithZeros());
        }

        [TestMethod]
        public void TestInsertTokenInRasterInFullColumn() {
            gameWithFullRaster.insertToken(0, 1);
            Assert.IsFalse(gameWithFullRaster.hasNotCrashed());
        }

        [TestMethod]
        public void TestIsRasterFullWhenRasterIsFull() {
            Assert.IsTrue(gameWithFullRaster.rasterIsFull());
        }

        [TestMethod]
        public void TestIsRasterFullWhenRasterIsNotFull() {
            Assert.IsFalse(gameWithOneTokenBeforeFullRaster.rasterIsFull());
        }

        [TestMethod]
        public void TestGivenNotWonGameIfIsNotWonYet() {
            Assert.IsFalse(gameWithNotWonRaster.isWon());
        }

        [TestMethod]
        public void TestGivenVerticalWonGameIfIsWon() {
            Assert.IsTrue(gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.isWonVertical());
        }

		[TestMethod]
		public void TestGivenHorizontalWonGameIfIsWon() {
			Assert.IsTrue(gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.isWonHorizontal());
		}

        [TestMethod]
        public void TestGiven45DegreeWonGameIfIsWon() {
         //   Assert.IsTrue(gameWith45DegreeStartingAtColumn0Row0WonRaster.isWonDiagonal45());
		//	Assert.IsTrue(gameWith45DegreeStartingAtColumn0Row1WonRaster.isWonDiagonal45());
			Assert.IsFalse(gameWithout45Degree.isWonDiagonal45());
        }

		[TestMethod]
		public void TestGiven135DegreeWonGameIfIsWon() {
			Assert.IsTrue(gameWith135DegreeStartingAtColumn0Row0WonRaster.isWonDiagonal135());
			Assert.IsTrue(gameWith135DegreeStartingAtColumnXRow1WonRaster.isWonDiagonal135());
		}

        [TestMethod]
        public void TestNewGameWithParameters() {
            // New game with 10 rows, 12 columns, tokenStreak of 7
            ConnectX gameWithParameters = new ConnectX(10,12,7);

            Assert.IsTrue(gameWithParameters.getRows() == 10);
            Assert.IsTrue(gameWithParameters.getColumns() == 12);
            Assert.IsTrue(gameWithParameters.getStreakToReach() == 7);
        }

        [TestMethod]
        public void TestTurnByAI() {
            // Let AI Determine Spot To Put Token
            gameWithOneTokenBeforeFullRaster.insertTokenByAI();

            Assert.IsTrue(gameWithOneTokenBeforeFullRaster.rasterIsFull());
        }

        [TestMethod]
        public void TestClearRaster() {
            gameWithFullRaster.clearRaster();
            Assert.IsTrue(gameWithFullRaster.isRasterInitializedWithZeros());
            game.insertToken(0, 1);
            Assert.IsFalse(game.isRasterInitializedWithZeros());
        }

        [TestMethod]
        public void TestGetWinningPlayerGivenWonGame() {
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.isWon();
            Assert.IsTrue(gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.getWonPlayer() == 1);
        }

        [TestMethod]
        public void TestWhichPlayerPlaysNextTurn() {
            game.insertToken(0, 1);
            Assert.IsTrue(game.getPlayerAtTurn() == 2);
        }
    }
}