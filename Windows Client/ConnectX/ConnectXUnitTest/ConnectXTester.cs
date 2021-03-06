﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectXLibrary;

namespace ConnectXUnitTest
{
    [TestClass]
    public class ConnectXTester
    {
        //We kunnen tests schrijven van:
        //Alle richtingen van een check te laten doen
        //Ook bv 00X0XXX , en als laatste token laten checken via column 4 (Zodat hij goed links en rechts checkt)
        //Kijken op volle kolommen
        //Is kolom vol of leeg
        //Is er een winnaar of is er een TIE
        //undoMove en makeMove (momenteel nog)

        //nextGame checken of speler 1 wel aan de turn is
        #region State
        #region WinnerCheck
        //Vertical

        //Horizontal

        //Diagonal bottom to right

        //Diagonal bottom to left
        private ConnectX gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon;
        private ConnectX gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon;
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
        #endregion

        #region RasterState
        private ConnectX emptyGame;
        private ConnectX gameWithFullRaster;
        private ConnectX gameWithOneTokenBeforeFullRaster;
        private ConnectX game10Rows14ColumnsWithOneTokenBeforeFullRaster;
        #endregion

        private ConnectX game10Rows14Columns;
        private ConnectX game10Rows14Columns6Streak;

        private ConnectX gameInterface;
        private ConnectX gameInterface10Rows14Columns;
        private ConnectX gameInterface10Rows14Columns5Streak;
        
        
        
        private ConnectX gameMakeMoveUndoMove;

        private AI aiCopy;
        #endregion

        #region Initialize
        [TestInitialize]
        public void setup() {
            // Empty game
            emptyGame = new ConnectX();

            game10Rows14Columns = new ConnectX(10, 14);
            game10Rows14Columns6Streak = new ConnectX(10, 14, 6);
            gameMakeMoveUndoMove = new ConnectX(7, 6, 4);

            // Game in raster where 4 in a row can be found vertically
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon = new ConnectX();
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 0, 1);
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(1, 0, 1);
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(2, 0, 1);
            gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(3, 0, 1);

            // Game in raster where 4 in a row can be found vertically, and let game check if it is won
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon = new ConnectX();
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(0, 0, 1);
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(1, 0, 1);
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(2, 0, 1);
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.insertToken(3, 0, 1);
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.hasWinner();

			//Game in raster where 4 in a row can be found horizontally
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon = new ConnectX();
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 0, 1);
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(1, 0, 1);
			gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(2, 0, 1);
            gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(3, 0, 1);

            //Game in raster where 4 in a row can be found horizontally
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon = new ConnectX(10,14);
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(0, 1, 1);
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(1, 1, 1);
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(2, 1, 1);
            game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.insertToken(3, 1, 1);

