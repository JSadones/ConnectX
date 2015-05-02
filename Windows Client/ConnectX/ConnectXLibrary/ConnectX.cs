using System;
using System.Linq;
using System.Collections.Generic;

namespace ConnectXLibrary
{
    public class ConnectX
    {
        #region State
        int[,] raster;
        private int rows, columns, streakToWin, playerAtTurn, scorePlayer1 = 0, scorePlayer2 = 0;
		private static int defaultRows = 6, defaultColumns = 7, defaultStreak = 4;
        private static bool  defaultMP = true;
        private bool multiplayer;
        #endregion State

        #region Constructor
        public ConnectX(): this(defaultRows, defaultColumns, defaultStreak, defaultMP){ }

        public ConnectX(int rows, int columns) : this(rows, columns, defaultStreak, defaultMP) { }

        public ConnectX(int rows, int columns, int streakToWin, bool multiplayer)
        {
            this.rows = rows;
            this.columns = columns;
            this.streakToWin = streakToWin;
            this.multiplayer = multiplayer;

            playerAtTurn = 1;
            raster = new int[rows, columns];
        }
        #endregion

        #region Properties
        public int getRows() {
            return rows;
        }//getRows

        public int getColumns() {
            return columns;
        }//getColumns

        public int getStreakToWin() {
            return streakToWin;
        }//getStreakToWin

		public static int GetDefaultRows() {
			return defaultRows;
		}//GetDefaultRows

		public static int GetDefaultColumns() {
			return defaultColumns;
		}//GetDefaultColumns

		public static int GetDefaultStreakToWin() {
			return defaultStreak;
		}//GetDefaultStreakToWin

        public int getRowIndexOfLowestEmptyTokenInColumn(int column)
        {
            int row = 0;
            while (row < rows)
            {
                if (raster[row, column] == 0) return row;
                row++;
            }
            return -1;
        }//getRowIndexOfLowestEmptyTokenInColumn

        public int getRowIndexOfHighestTokenInColumn(int column)
        {
            int row = 0;
            while (row < rows)
            {
                if (raster[row, column] == 0) return row - 1;
                if (row == rows - 1 ) return row ;
                row++;
            }


            return -1;
        }//getRowIndexOfHighestTokenInColumn

        public int getPlayerAtTurn()
        {
            return playerAtTurn;
        }

        public int getToken(int row, int column)
        {
            return raster[row, column];
        }//getToken

        public int getWinnerOfLastSession()
        {
            if (scorePlayer1 > scorePlayer2)
            {
                return 1;
            }
            else if (scorePlayer1 < scorePlayer2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }//getOverallWonPlayer

        public int getScore(int player)
        {
            if (player == 1)
            {
                return scorePlayer1;
            }
            else return scorePlayer2;
        }//getScore
		#endregion

        #region Methods
        //Methods for raster
        public bool rasterIsFull()
        {
            for (int column = 0; column < columns; column++)
            {
                if (raster[rows - 1, column] == 0) return false;
            }
            return true;
        }//rasterIsFull

        public void clearRaster()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    raster[row, column] = 0;
                }
            }
        }//clearRaster

        public bool isRasterInitializedWithZeros()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (raster[row, column] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }//isRasterInitializedWithZeros


        //Winning algorithm
        private bool isLinearMatch(int row, int column, int stepRow, int stepColumn)
        {
            int counter = 0;
            for (int i = 1; i < streakToWin; i++)
            {
                try
                {
                    if (raster[row + i * stepRow, column + i * stepColumn] == getPlayerAtTurn()) counter++;
                    else return false;
                }
                catch(IndexOutOfRangeException)
                {
                    return false;
                }

                if (counter == streakToWin - 1) return true;
            }
            return false;
        }

        public bool isLineStartingAt(int row, int column)
        {
            if (isLinearMatch(row, column, 0, 1) || isLinearMatch(row, column, 0, -1) || isLinearMatch(row, column, -1, 0) || isLinearMatch(row, column, -1, 1) || isLinearMatch(row, column, -1, -1)) return true;
            else return false;
        }


        public bool gameExists()
        {
            if (raster != null)
            {
                return true;
            }
            return false;
        }//exists

        private List<byte> checkEmptySpotInColumn()
        {
            List<byte> empySpots = new List<byte>();

            for (byte i = 0; i < columns; i++)
            {
                if (raster[rows - 1, i] == 0)
                {
                    empySpots.Add(i);
                }
            }
            return empySpots;
        }//checkEmptySpotInColumn

        public void switchPlayerAtTurn()
        {
            if (playerAtTurn == 1) playerAtTurn = 2;
            else playerAtTurn = 1;
        }//switchPlayerAtTurn

        public bool insertToken(int column, int player)
        {
            if (1 <= player && player <= 2)
            {
                if (getRowIndexOfLowestEmptyTokenInColumn(column) != -1)
                {
                    raster[getRowIndexOfLowestEmptyTokenInColumn(column), column] = player;
                }
                return true;
            }
            else return false;
        }//insertToken

        public int chooseRandomSpot()
        {
            List<byte> emptySpots;
            Random rnd = new Random();
            emptySpots = checkEmptySpotInColumn();
            int length = emptySpots.Count;
            int spot = rnd.Next(0, length);

            return spot;
        }//chooseRandomSpot

        private bool isColumnFull(int column)
        {
            if (raster[rows - 1, column] != 0)
            {
                return true;
            }
            else return false;
        }//isColumnFull

        public void incrementScorePlayer(int player)
        {
            if (player == 1) scorePlayer1++;
            else scorePlayer2++;
        }//incrementScorePlayer

        public int checkIfColumnHasEmptySpot(int column)
        {
            if (isColumnFull(column) == false)
            {
                int row = 0;
                while (row < rows)
                {
                    if (raster[row, column] == 0) return row;
                    row++;
                }
                return rows;
            }
            else return -1;
        }//checkIfColumnHasEmptySpot

        public void nextGame()
        {
            clearRaster();
            playerAtTurn = 1;
        }//nextGame
        #endregion
    }
}