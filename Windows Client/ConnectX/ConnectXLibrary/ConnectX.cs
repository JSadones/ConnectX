using System;
using System.Linq;
using System.Collections.Generic;

namespace ConnectXLibrary
{
    public class ConnectX
    {
        #region State
        int[,] raster;
        private int rows, columns, streakToWin, playerAtTurn, scorePlayer1 = 0, scorePlayer2 = 0, difficulty;
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
        }//getPlayerAtTurn

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
        //===Methods for raster===
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

        public bool insertToken(int column, int row, int player)
        {
            if (!isColumnFull(column))
            {
                if (selectLowestAvailableRow(column) != -1)
                {
                    raster[row, column] = player;
                }
                return true;
            }
            else return false;
        }//insertToken



        //===Checks for raster===
        private bool isColumnFull(int column)
        {
            if (raster[rows - 1, column] != 0)
            {
                return true;
            }
            else return false;
        }//isColumnFull

        public int selectLowestAvailableRow(int column)
        {
            if (!isColumnFull(column))
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
        }//selectLowestAvailableRow


        //===Winning algorithm===
        private bool checkWinner(int row, int column, int stepRow, int stepColumn)
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
        }//checkWinner

        public bool checkWinnerAllDirections(int row, int column)
        {
            if (checkWinner(row, column, 0, 1) || checkWinner(row, column, 0, -1) || checkWinner(row, column, -1, 0) || checkWinner(row, column, -1, 1) || checkWinner(row, column, -1, -1)) return true;
            else return false;
        }//checkWinnerAllDirections


        //===AI Methods===
        public int chooseRandomSpot()
        {
            List<byte> emptySpots;
            Random rnd = new Random();
            emptySpots = selectAllAvailableColumns();
            int length = emptySpots.Count;
            int spot = rnd.Next(0, length);

            return spot;
        }//chooseRandomSpot

        private List<byte> selectAllAvailableColumns()
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
        }//selectAllAvailableColumns


        //===Score Methods===
        public void incrementScorePlayer(int player)
        {
            if (player == 1) scorePlayer1++;
            else scorePlayer2++;
        }//incrementScorePlayer


        //===Other Methods===
        public void newGame()
        {
            clearRaster();
            playerAtTurn = 1;
        }//nextGame

        public void switchPlayerAtTurn()
        {
            if (playerAtTurn == 1) playerAtTurn = 2;
            else playerAtTurn = 1;
        }//switchPlayerAtTurn
        #endregion
    }
}