			// Game in raster where diagonal 45° can be found starting from column 0 row 0
            gameWith45DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2, 1);
            gameWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 1, 1);

            // Game in raster where diagonal 45° can be found starting from column 0 row 0
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 0, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 3, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.insertToken(4, 4, 1);

			// Game in raster where diagonal 45° can be found starting from column 0 row 1
			gameWith45DegreeStartingAtColumn0Row1WonRaster = new ConnectX();
			gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(0, 1, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(0, 2, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 1, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 2, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 2, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 1, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 2, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 1, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 2, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 1, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 1, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2, 1);
            gameWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2, 1);

            // Game in raster where diagonal 45° can be found starting from column 0 row 1
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster = new ConnectX();
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(0, 1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(0, 2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(1, 2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(2, 2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 1, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2, 1);
            game10Rows14ColumnsWith45DegreeStartingAtColumn0Row1WonRaster.insertToken(3, 2, 1);

			// #####DEBUG#####
			// Game in raster without diagonal 45° where game is won anyway. 
			gameWithout45Degree = new ConnectX();
            gameWithout45Degree.insertToken(0, 1, 1);
            gameWithout45Degree.insertToken(0, 2, 1);
            gameWithout45Degree.insertToken(0, 1, 1);
            gameWithout45Degree.insertToken(0, 2, 1);
            gameWithout45Degree.insertToken(1, 2, 1);
            gameWithout45Degree.insertToken(1, 1, 1);
            gameWithout45Degree.insertToken(1, 1, 1);
            gameWithout45Degree.insertToken(1, 1, 1);
            gameWithout45Degree.insertToken(2, 1, 1);
            gameWithout45Degree.insertToken(2, 2, 1);
            gameWithout45Degree.insertToken(2, 2, 1);
            gameWithout45Degree.insertToken(2, 2, 1);
            gameWithout45Degree.insertToken(2, 1, 1);
            gameWithout45Degree.insertToken(3, 2, 1);
            gameWithout45Degree.insertToken(3, 1, 1);
            gameWithout45Degree.insertToken(3, 1, 1);
            gameWithout45Degree.insertToken(3, 2, 1);
            gameWithout45Degree.insertToken(4, 1, 1);
            gameWithout45Degree.insertToken(4, 2, 1);
            gameWithout45Degree.insertToken(4, 2, 1);
            gameWithout45Degree.insertToken(4, 1, 1);
            gameWithout45Degree.insertToken(5, 2, 1);
            gameWithout45Degree.insertToken(5, 1, 1);
            gameWithout45Degree.insertToken(5, 1, 1);
            gameWithout45Degree.insertToken(5, 2, 1);
            gameWithout45Degree.insertToken(6, 1, 1);
            gameWithout45Degree.insertToken(6, 2, 1);
            gameWithout45Degree.insertToken(6, 2, 1);
            gameWithout45Degree.insertToken(6, 1, 1);

            // #####DEBUG#####
            // Game in raster without diagonal 45° where game is won anyway. 
            game10Rows14ColumnsWithout45Degree = new ConnectX();
            game10Rows14ColumnsWithout45Degree.insertToken(0, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(0, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(0, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(0, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(1, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(1, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(1, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(1, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(2, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(3, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(3, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(3, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(3, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(4, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(4, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(4, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(4, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(5, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(5, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(5, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(5, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(6, 1, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(6, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(6, 2, 1);
            game10Rows14ColumnsWithout45Degree.insertToken(6, 1, 1);

			// Game in raster where diagonal 135° can be found starting from column 0 row 0
			gameWith135DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
			gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2, 1);
            gameWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2, 1);

            // Game in raster where diagonal 135° can be found starting from column 0 row 0
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2, 1);

			// Game in raster where diagonal 135° can be found starting from column x row 1
			gameWith135DegreeStartingAtColumnXRow1WonRaster = new ConnectX();
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(6, 2, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(6, 2, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 2, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 1, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 2, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 1, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 2, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 1, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 2, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 1, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 1, 1);
            gameWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2, 1);

 
            // Game in raster where diagonal 135° can be found starting from column 0 row 0
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster = new ConnectX();
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(0, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(1, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(2, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumn0Row0WonRaster.insertToken(3, 2, 1);

            // Game in raster where diagonal 135° can be found starting from column x row 1
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster = new ConnectX();
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(6, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(6, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(5, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(4, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 1, 1);
            game10Rows14ColumnsWith135DegreeStartingAtColumnXRow1WonRaster.insertToken(3, 2, 1);

            // Game in raster where 4 in a row can almost be found (3 in a row)
            gameWithNotWonRaster = new ConnectX();
            gameWithNotWonRaster.insertToken(0, 1, 1);
            gameWithNotWonRaster.insertToken(0, 1, 1);
            gameWithNotWonRaster.insertToken(0, 1, 1);

            game10Rows14ColumnsWithNotWonRaster = new ConnectX();
            game10Rows14ColumnsWithNotWonRaster.insertToken(0, 1, 1);
            game10Rows14ColumnsWithNotWonRaster.insertToken(0, 1, 1);
            game10Rows14ColumnsWithNotWonRaster.insertToken(0, 1, 1);


            // Game with full board
            gameWithFullRaster = new ConnectX();

            for (int i = 0; i < gameWithFullRaster.getRows(); i++)
            {
                for (int j = 0; j < gameWithFullRaster.getColumns(); j++)
                {
                    gameWithFullRaster.insertToken(j, i, 1);
                }
            }

            // Game with almost full board
            gameWithOneTokenBeforeFullRaster = new ConnectX(6, 7);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(0, 5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(1, 5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(2, 5, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 0, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 1, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 2, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 3, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 4, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(3, 5, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(4, 5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 4, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(5, 5, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 0, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 1, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 2, 1);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 3, 2);
            gameWithOneTokenBeforeFullRaster.insertToken(6, 4, 1);

            game10Rows14ColumnsWithOneTokenBeforeFullRaster = new ConnectX(10, 14);

            int currentplayer = 1;

            for (int i = 0; i < game10Rows14ColumnsWithOneTokenBeforeFullRaster.getRows(); i++)
            {
                for (int j = 0; j < game10Rows14ColumnsWithOneTokenBeforeFullRaster.getColumns(); j++)
                { 
                    if (!(i == (game10Rows14ColumnsWithOneTokenBeforeFullRaster.getRows() - 1) && j == (game10Rows14ColumnsWithOneTokenBeforeFullRaster.getColumns() - 1))) {
                        game10Rows14ColumnsWithOneTokenBeforeFullRaster.insertToken(j, i, currentplayer);

                        if (currentplayer == 1) currentplayer = 2;
                        else currentplayer = 1;
                    }
                }
            }

            gameInterface = new ConnectX();
            gameInterface10Rows14Columns = new ConnectX(10, 14);
            gameInterface10Rows14Columns5Streak = new ConnectX(10, 14, 5);
        }
        #endregion

        #region TestMethods
        // Is the board really empty?
		[TestMethod]
		public void TestIsRasterInitializedWithZeros(){
			Assert.IsTrue(emptyGame.isInitializedWithZeros());
		}

		[TestMethod]
		public void Test10Rows14ColumnsIsRasterInitializedWithZeros() {
			Assert.IsTrue(game10Rows14Columns.isInitializedWithZeros());

			for (int i = 0; i < game10Rows14Columns.getColumns(); i++)
			{
				for (int j = 0; j < game10Rows14Columns.getRows(); j++)
				{
					Assert.IsTrue(game10Rows14Columns.getToken(j, i) == 0);
				}
			}
		}

		[TestMethod]
		public void TestnextGameWithParameters() {
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
			emptyGame.insertToken(0, 1, 1);
			Assert.IsFalse(emptyGame.isInitializedWithZeros());
		}

        [TestMethod]
		public void Test10Rows14ColumnsInsertTokenInRasterAndAssertThatRasterIsNotZero() {
			// Insert token for column 0 for player 1
            game10Rows14Columns.insertToken(0, 1, 1);
			Assert.IsFalse(game10Rows14Columns.isInitializedWithZeros());
        }

		[TestMethod]
		public void TestWhichPlayerPlaysCurrentTurn() {
            emptyGame.insertToken(0, 1, 1);
			Assert.IsTrue(emptyGame.getPlayerAtTurn() == 1);
		}

		[TestMethod]
		public void TestTurnByAI() {
			// Let AI Determine Spot To Put Token
            aiCopy = new AI(gameWithOneTokenBeforeFullRaster);
			int column = aiCopy.chooseRandomSpot();
            int row = gameWithOneTokenBeforeFullRaster.getLowestAvailableRowInColumn(column);
            gameWithOneTokenBeforeFullRaster.insertToken(column, row, 1);

			Assert.IsTrue(gameWithOneTokenBeforeFullRaster.isTie());
		}

        [TestMethod]
        public void Test10Rows14ColumnsTurnByAI()
        {
            aiCopy = new AI(game10Rows14ColumnsWithOneTokenBeforeFullRaster);
            int column = aiCopy.chooseRandomSpot();
            int row = game10Rows14ColumnsWithOneTokenBeforeFullRaster.getLowestAvailableRowInColumn(column);
            game10Rows14ColumnsWithOneTokenBeforeFullRaster.insertToken(column, row, 1);

            Assert.IsTrue(game10Rows14ColumnsWithOneTokenBeforeFullRaster.isTie());
        }

        [TestMethod]
        public void TestIsRasterFullWhenRasterIsNotFull()
        {
            Assert.IsFalse(gameWithOneTokenBeforeFullRaster.isTie());
        }

        [TestMethod]
        public void Test10Rows14ColumnsIsRasterFullWhenRasterIsNotFull()
        {
            Assert.IsFalse(game10Rows14ColumnsWithOneTokenBeforeFullRaster.isTie());
        }

        [TestMethod]
        public void TestGivenNotWonGameIfIsNotWonYet()
        {
            Assert.IsFalse(gameWithNotWonRaster.hasWinner());
        }

        [TestMethod]
        public void Test10Rows14ColumnsGivenNotWonGameIfIsNotWonYet()
        {
            Assert.IsFalse(game10Rows14ColumnsWithNotWonRaster.hasWinner());
        }

        [TestMethod]
        public void TestGivenVerticalWonGameIfIsWon()
        {
            Assert.IsTrue(gameWithVerticalWonRasterByPlayer1BeforeControlIfIsWon.hasWinner());
        }

        [TestMethod]
        public void TestGivenHorizontalWonGameIfIsWon()
        {
            Assert.IsTrue(gameWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.hasWinner());
        }

        [TestMethod]
        public void Test10Rows14ColumnsGivenHorizontalWonGameIfIsWon()
        {
            Assert.IsTrue(game10Rows14ColumnsWithHorizontalWonRasterByPlayer1BeforeControlIfIsWon.hasWinner());
        }

        [TestMethod]
        public void TestGiven45DegreeWonGameIfIsWon()
        {
            Assert.IsTrue(gameWith45DegreeStartingAtColumn0Row0WonRaster.hasWinner());
            //onderscheid tussen player 1 en 2 gewonnen.
        }

        [TestMethod]
        public void Test10Rows14ColumnsGiven45DegreeWonGameIfIsWon()
        {
            Assert.IsTrue(game10Rows14ColumnsWith45DegreeStartingAtColumn0Row0WonRaster.hasWinner());
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
        public void TestIsRasterFullWhenisRasterFull()
        {
            Assert.IsTrue(gameWithFullRaster.isTie());
        }


        [TestMethod]
        public void TestInsertTokenInRasterInFullColumn()
        {
           Assert.IsTrue(gameWithFullRaster.isColumnFull(0));
        }

        [TestMethod]
        public void TestClearRaster()
        {
            gameWithFullRaster.clear();
            Assert.IsTrue(gameWithFullRaster.isInitializedWithZeros());
            emptyGame.insertToken(0, 1, 1);
            Assert.IsFalse(emptyGame.isInitializedWithZeros());
        }

        [TestMethod]
        public void TestGetWinningPlayerGivenWonGame()
        {
            gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.hasWinner();
            Assert.IsTrue(gameWithVerticalWonRasterByPlayer1AfterControlIfIsWon.getWinner() == 1);
        }

        [TestMethod]
        public void TestGetScorePlayer1()
        {
            gameInterface.incrementScoreOfPlayer(1);
            // Parameter == player number
            Assert.IsTrue(gameInterface.getScore(1) == 1);
        }

        [TestMethod]
        public void TestGetOverallWonPlayer()
        {
            emptyGame.incrementScoreOfPlayer(1);
            emptyGame.incrementScoreOfPlayer(2);

            Assert.IsTrue(emptyGame.getWinnerOfLastSession() == 0);
            emptyGame.incrementScoreOfPlayer(1);
            Assert.IsTrue(emptyGame.getWinnerOfLastSession() == 1);
            emptyGame.incrementScoreOfPlayer(2);
            emptyGame.incrementScoreOfPlayer(2);
            Assert.IsTrue(emptyGame.getWinnerOfLastSession() == 2);
        }
        #endregion
    }
}