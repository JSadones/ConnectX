using System;
using System.Linq;
using System.Collections.Generic;

namespace ConnectXLibrary
{
    public class ConnectX
    {
        #region State
        int[,] raster;
        private int rows, columns, streakToWin, playerAtTurn, scorePlayer1 = 0, scorePlayer2 = 0, difficulty, counterLeft = 0, counterRight = 0;
		private const int DefaultRows = 6, DefaultColumns = 7, DefaultStreak = 4;
        private const bool  DefaultMP = true;
        private bool multiplayer;


        public byte NOBODY = 0;
	    public byte PLAYER = 1;
	    public byte AI = 2;
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
            this.multiplayer = multiplayer;
            this.columnCounts = new int[columns];

            playerAtTurn = 1;
            raster = new int[rows, columns];
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
        }//getWinnerOfLastSession

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
        public bool isTie()
        {
            for (int column = 0; column < columns; column++)
            {
                if (raster[rows - 1, column] == 0) return false;
            }
            return true;
        }//isTie

        public void clear()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    raster[row, column] = 0;
                }
            }
        }//clear

        public bool isInitializedWithZeros()
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
        }//isInitializedWithZeros

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

        public bool isColumnFull(int column)
        {
            return raster[rows - 1, column] != 0;
        }//isColumnFull


        //===Winning algorithm methods===
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
                    //Check vertical
                    if (stepRow == -1 && stepColumn == 0)
                    {
                        if (raster[row + i * stepRow, column + i * stepColumn] == getPlayerAtTurn()) counterLeft++;
                        else return false;
                    }

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
                }
                catch(IndexOutOfRangeException)
                {
                    return false;
                }

                if (counterLeft + counterRight == streakToWin - 1)
                {
                    return true;
                }
            }
            return false;
        }//isStreakReachedFromCoordinateInDirection

        public bool isCurrentGameWon (int row, int column)
        {
            //-1  0   --  Check vertical down
            //0   1   --  Check horizontal right
            //0  -1   --  Check horizontal left
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

            //Check vertical
            if (isStreakReachedFromCoordinateInDirection(row, column, -1, 0))
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
            clear();
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


        //===Methodes voor AI classe te laten werken, AFBLIJVEN PLS===
        /**
	     * Puts AI disc into the given column. If the
	     * move is invalid, the board remains
	     * unchanged.
	     * 
	     * @param column
	     * @return
	     */
        public bool makeMoveAI(int column)
        {
            return makeMove(column, false);
        }//makeMoveAI

        /**
	     * Puts player disc into the given column. If
	     * the move is invalid, the board remains
	     * unchanged.
	     * 
	     * @param column
	     * @return True if valid move, false
	     *         otherwise.
	     */
        public bool makeMovePlayer(int column)
        {
            return makeMove(column, true);
        }//makeMovePlayer

        /**
         * Removes AI disc from the given column. If
         * the move is invalid (the top disc is of
         * another player or there are no discs in
         * this column) the board remains unchanged.
         * 
         * @param column
         * @return True if action was successful
         */
        public bool undoMoveAI(int column)
        {
            return undoMove(column, false);
        }//undoMoveAI

        /**
         * Removes Player disc from the given column.
         * If the move is invalid (the top disc is of
         * another player or there are no discs in
         * this column) the board remains unchanged.
         * 
         * @param column
         * @return True if action was successful
         */
        public bool undoMovePlayer(int column)
        {
            return undoMove(column, true);
        }//undoMovePlayer

        /**
         * Returns if the player has won.
         * 
         * @return
         */
        public bool playerIsWinner()
        {
            //return isWon() != 1;
            return getWinner() == 1;
        }//playerIsWinner

        public bool hasWinner()
        {
            //return isWon() != 0;
            return getWinner() != 0;
        }//hasWinner





        //FOUTEN WAARSCHIJNLIJK HIER 
        // |     |
        // |     |
        // |     |
        // V     V
        //
        private bool makeMove(int column, bool player)
        {
            if (columnCounts[column] < rows - 1)
            {
                byte sign = player ? PLAYER : AI;
                if (column == 0) raster[column, columnCounts[column]++] = sign;
                else if (column > 0) raster[column - 1, columnCounts[column]++] = sign;
                
                return true;
            }
            return false;
        }//makeMove

        private bool undoMove(int column, bool player)
        {
            if (columnCounts[column] > 0)
            {
                byte sign = player ? PLAYER : AI;
                if (column == 0)
                {
                    if (raster[column, columnCounts[column] - 1] == sign)
                    {
                        raster[column, columnCounts[column] - 1] = NOBODY;
                        columnCounts[column]--;
                        return true;
                    }
                }
                else if (column > 0)
                {
                    if (raster[column - 1, columnCounts[column] - 1] == sign)
                    {
                        raster[column - 1, columnCounts[column] - 1] = NOBODY;
                        columnCounts[column]--;
                        return true;
                    }
                }
            }
            return false;
        }//undoMove

        /**
	     * Returns the winner of the current board
	     * state.
	     * 
	     * @return Board.NOBODY if there is no winner.
	     *         Board.AI if the AI is the winner.
	     *         Board.PLAYER if the player is the
	     *         winner.
	     */
        private byte getWinner()
        {
            for (int x = 0; x < columns - 1; x++)
            {
                for (int y = 0; y <= rows - streakToWin; y++)
                {
                    bool playerWin = true;
                    bool aiWin = true;
                    for (int o = 0; o < streakToWin; o++)
                    {
                        if (playerWin && raster[x, y + o] != PLAYER)
                        {
                            playerWin = false;
                        }
                        if (aiWin && raster[x, y + o] != AI)
                        {
                            aiWin = false;
                        }
                    }
                    if (playerWin)
                    {
                        return PLAYER;
                    }
                    else if (aiWin)
                    {
                        return AI;
                    }
                }
            }

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x <= columns - 1 - streakToWin; x++)
                {
                    bool playerWin = true;
                    bool aiWin = true;
                    for (int o = 0; o < streakToWin; o++)
                    {
                        if (playerWin && raster[x + o, y] != PLAYER)
                        {
                            playerWin = false;
                        }
                        if (aiWin && raster[x + o, y] != AI)
                        {
                            aiWin = false;
                        }
                    }
                    if (playerWin)
                    {
                        return PLAYER;
                    }
                    else if (aiWin)
                    {
                        return AI;
                    }
                }
            }

            for (int x = 0; x <= columns - 1 - streakToWin; x++)
            {
                for (int y = 0; y <= rows - streakToWin; y++)
                {
                    bool playerWin = true;
                    bool aiWin = true;
                    for (int o = 0; o < streakToWin; o++)
                    {
                        if (playerWin
                                && raster[x + o, y + o] != PLAYER)
                        {
                            playerWin = false;
                        }
                        if (aiWin
                                && raster[x + o, y + o] != AI)
                        {
                            aiWin = false;
                        }
                    }
                    if (playerWin)
                    {
                        return PLAYER;
                    }
                    else if (aiWin)
                    {
                        return AI;
                    }
                }
            }

            for (int x = columns - 2; x >= streakToWin - 1; x--)
            {
                for (int y = 0; y <= rows - streakToWin; y++)
                {
                    bool playerWin = true;
                    bool aiWin = true;
                    for (int o = 0; o < streakToWin; o++)
                    {
                        if (playerWin && raster[x - o, y + o] != PLAYER)
                        {
                            playerWin = false;
                        }
                        if (aiWin
                                && raster[x - o, y + o] != AI)
                        {
                            aiWin = false;
                        }
                    }
                    if (playerWin)
                    {
                        return PLAYER;
                    }
                    else if (aiWin)
                    {
                        return AI;
                    }
                }
            }
            return NOBODY;
        }//getWinner





        //IGNORE PLS
        public byte isWon()
        {
            if (isWonVertical() == 1 || isWonHorizontal() == 1 || isWonDiagonal45() == 1 || isWonDiagonal135() == 1)
            {
                return PLAYER;
            }
            else if (isWonVertical() == 2 || isWonHorizontal() == 2 || isWonDiagonal45() == 2 || isWonDiagonal135() == 2)
            {
                return AI;
            }
            else return NOBODY;
        }//isWon

        public int isWonVertical()
        {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;

            for (int i = 0; i < columns; i++)
            {
                int j = 0;
                counterPlayer1 = 0;
                counterPlayer2 = 0;
                while (j < rows && raster[j, i] != 0)
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

                    if (counterPlayer1 == streakToWin)
                    {
                        return 1;
                    }
                    if (counterPlayer2 == streakToWin)
                    {
                        return 2;
                    }
                    j++;
                }
            }
            return 0;
        }//isWonVertical

        public int isWonHorizontal()
        {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;

            for (int i = 0; i < rows; i++)
            {
                counterPlayer1 = 0;
                counterPlayer2 = 0;
                for (int j = 0; j < columns; j++)
                {

                    if (raster[i, j] == 1)
                    {
                        counterPlayer1++;
                    }
                    else counterPlayer1 = 0;

                    if (raster[i, j] == 2)
                    {
                        counterPlayer2++;
                    }
                    else counterPlayer2 = 0;

                    if (counterPlayer1 == streakToWin)
                    {
                        return 1;
                    }

                    if (counterPlayer2 == streakToWin)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }//isWonHorizontal

        public int isWonDiagonal45()
        {
            for (int i = columns - 1; i >= 0; i--)
            {
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

        private int getStreakWinnerDiagonal135(int counterRow, int counterColumn)
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
        #endregion
    }
}