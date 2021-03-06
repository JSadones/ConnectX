﻿using System;

namespace ConnectXLibrary
{
    public class ConnectX
    {
        #region State
        int[,] raster;
        private int rows, columns, streakToWin, playerAtTurn, scorePlayer1 = 0, scorePlayer2 = 0;
		private const int DefaultRows = 6, DefaultColumns = 7, DefaultStreak = 4;
        private const bool  DefaultMP = true;
        private bool multiplayerON;
        private byte NOBODY = 0, PLAYER1 = 1, PLAYER2 = 2;

        int[] columnCounts;
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
            this.multiplayerON = multiplayer;

            playerAtTurn = 1;
            raster = new int[columns, rows];

            this.columnCounts = new int[columns];
        }
        #endregion

        #region Properties
        public int getRows()
        {
            return rows;
        }//getRows

        public int getColumns()
        {
            return columns;
        }//getColumns

        public int getStreakToWin()
        {
            return streakToWin;
        }//getStreakToWin

		public static int GetDefaultRows()
        {
			return DefaultRows;
		}//GetDefaultRows

		public static int GetDefaultColumns()
        {
			return DefaultColumns;
		}//GetDefaultColumns

		public static int GetDefaultStreakToWin()
        {
			return DefaultStreak;
		}//GetDefaultStreakToWin

        public int getLowestAvailableRowInColumn(int column)
        {
            if (!isColumnFull(column))
            {
                int row = 0;
                while (row < rows)
                {
                    if (raster[column, row] == 0) return row;
                    row++;
                }
                return rows;
            }
            else return -1;
        }//getLowestAvailableRow

        public int getPlayerAtTurn()
        {
            return playerAtTurn;
        }//getPlayerAtTurn

        public int getToken(int row, int column)
        {
            return raster[column, row];
        }//getToken

        public int getWinnerOfLastSession()
        {
            if (scorePlayer1 > scorePlayer2) return 1;
            else if (scorePlayer1 < scorePlayer2) return 2;
            else return 0;
        }//getWinnerOfLastSession

        public int getScore(int player)
        {
            if (player == 1)
            {
                return scorePlayer1;
            }
            else return scorePlayer2;
        }//getScore

        public int[,] getRaster()
        {
            return raster;
        }//getRaster
		#endregion

        #region Methods
        //===Methods for raster===
        public bool isTie()
        {
            for (int column = 0; column < columns; column++)
            {
                if (raster[column, rows - 1] == 0) return false;
            }
            return true;
        }//isTie

