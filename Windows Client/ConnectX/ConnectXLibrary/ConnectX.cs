using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public class ConnectX
    {
        #region State
        private int[,] raster;
        private int rows, columns, tokenStreak, playerAtTurn, winningPlayer;
		private static int defaultRows = 6, defaultColumns = 7, defaultStreak = 4;
        private int scorePlayer1, scorePlayer2 = 0;
        private int counterPlayer1, counterPlayer2;
        private int counter;
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
        }//getRows

        public int getColumns() {
            return columns;
        }//getColumns

        public int getStreakToReach() {
            return tokenStreak;
        }//getStreakToReach

        public int[,] getRaster() {
            return raster;
        }//getRaster

		public static int GetDefaultNumberOfRows() {
			return defaultRows;
		}//GetDefaultNumberOfRows

		public static int GetDefaultNumberOfColumns() {
			return defaultColumns;
		}//GetDefaultNumberOfColumns

		public static int GetDefaultStreak() {
			return defaultStreak;
		}//GetDefaultStreak

        public int getCurrentGameWonPlayer()
        {
            return winningPlayer;
        }//getCurrentGameWonPlayer

        private int getStreakWinnerDiagonal135(int counterRow, int counterColumn)
        {
            resetCounter();
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
        }//getStreakWinnerDiagonal135

        private int getStreakWinnerDiagonal45(int counterRow, int counterColumn)
        {
            resetCounter();
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
        }//getStreakWinnerDiagonal45

        private int getRowIndexOfLowestEmptyTokenInColumn(int column)
        {
            int row = 0;
            while (row < rows)
            {
                if (raster[row, column] == 0) return row;
                row++;
            }
            return -1;
        }//getRowIndexOfLowestEmptyTokenInColumn

        public int getPlayerAtTurn()
        {
            return playerAtTurn;
        }//getPlayerAtTurn

        public int getToken(int row, int column)
        {
            return raster[row, column];
        }//getToken
        
        public int getColumnWithVerticalLongestStreakOfAI()
        {
            int longestStreak = 0;
            int longestStreakColumn = -1;

            for (int i = 0; i < columns; i++)
            {
                int j = 0;
                resetStreakCounter();

                while (j < rows && raster[j, i] != 0)
                {
                    if (raster[j, i] == 2)
                    {
                        counter++;
                    }
                    else counter = 0;
                    j++;
                }

                if (counter > longestStreak)
                {
                    longestStreak = counter;
                    longestStreakColumn = i;
                }
            }
            return longestStreakColumn;
        }//getColumnWithVerticalLongestStreakOfAI

        public int getRowWithHorizontalLongestStreakOfAI()
        {

            for (int i = 0; i < rows; i++)
            {

                resetStreakCounter();
                int longestStreak = 0;
                int longestStreakRow = -1;

                for (int j = 0; j < columns; j++)
                {

                    if (raster[i, j] == 2)
                    {
                        counter++;
                    }
                    else counter = 0;
                    j++;

                    if (counter > longestStreak)
                    {
                        longestStreak = counter;
                        longestStreakRow = i;
                    }

                    if (counter == tokenStreak)
                    {
                        return counter;
                    }
                }
            }
            return 0;
        }//getRowWithHorizontalLongestStreakOfAI

        public Coord getCoordinateWithDiagonal45LongestStreakOfAI()
        {
            Coord coordinate = new Coord(0,0);

            int currentStreak = 0;
            int longestStreakByAI = 0;
            int counterColumn = 0;
            int counterRow = 0;

            for (int i = columns - 1; i >= 0; i--)
            {
                while (counterColumn < columns && counterRow < rows)
                {
                    if (raster[counterRow, counterColumn] == 2)
                    {
                        currentStreak++;
                        if (currentStreak > longestStreakByAI) {
                            longestStreakByAI = currentStreak;
                            coordinate.setRow(counterRow);
                            coordinate.setColumn(counterColumn);
                        }
                    }
                    else currentStreak = 0;

                    counterRow++;
                    counterColumn++;
                }
            }

           
            for (int i = 1; i < rows; i++)
            {
                while (counterColumn < columns && counterRow < rows)
                {
                    if (raster[counterRow, counterColumn] == 2)
                    {
                        currentStreak++;
                        if (currentStreak > longestStreakByAI)
                        {
                            longestStreakByAI = currentStreak;
                            coordinate.setRow(counterRow);
                            coordinate.setColumn(counterColumn);
                        }
                    }
                    else currentStreak = 0;

                    counterRow++;
                    counterColumn++;
                }
            }

            return coordinate;


        }//getCoordinateWithDiagonal45LongestStreakOfAI

        public Coord getCoordinateWithDiagonal135LongestStreakOfAI()
        {
            Coord coordinate = new Coord(0, 0);

            int currentStreak = 0;
            int longestStreakByAI = 0;
            int counterColumn = 0;
            int counterRow = 0;

            for (int i = 0; i < columns; i++)
            {
                counterColumn = i;
                counterRow = 0;
                while (counterColumn >= 0 && counterRow < rows)
                {
                    if (raster[counterRow, counterColumn] == 2)
                    {
                        currentStreak++;
                        if (currentStreak > longestStreakByAI)
                        {
                            longestStreakByAI = currentStreak;
                            coordinate.setRow(counterRow);
                            coordinate.setColumn(counterColumn);
                        }
                    }
                    else currentStreak = 0;

                    counterRow++;
                    counterColumn--;
                }
            }

            for (int i = 1; i < rows; i++)
            {
                counterColumn = columns - 1;
                counterRow = i;
                while (counterColumn >= 0 && counterRow < rows)
                {
                    if (raster[counterRow, counterColumn] == 2)
                    {
                        currentStreak++;
                        if (currentStreak > longestStreakByAI)
                        {
                            longestStreakByAI = currentStreak;
                            coordinate.setRow(counterRow);
                            coordinate.setColumn(counterColumn);
                        }
                    }
                    else currentStreak = 0;

                    counterRow++;
                    counterColumn--;
                }
            }
            return coordinate;
        }//getCoordinateWithDiagonal135LongestStreakOfAI

        public int getOverallWonPlayer()
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
        public bool exists()
        {
            if (raster != null) {
                return true;
            }
            return false;
        }//exists

        public bool isRasterInitializedWithZeros()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (raster[i, j] != 0) {
                        return false;
                    }
                }
            }
            return true;
        }//isRasterInitializedWithZeros

        public void resetCounter()
        {
            counterPlayer1 = 0;
            counterPlayer2 = 0;
        }
        public void resetStreakCounter()
        {
            counter = 0;
        }

        public bool isWon()
        {
            if (isWonVertical() == 1 || isWonHorizontal() == 1 || isWonDiagonal45() ==1 || isWonDiagonal135() == 1)
            {
                winningPlayer = 1;
                return true;
            } else if (isWonVertical() == 2 || isWonHorizontal() == 2 || isWonDiagonal45() == 2 || isWonDiagonal135() == 2)
            {
                winningPlayer = 2;
                return true;
            }
            return false;
        }//isWon

        public int isWonVertical()
        {
            for (int i = 0; i < columns; i++)
            {
                int j = 0;
                resetCounter();
                while (j < rows && raster[j,i] != 0)
                {
                    if (raster[j, i] == 1)
                    {
                        counterPlayer1++;
                    }
                    else counterPlayer1 = 0;
                    
                    if (raster[j, i] == 2)
                    {
                        counterPlayer2++;
                    }
                    else counterPlayer2 = 0;

                    if (counterPlayer1 == tokenStreak)
                    {
                        return 1;
                    }
                    if (counterPlayer2 == tokenStreak)
                    {
                        return 2;
                    }
                    j++;
                }
            }
            return 0;
        }//isWonVertical

		public int isWonHorizontal() {

			for (int i = 0; i < rows; i++)
            {
                resetCounter();
				for (int j = 0; j < columns; j++)
                {

					if (raster[i, j] == 1)
                    {
						counterPlayer1++;
					} else counterPlayer1 = 0;

					if (raster[i, j] == 2)
                    {
						counterPlayer2++;
					} else counterPlayer2 = 0;

					if (counterPlayer1 == tokenStreak)
                    {
                        return 1;
					}

					if (counterPlayer2 == tokenStreak)
                    {
                        return 2;
					}
				}
			}
            return 0;
		}//isWonHorizontal

        public int isWonDiagonal45()
        {
			for (int i = columns - 1; i >= 0; i--) {
                int winner = getStreakWinnerDiagonal45(0, i);
                if (1 <= winner && winner <= 2)
                {
                    return winner;
                }
			}
			for (int i = 1; i < rows; i++)
            {
                int winner = getStreakWinnerDiagonal45(i, 0);
                if (1 <= winner && winner <= 2)
                {
                    return winner;
                }
			}
			return 0;
        }//isWonDiagonal45

        public int isWonDiagonal135()
        {
            for (int i = 0; i < columns; i++)
            {
                int winner = getStreakWinnerDiagonal135(0, i);
                if (1 <= winner && winner <= 2)
                {
                    return winner;
                }
            }

            for (int i = 1; i < rows; i++)
            {
                int winner = getStreakWinnerDiagonal135(i, columns - 1);
                if (1 <= winner && winner <= 2)
                {
                    return winner;
                }
            }
            return 0;
        }//isWonDiagonal135

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
                    switchPlayerAtTurn();
                }
				return true;
			}
			else return false;
        }//insertToken

        public bool rasterIsFull()
        {
            for (int i = 0; i < columns; i++)
            {
                if (raster[rows - 1, i] == 0) return false;
            }
            return true;
        }//rasterIsFull

        public bool insertTokenByAI() {
            List<byte> emptySpots;
            Random rnd = new Random();
            emptySpots = checkEmptySpotInColumn();
            int length = emptySpots.Count;
            int spot = rnd.Next(0, length);
 
            if (playerAtTurn == 2)
            {
                // Bruikbare functies:
                // getCoordinateWithDiagonal135LongestStreakOfAI();
                // getCoordinateWithDiagonal45LongestStreakOfAI();
                // getColumnWithVerticalLongestStreakOfAI();
                // getRowWithHorizontalLongestStreakOfAI();

                insertToken(emptySpots[spot], 2);
                return true;
            }
            else return false;
        }//insertTokenByAI

        public void clearRaster()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    raster[i, j] = 0;
                }
            }
        }//clearRaster

        public bool isColumnFull(int column)
        {
            if (raster[rows - 1, column] != 0)
            {
                return true;
            }
            else { return false; }
        }//isColumnFull

        public bool isCurrentGameWon()
        {
            return isWon();
        }//isCurrentGameWon

        public bool checkIfWon(int column, int player)
        {
            if (player == getPlayerAtTurn())
            {
                if (insertToken(column, player))
                {
                    if (isWon())
                    {
                        incrementScorePlayer(getCurrentGameWonPlayer());
                    }
                    return true;
                }
                else return false;
            }
            else return false;
        }//insertToken

        public void incrementScorePlayer(int player)
        {
            switch (player)
            {
                case 1:
                    scorePlayer1++;
                    break;

                case 2:
                    scorePlayer2++;
                    break;
            }
        }//incrementScorePlayer
        #endregion
	}
}