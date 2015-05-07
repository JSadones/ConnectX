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
		private const int DefaultRows = 6, DefaultColumns = 7, DefaultStreak = 4;
        private const bool  DefaultMP = true;
        private bool multiplayer;
        int counterLeft = 0;
        int counterRight = 0;
        #endregion State

        #region Constructor
        public ConnectX(): this(DefaultRows, DefaultColumns, DefaultStreak, DefaultMP){ }

        public ConnectX(int rows, int columns) : this(rows, columns, DefaultStreak, DefaultMP) { }

        public ConnectX(int rows, int columns, int streak) : this(rows, columns, streak, DefaultMP) { }

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
			return DefaultRows;
		}//GetDefaultRows

		public static int GetDefaultColumns() {
			return DefaultColumns;
		}//GetDefaultColumns

		public static int GetDefaultStreakToWin() {
			return DefaultStreak;
		}//GetDefaultStreakToWin

        public int getLowestAvailableRowInColumn(int column)
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
        }//getLowestAvailableRow

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
        public bool isRasterFull()
        {
            for (int column = 0; column < columns; column++)
            {
                if (raster[rows - 1, column] == 0) return false;
            }
            return true;
        }//isRasterFull

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
                if (getLowestAvailableRowInColumn(column) != -1)
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

        //===Winning algorithm===
        private void resetCounter()
        {
            counterLeft = 0;
            counterRight = 0;
        }//resetCounter

        private bool isStreakReachedFromCoordinateInDirection(int row, int column, int stepRow, int stepColumn)
        {
            for (int i = 1; i < streakToWin; i++)
            {
                try
                {
                    //Check horizontal left && diagonal bottom to left && diagonal top to left
                    if ((stepRow == 0 && stepColumn == -1) || (stepRow == -1 && stepColumn == -1) || (stepRow == 1 && stepColumn == 1))
                    {
                        if (raster[row + i * stepRow, column + i * stepColumn] == getPlayerAtTurn()) counterLeft++;
                        else return false;
                    }
                    //Check horizontal right && diagonal bottom to right && diagonal top to right
                    else if ((stepRow == 0 && stepColumn == 1) || (stepRow == -1 && stepColumn == 1) || (stepRow == 1 && stepColumn == -1))
                    {
                        if (raster[row + i * stepRow, column + i * stepColumn] == getPlayerAtTurn()) counterRight++;
                        else return false;
                    }
                    else if (stepRow == -1 && stepColumn == 0)
                    {
                        if (raster[row + i * stepRow, column + i * stepColumn] == getPlayerAtTurn()) counterLeft++;
                        else return false;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    return false;
                }

                if (counterLeft + counterRight == streakToWin - 1) return true;
            }
            return false;
        }//isStreakReachedFromCoordinateInDirection

        public bool isCurrentGameWon (int row, int column)
        {
            //0   1   --  Check horizontal right
            //0  -1   --  Check horizontal left
            //-1  0   --  Check vertical down
            //-1  1   --  Check diagonal bottom to right
            //1  1   --  Check diagonal top to left
            //-1 -1   --  Check diagonal bottom to left
            //1  -1    --  Check diagonal top to right

            //Check left and right
            if (isStreakReachedFromCoordinateInDirection(row, column, 0, 1) || isStreakReachedFromCoordinateInDirection(row, column, 0, -1))
            {
                return true;
            }
            else
            {
                resetCounter();
            }

            //Check vertical
            if (isStreakReachedFromCoordinateInDirection(row, column, -1, 0))
            {
                return true;
            }
            else
            {
                resetCounter();
            }

            //Check diagonal bottom to right and diagonal top to left
            if (isStreakReachedFromCoordinateInDirection(row, column, -1, 1) || isStreakReachedFromCoordinateInDirection(row, column, 1, 1))
            {
                return true;
            }
            else
            {
                resetCounter();
            }

            //Check diagonal bottom to left and diagonal top to right
            if (isStreakReachedFromCoordinateInDirection(row, column, -1, -1) || isStreakReachedFromCoordinateInDirection(row, column, 1, -1))
            {
                return true;
            }
            else
            {
                resetCounter();
            }
            return false;
        }//isCurrentGameWon


        //===AI Methods===
        public int chooseRandomSpot()
        {
            List<byte> emptySpots;
            Random rnd = new Random();
            emptySpots = getListOfAvailableColumns();
            int length = emptySpots.Count;
            int spot = rnd.Next(0, length);

            return spot;
        }//chooseRandomSpot

        private List<byte> getListOfAvailableColumns()
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
        }//getListOfAvailableColumns


        //===Score Methods===
        public void incrementScoreOfPlayer(int player)
        {
            if (player == 1) scorePlayer1++;
            else scorePlayer2++;
        }//incrementScoreOfPlayer
        

        //===Other Methods===
        public bool nextGame()
        {
            clearRaster();
            playerAtTurn = 1;
            counterLeft = 0;
            counterRight = 0;
            return true;
        }//nextGame

        public void switchPlayerAtTurn()
        {
            if (playerAtTurn == 1) playerAtTurn = 2;
            else playerAtTurn = 1;
        }//switchPlayerAtTurn
        #endregion
    }
}