        public void clear()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    raster[column, row] = NOBODY;
                }
            }

            for (int column = 0; column < columns; column++)
            {
                columnCounts[column] = NOBODY;
            }
        }//clear

        public bool isInitializedWithZeros()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (raster[column, row] != NOBODY) return false;
                }
            }
            return true;
        }//isInitializedWithZeros

        public bool insertToken(int column, int row, int player)
        {
            columnCounts[column]++;
            raster[column, row] = player;
            return true;
        }//insertToken

        public bool undoMovePlayer(int column)
        {
            return undoMove(column, true);
        }//undoMovePlayer

        public bool undoMoveAI(int column)
        {
            return undoMove(column, false);
        }//undoMoveAI

        private bool undoMove(int column, bool player)
        {
            if (columnCounts[column] > 0)
            {
                byte sign = player ? PLAYER1 : PLAYER2;
                if (raster[column, columnCounts[column] - 1] == sign)
                {
                    raster[column, columnCounts[column] - 1] = NOBODY;
                    columnCounts[column]--;
                    return true;
                }
            }
            return false;
        }//undoMove

        public bool isColumnFull(int column)
        {
            return raster[column, rows - 1] != NOBODY;
        }//isColumnFull


        //===Winning algorithm methods===
        //private void resetCounter()
        //{
        //    counterLeft = 0;
        //    counterRight = 0;
        //}//resetCounter

        //private bool isStreakReachedFromCoordinateInDirection(int column, int row, int stepRow, int stepColumn, int player)
        //{
        //    for (int i = 1; i < streakToWin; i++)
        //    {
        //        try
        //        {
        //            if (raster[column + i * stepColumn, row + i * stepRow] == player)
        //            {
        //                if ((stepRow == -1 && stepColumn == 0) || (stepRow == 0 && stepColumn == -1) || (stepRow == -1 && stepColumn == -1) || (stepRow == 1 && stepColumn == 1))
        //                    counterLeft++;
        //                else if ((stepRow == 0 && stepColumn == 1) || (stepRow == -1 && stepColumn == 1) || (stepRow == 1 && stepColumn == -1))
        //                    counterRight++;
        //                else return false;
        //            }
        //            else return false;
                    
        //        }
        //        catch(IndexOutOfRangeException)
        //        {
        //            return false;
        //        }

        //        if (counterLeft + counterRight == streakToWin - 1)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}//isStreakReachedFromCoordinateInDirection

        //public bool isCurrentGameWon(int column, int row, int player)
        //{
        //    if (player == 0) player = playerAtTurn;

        //    //-1  0   --  Check vertical down

        //    //0   1   --  Check horizontal right
        //    //0  -1   --  Check horizontal left

        //    //-1  1   --  Check diagonal bottom to right
        //    //1  -1    --  Check diagonal top to right

        //    //1  1   --  Check diagonal top to left
        //    //-1 -1   --  Check diagonal bottom to left

        //    //Check left and right
        //    if (isStreakReachedFromCoordinateInDirection(column, row, 0, 1, player) || isStreakReachedFromCoordinateInDirection(column, row, 0, -1, player)) return true;
        //    else resetCounter();

        //    //Check vertical
        //    if (isStreakReachedFromCoordinateInDirection(column, row, -1, 0, player)) return true;
        //    else resetCounter();

        //    //Check diagonal bottom to right and diagonal top to left 
        //    if (isStreakReachedFromCoordinateInDirection(column, row, -1, 1, player) || isStreakReachedFromCoordinateInDirection(column, row, 1, -1, player)) return true;
        //    else resetCounter();

        //    //Check diagonal bottom to left and diagonal top to right
        //    if (isStreakReachedFromCoordinateInDirection(column, row, -1, -1, player) || isStreakReachedFromCoordinateInDirection(column, row, 1, 1, player)) return true;
        //    else resetCounter();
        //    return false;
        //}//isCurrentGameWon

        public byte getWinner()
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y <= rows - streakToWin; y++)
                {
                    bool playerWin = true;
                    bool aiWin = true;
                    for (int o = 0; o < streakToWin; o++)
                    {
                        if (playerWin && raster[x, y + o] != PLAYER1) playerWin = false;
                        if (aiWin && raster[x, y + o] != PLAYER2) aiWin = false;
                    }

                    if (playerWin) return PLAYER1;
                    else if (aiWin) return PLAYER2;
                }
            }

            for (int x = 0; x <= columns - streakToWin; x++)
            {
                for (int y = 0; y <= rows - streakToWin; y++)
                {
                    bool playerWin = true;
                    bool aiWin = true;
                    for (int o = 0; o < streakToWin; o++)
                    {
                        if (playerWin && raster[x + o, y + o] != PLAYER1) playerWin = false;
                        if (aiWin && raster[x + o, y + o] != PLAYER2) aiWin = false;
                    }

                    if (playerWin) return PLAYER1;
                    else if (aiWin) return PLAYER2;
                }
            }

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x <= columns - streakToWin; x++)
                {
                    bool playerWin = true;
                    bool aiWin = true;
                    for (int o = 0; o < streakToWin; o++)
                    {
                        if (playerWin && raster[x + o, y] != PLAYER1) playerWin = false;
                        if (aiWin && raster[x + o, y] != PLAYER2) aiWin = false;
                    }

                    if (playerWin) return PLAYER1;
                    else if (aiWin) return PLAYER2;
                }
            }

            for (int x = columns - 1; x >= streakToWin - 1; x--)
            {
                for (int y = 0; y <= rows - streakToWin; y++)
                {
                    bool playerWin = true;
                    bool aiWin = true;
                    for (int o = 0; o < streakToWin; o++)
                    {
                        if (playerWin && raster[x - o, y + o] != PLAYER1) playerWin = false;
                        if (aiWin && raster[x - o, y + o] != PLAYER2) aiWin = false;
                    }

                    if (playerWin) return PLAYER1;
                    else if (aiWin) return PLAYER2;
                }
            }

            return NOBODY;
        }//getWinner

        public bool playerIsWinner()
        {
            return getWinner() == PLAYER1;
        }//playerIsWinner

        public bool hasWinner()
        {
            return getWinner() != NOBODY;
        }//hasWinner

        
        //===Score Methods===
        public void incrementScoreOfPlayer(int player)
        {
            if (player == 1) scorePlayer1++;
            else scorePlayer2++;
        }//incrementScoreOfPlayer
        

        //===Other Methods===
        public bool nextGame()
        {
            clear();
            playerAtTurn = PLAYER1;
            //resetCounter();
            return true;
        }//nextGame

        public void switchPlayerAtTurn()
        {
            if (playerAtTurn == PLAYER1) playerAtTurn = PLAYER2;
            else playerAtTurn = PLAYER1;
        }//switchPlayerAtTurn
        #endregion
    }
}