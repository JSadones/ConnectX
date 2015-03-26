﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public class ConnectX
    {
        #region State
        private int[,] raster;
        private int rows;
        private int columns;
        private int tokenStreak;
		private int playerAtTurn;
        private int winningPlayer;
		private static int defaultRows = 6;
		private static int defaultColumns = 7;
		private static int defaultStreak = 4;
        #endregion State

        #region Constructor
        public ConnectX(): this(defaultRows, defaultColumns, defaultStreak) {
        }

        public ConnectX(int rows, int columns): this (rows, columns, defaultStreak) {
        }

        public ConnectX(int rows, int columns, int tokenStreak) {
            this.rows = rows;
            this.columns = columns;
            this.tokenStreak = tokenStreak;
            playerAtTurn = 1;

            raster = new int[rows, columns];
            clearRaster();
        }
        #endregion

        #region Properties
        public int getRows() {
            return rows;
        }

        public int getColumns() {
            return columns;
        }

        public int getStreakToReach() {
            return tokenStreak;
        }

        public int[,] getRaster() {
            return raster;
        }

		public static int GetDefaultNumberOfRows()
		{
			return defaultRows;
		}

		public static int GetDefaultNumberOfColumns()
		{
			return defaultColumns;
		}

		public static int GetDefaultStreak()
		{
			return defaultStreak;
		}
		
		#endregion

        #region Methods
        public bool exists() {
            return true;
        }

        public bool rasterExists() {
            return true;
        }

        public bool isRasterInitializedWithZeros() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (raster[i, j] != 0) {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool isWon() {
			if (isWonVertical() || isWonDiagonal45() || isWonDiagonal135() || isWonHorizontal()) {
                return true;
            }
            return false;
        }

        public bool isWonVertical() {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;

            for (int i = 0; i < columns; i++) {

                int j = 0;
                counterPlayer1 = 0;
                counterPlayer2 = 0;

                while (j < rows && raster[j,i] != 0) {

                   
                    if (raster[j, i] == 1) {
                        counterPlayer1++;
                    } else counterPlayer1 = 0;
                    
                    if (raster[j, i] == 2) {
                        counterPlayer2++;
                    } else counterPlayer2 = 0;

                    if (counterPlayer1 == tokenStreak) {
                        winningPlayer = 1;
                        return true;
                    }

                    if (counterPlayer2 == tokenStreak) {
                        winningPlayer = 2;
                        return true;
                    }

                    j++;
                }
            }
            return false;
        }

		public bool isWonHorizontal() {
			int counterPlayer1 = 0;
			int counterPlayer2 = 0;

			for (int i = 0; i < rows; i++) {

				counterPlayer1 = 0;
				counterPlayer2 = 0;

				for (int j = 0; j < columns; j++) {

					if (raster[i, j] == 1) {
						counterPlayer1++;
					} else counterPlayer1 = 0;

					if (raster[i, j] == 2) {
						counterPlayer2++;
					} else counterPlayer2 = 0;

					if (counterPlayer1 == tokenStreak) {
                        winningPlayer = 1;
						return true;
					}

					if (counterPlayer2 == tokenStreak) {
                        winningPlayer = 2;
						return true;
					}
				}
			}
			return false;
		}

        public bool isWonDiagonal45() {

			for (int i = columns - 1; i >= 0; i--) {
                int winner = getStreakWinnerDiagonal45(0, i);
                if (1 <= winner && winner <= 2)
                {
                    winningPlayer = winner;
                    return true;
                }
                
			}

			for (int i = 1; i < rows; i++) {

                int winner = getStreakWinnerDiagonal45(i, 0);
                if (1 <= winner && winner <= 2)
                {
                    winningPlayer = winner;
                    return true;
                }
                
                
			}
			return false;
        }

        public int getStreakWinnerDiagonal45(int counterRow, int counterColumn)
        {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;
            while (counterColumn < columns && counterRow < rows)
            {
                if (raster[counterRow, counterColumn] == 1)
                {
                    counterPlayer1++;
                }
                else counterPlayer1 = 0;

                if (raster[counterRow, counterColumn] == 2)
                {
                    counterPlayer2++;
                }
                else counterPlayer2 = 0;

                counterRow++;
                counterColumn++;

                if (counterPlayer1 == tokenStreak)
                {
                    return 1;
                    
                }

                else if (counterPlayer2 == tokenStreak)
                {
                    return 2;
                    
                }
               
            }
            return 0;
        }

        public bool isWonDiagonal135()
        {

            for (int i = 0; i < columns; i++)
            {

                int winner = getStreakWinnerDiagonal135(0, i);
                if (1 <= winner && winner <= 2)
                {
                    winningPlayer = winner;
                    return true;
                }

            }

            for (int i = 1; i < rows; i++)
            {
                int winner = getStreakWinnerDiagonal135(i, columns - 1);
                if (1 <= winner && winner <= 2)
                {
                    winningPlayer = winner;
                    return true;
                }
            }
            return false;
        }

        public int getStreakWinnerDiagonal135(int counterRow, int counterColumn)
        {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;
            while (counterColumn >= 0 && counterRow < rows)
            {
                if (raster[counterRow, counterColumn] == 1)
                {
                    counterPlayer1++;
                }
                else counterPlayer1 = 0;

                if (raster[counterRow, counterColumn] == 2)
                {
                    counterPlayer2++;
                }
                else counterPlayer2 = 0;

                counterRow++;
                counterColumn--;

                if (counterPlayer1 == tokenStreak)
                {
                    return 1;
                }

                if (counterPlayer2 == tokenStreak)
                {
                    return 2;
                }
            }
            return 0;
        }

        private List<byte> checkEmptySpotInColumn() {
            List<byte> empySpots = new List<byte>();

            for (byte i = 0; i < columns; i++) {
                if (raster[rows - 1, i] == 0) {
                    empySpots.Add(i);
                }
            }
            return empySpots;
        }

        private int getRowIndexOfLowestEmptyTokenInColumn(int column) {
            int row = 0;
            while (row < rows) {
                if (raster[row, column] == 0) return row;
                row++;
            }
            return -1;
        }

        public void switchPlayerAtTurn() {
            if (playerAtTurn == 1) playerAtTurn = 2;
            else playerAtTurn = 1;
        }

        public bool insertToken(int column, int player) {
			if (1 <= player && player <= 2) {

                if (getRowIndexOfLowestEmptyTokenInColumn(column) != -1) {
                    raster[getRowIndexOfLowestEmptyTokenInColumn(column), column] = player;

                    switchPlayerAtTurn();
                }
				return true;
			}
			else return false;
        }

        public bool hasNotCrashed() {
            return false;
        }

        public bool rasterIsFull() {
            for (int i = 0; i < columns; i++) {
                if (raster[rows - 1, i] == 0) {
                    return false;
                }
            }
            return true;
        }

        public void insertTokenByAI() {
            List<byte> emptySpots;
            Random rnd = new Random();
            emptySpots = checkEmptySpotInColumn();
            int length = emptySpots.Count;
            int spot = rnd.Next(0, length);

            //TODO : Hoe weet je dat player 2 AI is? of insertToken(item) gebruiken?
            insertToken(emptySpots[spot], 2);
        }
        
        public int getCurrentGameWonPlayer() {
            return winningPlayer;
        }

        public void clearRaster() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    raster[i, j] = 0;
                }
            }
        }

		public int getPlayerAtTurn() {
			return playerAtTurn;
		}

        public bool isColumnFull(int column) {
            if (raster[rows - 1, column] != 0) {
                return true;
            }
            else { return false; }
        }

		public int getToken(int row, int column) {
			return raster[row, column];
		}
        #endregion
    }
}