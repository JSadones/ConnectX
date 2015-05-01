﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace ConnectXLibrary
{
    public class ConnectX
    {
        #region State
        int[,] raster;
        private int rows, columns, streakToWin, playerAtTurn, winningPlayer, scorePlayer1 = 0, scorePlayer2 = 0, counterPlayer1, counterPlayer2, counter;
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

        public int getWinnerOfLastGame()
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

                if (counterPlayer1 == streakToWin)
                {
                    return 1;
                }

                if (counterPlayer2 == streakToWin)
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

                if (counterPlayer1 == streakToWin)
                {
                    return 1;
                }

                else if (counterPlayer2 == streakToWin)
                {
                    return 2;
                }

            }
            return 0;
        }//getStreakWinnerDiagonal45

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
        
        public int getColumnVerticalLongestStreakOfAI()
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
                    else resetStreakCounter();
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

        public int getRowHorizontalLongestStreakOfAI()
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
                    else resetStreakCounter();
                    j++;

                    if (counter > longestStreak)
                    {
                        longestStreak = counter;
                        longestStreakRow = i;
                    }

                    if (counter == streakToWin)
                    {
                        return counter;
                    }
                }
            }
            return 0;
        }//getRowWithHorizontalLongestStreakOfAI

        public Coord getCoordinateDiagonal45LongestStreakOfAI()
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

        public Coord getCoordinateDiagonal135LongestStreakOfAI()
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

        //public int getStreakDiagonal(int start, int type, int step)
        //{
        //    for (int i = start; diagonalIterationCondition(type, i); i += step)
        //    {
        //        int winner;

        //        switch (type)
        //        {
        //            case 1: winner = getStreakWinnerDiagonal45(0, i); break;

        //            case 2: winner = getStreakWinnerDiagonal45(i, 0); break;

        //            case 3: winner = getStreakWinnerDiagonal135(0, i); break;

        //            case 4: winner = getStreakWinnerDiagonal135(i, columns - 1); break;

        //            default: winner = 0; break;
        //        }
        //        if (1 <= winner && winner <= 2)
        //        {
        //            return winner;
        //        }
        //    }
        //    return 0;
        //}//getStreakDiagonal
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

        //public int streakCounter(int i, int j, int player)
        //{
        //    if (raster[i, j] == player)
        //    {
        //        if (player == 1)
        //        {
        //            int tmp = j;
        //            counterPlayer2 = 0;
        //            counterPlayer1++;
        //            return counterPlayer1;
        //        }
        //        else if (player == 2)
        //        {
        //            counterPlayer2 = 0;
        //            return ++counterPlayer2;
        //        }
        //    }
        //    else
        //    {
        //        counterPlayer1 = 0;
        //        counterPlayer2 = 0;
        //    }
        //    return 0;
        //}// streakCounter
        
        //public int isWonVertical()
        //{
        //    int winner;

        //    for (int i = 0; i < columns; i++)
        //    {
        //        resetCounter();
        //        for (int j = 0; j < rows; j++)
        //        {
        //            winner = winnerCalculation(j, i);
        //            if (winner != 0) return winner;
        //        }
        //    }
        //    winner = 0;
        //    return winner;
        //}//isWonVertical

        //public int isWonHorizontal()
        //{
        //    int winner;

        //    for (int i = 0; i < rows; i++)
        //    {
        //        resetCounter();
        //        for (int j = 0; j < columns; j++)
        //        {
        //            winner = winnerCalculation(i, j);
        //            if (winner != 0) return winner;
        //        }
        //    }

        //    winner = 0;
        //    return winner;
        //}//isWonHorizontal

        //public int isWonDiagonal()
        //{
        //    if ((getStreakDiagonal(columns - 1, 1, -1) != 0)) return (getStreakDiagonal(columns - 1, 1, -1));
        //    if ((getStreakDiagonal(1, 2, 1) != 0)) return (getStreakDiagonal(1, 2, 1));
        //    if ((getStreakDiagonal(0, 3, 1) != 0)) return (getStreakDiagonal(0, 3, 1));
        //    if ((getStreakDiagonal(1, 4, 1) != 0)) return (getStreakDiagonal(1, 4, 1));
        //    else return 0;
        //}//isWonDiagonal

        //public bool diagonalIterationCondition(int type, int i)
        //{
        //    if (type == 1)
        //    {
        //        return (i >= 0);

        //    }
        //    else if (type == 2)
        //    {
        //        return (i < rows);

        //    }
        //    else if (type == 3)
        //    {
        //        return (i < columns);

        //    }
        //    else if (type == 4)
        //    {
        //        return (i < rows);

        //    }
        //    else
        //    {
        //        return false;
        //    }
        //} //diagonalIterationCondition

        //public int winnerCalculation(int i, int j)
        //{
        //    if (streakCounter(i, j, 1) == streakToWin) return 1;
        //    else if (streakCounter(i, j, 2) == streakToWin) return 2;
        //    else return 0;
        //}// winnerCalculation
        private bool IsLinearMatch(int row, int column, int stepRow, int stepColumn)
        {
            /* Get the value of the start position. */
            //int startValue = raster[x, y];
            int counter = 0;

            /* Confirm the two values after it match. */
            for (int i = 1; i < streakToWin; i++)
            {
                try
                {
                    if (stepRow == 0 && stepColumn == 1) System.Diagnostics.Debug.WriteLine("---HORIZONTAL RECHTS---");
                    if (stepRow == 0 && stepColumn == -1) System.Diagnostics.Debug.WriteLine("---HORIZONTAL LINKS---");
                    if (stepRow == -1 && stepColumn == 0) System.Diagnostics.Debug.WriteLine("---VERTICAL DOWN---");
                    if (stepRow == -1 && stepColumn == 1) System.Diagnostics.Debug.WriteLine("---DIAGONAL UP---");
                    if (stepRow == -1 && stepColumn == -1) System.Diagnostics.Debug.WriteLine("---DIAGONAL DOWN---");

                    System.Diagnostics.Debug.WriteLine("x : " + column);
                    System.Diagnostics.Debug.WriteLine("y : " + row);
                    System.Diagnostics.Debug.WriteLine("stepX : " + stepColumn);
                    System.Diagnostics.Debug.WriteLine("stepY : " + stepRow);
                    System.Diagnostics.Debug.WriteLine("---------------------------");
                    System.Diagnostics.Debug.WriteLine(column + " + " + i + " * " + stepColumn);
                    System.Diagnostics.Debug.WriteLine(row + " + " + i + " * " + stepRow);
                    System.Diagnostics.Debug.Write("Coords : ");

                    System.Diagnostics.Debug.Write(row + i * stepRow);
                    System.Diagnostics.Debug.Write(" ");
                    System.Diagnostics.Debug.WriteLine(column + i * stepColumn);

                    if (raster[row + i * stepRow, column + i * stepColumn] == getPlayerAtTurn())
                    {
                        counter++;
                        System.Diagnostics.Debug.WriteLine("counter +1");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("counter reset");
                        return false;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    System.Diagnostics.Debug.WriteLine("out of range");
                    System.Diagnostics.Debug.WriteLine("");
                    return false;
                }

                if (counter == streakToWin - 1) 
                {
                    System.Diagnostics.Debug.WriteLine("***********streak got***********");
                    return true;
                }
            }
            return false;
            /* If we got here, then they all match! */
        }

        public bool IsLineStartingAt(int x, int y)
        {
            if(IsLinearMatch(x, y, 0, 1) || IsLinearMatch(x, y, 0, -1) || IsLinearMatch(x, y, -1, 0) || IsLinearMatch(x, y, -1,  1) || IsLinearMatch(x, y, -1, -1))
            {
                return true;
            }
            return false;
        }


        public bool gameExists()
        {
            if (raster != null)
            {
                return true;
            }
            return false;
        }//exists

        private void resetCounter()
        {
            counterPlayer1 = 0;
            counterPlayer2 = 0;
        }//resetCounter

        private void resetStreakCounter()
        {
            counter = 0;
        }//resetStreakCounter

        //public bool isWon()
        //{
        //    if (isWonVertical() == 1 || isWonHorizontal() == 1 || isWonDiagonal() == 1)
        //    {
        //        winningPlayer = 1;
        //        return true;
        //    }
        //    else if (isWonVertical() == 2 || isWonHorizontal() == 2 || isWonDiagonal() == 2)
        //    {
        //        winningPlayer = 2;
        //        return true;
        //    }
        //    return false;
        //}//isWon

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

        //public bool isCurrentGameWon()
        //{
        //    return isWon();
        //}//isCurrentGameWon

        //public bool checkIfWon(int column, int player)
        //{
        //    if (IsLineStartingAt())
        //    {
        //        incrementScorePlayer(getWinnerOfLastGame());
        //        return true;
        //    }
        //    return false;
        //}//insertToken

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