using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXTester
    {
        private ConnectX game;
        private ConnectX game10Rows14Columns;
        private ConnectX game10Rows14Columns6Streak;

        private ConnectX gameInterface;
        private ConnectX gameInterface10Rows14Columns;
        private ConnectX gameInterface10Rows14Columns5Streak;

        private ConnectX gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon;
        private ConnectX gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon;

        private ConnectX game10Rows14ColumnsWithVerticalWonRasterByPlayer1BeforeControlIfIsWon;
        private ConnectX game10Rows14ColumnsWithVerticalWonRasterByPlayer1AfterControlIfIsWon;

		private ConnectX gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon;

		private ConnectX game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon;

        private ConnectX gameWith45DegreeStartingAtColumn0Row0WonRaster;
        private ConnectX gameWith45DegreeStartingAtColumn0Row1WonRaster;
        private ConnectX gameWithout45Degree;

        private ConnectX game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster;
        private ConnectX game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster;
        private ConnectX game10Rows14ColumnsWithout45Degree;

		private ConnectX gameWith135DegreeStartingAtColumn0Row0WonRaster;
        private ConnectX gameWith135DegreeStartingAtColumnXRow1WonRaster;

        private ConnectX game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster;
        private ConnectX game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster;

        private ConnectX gameWithNotWonRaster;
        private ConnectX game10Rows14ColumnsWithNotWonRaster;
        private ConnectX gameWithFullRaster;
        private ConnectX game10Rows14ColumnsWithFullRaster;
        private ConnectX gameWithOneTokenBeforeFullRaster;
        private ConnectX game10Rows14ColumnsWithOneTokenBeforeFullRaster;

        [TestInitialize]
        public void setup() {
            // Empty game
            game = new ConnectX();
            game10Rows14Columns = new ConnectX(10, 14);
            game10Rows14Columns6Streak = new ConnectX(10, 14, 6);

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

            // Game in raster where 4 in a row can be found vertically
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1BeforeControlIfIsWon = new ConnectX(10,14);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);

            // Game in raster where 4 in a row can be found vertically, and let game check if it is won
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1AfterControlIfIsWon = new ConnectX(10,14);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 1);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 1);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 1);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 1);
            game10Rows14ColumnsWithVerticalWonRasterByPlayer1AfterControlIfIsWon.isWon();

			//Game in raster where 4 in a row can be found horizontally
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon = new ConnectX();
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(1, 1);
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(2, 1);
            gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(3, 1);

            //Game in raster where 4 in a row can be found horizontally
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon = new ConnectX(10,14);
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1);
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(1, 1);
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(2, 1);
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(3, 1);

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

            // Game in raster where diagonal 45° can be found starting from column 0 row 0
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 1);

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

            // Game in raster where diagonal 45° can be found starting from column 0 row 1
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster = new ConnectX();
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(0, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(0, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2);

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

            // #####DEBUG#####
            // Game in raster without diagonal 45° where game is won anyway. 
            game10Rows14ColumnsWithout45Degree = new ConnectX();
            game10Rows14ColumnsWithout45Degree.insertToken(0, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(0, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(0, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(0, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(1, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(3, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(3, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(3, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(3, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(4, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(4, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(4, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(4, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(5, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(5, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(5, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(5, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(6, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(6, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(6, 2);
            game10Rows14ColumnsWithout45Degree.insertToken(6, 1);

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

            // Game in raster where diagonal 135° can be found starting from column 0 row 0
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);

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

 
            // Game in raster where diagonal 135° can be found starting from column 0 row 0
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2);

            // Game in raster where diagonal 135° can be found starting from column x row 1
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster = new ConnectX();
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(6, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(6, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2);

            // Game in raster where 4 in a row can almost be found (3 in a row)
            gameWithNotWonRaster = new ConnectX();
            gameWithNotWonRaster.insertToken(0, 1);
            gameWithNotWonRaster.insertToken(0, 1);
            gameWithNotWonRaster.insertToken(0, 1);

            game10Rows14ColumnsWithNotWonRaster = new ConnectX();
            game10Rows14ColumnsWithNotWonRaster.insertToken(0, 1);
            game10Rows14ColumnsWithNotWonRaster.insertToken(0, 1);
            game10Rows14ColumnsWithNotWonRaster.insertToken(0, 1);


            // Game with full raster
            gameWithFullRaster = new ConnectX();

            for (int i = 0; i < gameWithFullRaster.getRows(); i++)
            {
                for (int j = 0; j < gameWithFullRaster.getColumns(); j++)
                {
                    gameWithFullRaster.insertToken(j, 1);
                }
            }

            game10Rows14ColumnsWithFullRaster = new ConnectX(10, 14);

            for (int i = 0; i < game10Rows14ColumnsWithFullRaster.getRows(); i++)
            {
                for (int j = 0; j < game10Rows14ColumnsWithFullRaster.getColumns(); j++)
                {
                    game10Rows14ColumnsWithFullRaster.insertToken(j,1);
                }
            }

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
            gameWithOneTokenBeforeFullRaster.insertToken(6, 1);


            game10Rows14ColumnsWithOneTokenBeforeFullRaster = new ConnectX(10, 14);

            int currentplayer = 1;

            for (int i = 0; i < game10Rows14ColumnsWithOneTokenBeforeFullRaster.getRows(); i++)
            {
                for (int j = 0; j < game10Rows14ColumnsWithOneTokenBeforeFullRaster.getColumns(); j++)
                { 
                    if (!(i == (game10Rows14ColumnsWithOneTokenBeforeFullRaster.getRows() - 1) && j == (game10Rows14ColumnsWithOneTokenBeforeFullRaster.getColumns() - 1))) {
                        game10Rows14ColumnsWithOneTokenBeforeFullRaster.insertToken(j, currentplayer);

                        if (currentplayer == 1) currentplayer = 2;
                        else currentplayer = 1;


                    }
                        

                }
            }

            gameInterface = new ConnectX();
            gameInterface10Rows14Columns = new ConnectX(10, 14);
            gameInterface10Rows14Columns5Streak = new ConnectX(10, 14, 5);
        }

        [TestMethod]
        public void TestGameExists() {
            Assert.IsTrue(game.gameExists());
        }

		[TestMethod]
		public void TestIsRasterInitializedWithZeros(){
			Assert.IsTrue(game.isRasterInitializedWithZeros());
		}

		[TestMethod]
		public void Test10Rows14ColumnsIsRasterInitializedWithZeros() {
			Assert.IsTrue(game10Rows14Columns.isRasterInitializedWithZeros());

			for (int i = 0; i < game10Rows14Columns.getColumns(); i++)
			{
				for (int j = 0; j < game10Rows14Columns.getRows(); j++)
				{
					Assert.IsTrue(game10Rows14Columns.getToken(j, i) == 0);
				}
			}
		}

		[TestMethod]
		public void TestNewGameWithParameters() {
			// New game with 10 rows, 12 columns, streakToWin of 7
			ConnectX gameWithParameters = new ConnectX(10, 12, 7);
			Assert.IsTrue(gameWithParameters.getRows() == 10);
			Assert.IsTrue(gameWithParameters.getColumns() == 12);
			Assert.IsTrue(gameWithParameters.getStreakToWin() == 7);
		}

		[TestMethod]
		public void TestInsertTokenInRasterAndAssertThatRasterIsNotZero()
		{
			// Insert token for column 0 for player 1
			game.insertToken(0, 1);
			Assert.IsFalse(game.isRasterInitializedWithZeros());
		}

        [TestMethod]
		public void Test10Rows14ColumnsInsertTokenInRasterAndAssertThatRasterIsNotZero() {
			// Insert token for column 0 for player 1
			game10Rows14Columns.insertToken(0, 1);
			Assert.IsFalse(game10Rows14Columns.isRasterInitializedWithZeros());
        }

		[TestMethod]
		public void TestWhichPlayerPlaysNextTurn() {
			game.insertToken(0, 1);
			Assert.IsTrue(game.getPlayerAtTurn() == 2);
		}

		[TestMethod]
		public void TestTurnByAI() {
			// Let AI Determine Spot To Put Token
			gameWithOneTokenBeforeFullRaster.insertTokenByAI();

			Assert.IsTrue(gameWithOneTokenBeforeFullRaster.rasterIsFull());
		}

        [TestMethod]
        public void TestAIGetColumnWithVerticalLongestStreakOfAI()
        {
            // Let AI Determine Spot To Put Token
            game.insertToken(0, 1);
            game.insertToken(1, 2);
            game.insertToken(2, 1);
            game.insertToken(1, 2);
            game.insertToken(3, 1);
            game.insertToken(1, 2);

            Assert.IsTrue(game.getColumnVerticalLongestStreakOfAI() == 1);
        }

		[TestMethod]
		public void TestAIGetRowWithHorizontalLongestStreakOfAI(){
			game.insertToken(0, 1);
			game.insertToken(1, 2);
			game.insertToken(0, 1);
			game.insertToken(2, 2);
			game.insertToken(0, 1);
			game.insertToken(3, 2);

			Assert.IsTrue(game.getRowHorizontalLongestStreakOfAI() == 0);
		}

	    [TestMethod]
		public void TestAIGetCoordWithDiagonal45LongestStreakOfAI() {
			game.insertToken(0, 2);
			game.insertToken(1, 1);
			game.insertToken(1, 2);
			game.insertToken(2, 2);
			game.insertToken(2, 1);
			game.insertToken(2, 2);

			Assert.IsTrue(game.getCoordinateDiagonal45LongestStreakOfAI().getRow() == 2);
			Assert.IsTrue(game.getCoordinateDiagonal45LongestStreakOfAI().getColumn() == 2);
		}

		[TestMethod]
		public void TestAIGetCoordWithDiagonal135LongestStreakOfAI()
		{
			game.insertToken(1, 2);
			game.insertToken(1, 1);
			game.insertToken(1, 2);
			game.insertToken(2, 1);
			game.insertToken(2, 2);
			game.insertToken(3, 2);

			Assert.IsTrue(game.getCoordinateDiagonal135LongestStreakOfAI().getRow() == 2);
			Assert.IsTrue(game.getCoordinateDiagonal135LongestStreakOfAI().getColumn() == 1);
		}

		[TestMethod]
		public void Test10Rows14ColumnsTurnByAI() {
			game10Rows14ColumnsWithOneTokenBeforeFullRaster.insertTokenByAI();

			Assert.IsTrue(game10Rows14ColumnsWithOneTokenBeforeFullRaster.rasterIsFull());
		}

		[TestMethod]
		public void TestIsRasterFullWhenRasterIsNotFull(){
			Assert.IsFalse(gameWithOneTokenBeforeFullRaster.rasterIsFull());
		}

		[TestMethod]
		public void Test10Rows14ColumnsIsRasterFullWhenRasterIsNotFull(){
			Assert.IsFalse(game10Rows14ColumnsWithOneTokenBeforeFullRaster.rasterIsFull());
		}

		[TestMethod]
		public void TestGivenNotWonGameIfIsNotWonYet()
		{
			Assert.IsFalse(gameWithNotWonRaster.isWon());
		}

		[TestMethod]
		public void Test10Rows14ColumnsGivenNotWonGameIfIsNotWonYet()
		{
			Assert.IsFalse(game10Rows14ColumnsWithNotWonRaster.isWon());
		}

        [TestMethod]
        public void TestGivenVerticalWonGameIfIsWon() {
            Assert.IsTrue(gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.isWonVertical() == 1);
        }
     
        [TestMethod]
        public void Test10Rows14ColumnsGivenVerticalWonGameIfIsWon() {
            Assert.IsTrue(game10Rows14ColumnsWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.isWonVertical() == 1);
        }

		[TestMethod]
		public void TestGivenHorizontalWonGameIfIsWon() {
			Assert.IsTrue(gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.isWonHorizontal() == 1);
		}

        [TestMethod]
        public void Test10Rows14ColumnsGivenHorizontalWonGameIfIsWon()
        {
            Assert.IsTrue(game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.isWonHorizontal() ==1);
        }
        
        [TestMethod]
        public void TestGiven45DegreeWonGameIfIsWon() {
            Assert.IsTrue(gameWith45DegreeStartingAtColumn0Row0WonRaster.isWonDiagonal() == 1);
			Assert.IsTrue(gameWith45DegreeStartingAtColumn0Row1WonRaster.isWonDiagonal() == 2);
			Assert.IsTrue(gameWithout45Degree.isWonDiagonal() == 0);
        }

        [TestMethod]
        public void Test10Rows14ColumnsGiven45DegreeWonGameIfIsWon()
        {
            Assert.IsTrue(game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.isWonDiagonal() == 1);
            Assert.IsTrue(game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.isWonDiagonal() == 2);
        }

        [TestMethod]
        public void TestGame10Rows14ColumnsGetRowsColumnsAndStreak()
        {
            Assert.IsTrue(game10Rows14Columns.getRows() == 10);
            Assert.IsTrue(game10Rows14Columns.getColumns() == 14);
            Assert.IsTrue(game10Rows14Columns.getStreakToWin() == 4);
        }

        [TestMethod]
        public void TestGame10Rows14Columns6StreakGetRowsColumnsAndStreak()
        {
            Assert.IsTrue(game10Rows14Columns6Streak.getRows() == 10);
            Assert.IsTrue(game10Rows14Columns6Streak.getColumns() == 14);
            Assert.IsTrue(game10Rows14Columns6Streak.getStreakToWin() == 6);
        }

		[TestMethod]
		public void TestIsRasterFullWhenRasterIsFull() {
			Assert.IsTrue(gameWithFullRaster.rasterIsFull());
		}

		[TestMethod]
		public void Test10Rows14ColumnsIsRasterFullWhenRasterIsFull() {
			Assert.IsTrue(game10Rows14ColumnsWithFullRaster.rasterIsFull());
		}

        [TestMethod]
        public void TestInsertTokenInRasterInFullColumn() {
            gameWithFullRaster.insertToken(0, 1);
        }

        [TestMethod]
        public void Test10Rows14ColumnsInsertTokenInRasterInFullColumn()
        {
            game10Rows14ColumnsWithFullRaster.insertToken(0, 1);
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
			Assert.IsTrue(gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.getWinnerOfLastGame() == 1);
		}

		[TestMethod]
		public void Test10Rows14ColumnsClearRaster() {
			game10Rows14ColumnsWithFullRaster.clearRaster();
			Assert.IsTrue(game10Rows14ColumnsWithFullRaster.isRasterInitializedWithZeros());
			game.insertToken(0, 1);
			Assert.IsFalse(game.isRasterInitializedWithZeros());
		}

        [TestMethod]
        public void TestInsertTokenByUserAndThenByAIAndThenByUserAndCheckIfTurnsAreRespected()
        {
            gameInterface.newGame();


            Assert.IsTrue(gameInterface.checkIfWon(2, 1));
            Assert.IsFalse(gameInterface.checkIfWon(2, 1));

            Assert.IsTrue(gameInterface.insertTokenByAI());
            Assert.IsFalse(gameInterface.insertTokenByAI());

            Assert.IsTrue(gameInterface.checkIfWon(2, 1));
        }

        [TestMethod]
        public void TestNewGameStarted()
        {
            gameInterface.newGame();
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestGetScorePlayer1()
        {
            gameInterface.incrementScorePlayer(1);
            // Parameter == player number
            Assert.IsTrue(gameInterface.getScore(1) == 1);
        }

        [TestMethod]
        public void TestGetOverallWonPlayer()
        {
            game.incrementScorePlayer(1);
            game.incrementScorePlayer(2);
            // Parameter == player number
            Assert.IsTrue(game.getWinnerOfLastSession() == 0);
            game.incrementScorePlayer(1);
            Assert.IsTrue(game.getWinnerOfLastSession() == 1);
            game.incrementScorePlayer(2);
            game.incrementScorePlayer(2);
            Assert.IsTrue(gameInterface.getWinnerOfLastSession() == 2);
        }

        [TestMethod]
        public void TestNewGame2HumanPlayersWith10RowsAnd14Columns()
        {
            game.newGame();
            Assert.IsTrue(gameInterface10Rows14Columns.gameRunning());
        }

        [TestMethod]
        public void TestNewGameWith10Rows14ColumnsAnd5Streak()
        {
            gameInterface10Rows14Columns5Streak.newGame();
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestNewGameWith10RowsAnd14Columns()
        {
            gameInterface10Rows14Columns.newGame();
            Assert.IsTrue(gameInterface.gameRunning());
        }

        [TestMethod]
        public void TestCurrentGameWon()
        {
            gameInterface.newGame();

            Assert.IsTrue(gameInterface.isCurrentGameWon() == false);

            gameInterface.checkIfWon(1, 1);
            gameInterface.checkIfWon(2, 2);

            gameInterface.checkIfWon(1, 1);
            gameInterface.checkIfWon(3, 2);

            gameInterface.checkIfWon(1, 1);
            gameInterface.checkIfWon(4, 2);

            gameInterface.checkIfWon(1, 1);

            Assert.IsTrue(gameInterface.isCurrentGameWon() == true);

        }

        [TestMethod]
        public void TestGetPlayerAtPlay()
        {
            // Parameter == player number
            Assert.IsTrue(gameInterface.getPlayerAtPlay() == 1);
        }

        [TestMethod]
        public void TestInsertTokenInColumn2ByPlayer1()
        {
            gameInterface.newGame();

            // insertToken returns true if token is successfully inserted
            Assert.IsTrue(gameInterface.checkIfWon(2, 1));
            // return false if it is not his turn
            Assert.IsTrue(gameInterface.checkIfWon(2, 2));
        }
    }
}