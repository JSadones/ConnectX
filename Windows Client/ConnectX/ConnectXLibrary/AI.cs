using System;
using System.Collections.Generic;

namespace ConnectXLibrary
{
    public class AI
    {
        #region State
        static int MaxDepth = 8;
	    static float WinRevenue = 1f;
	    static float LoseRevenue = -1f;
	    static float UncertainRevenue = 0f;
	    ConnectX board;
        #endregion

        #region Constructor
        public AI(ConnectX board) {
		    this.board = board;
	    }//AI
        #endregion

        #region Methods
        public int makeTurn(int depth) {
            MaxDepth = depth;
		    double maxValue = 2.0 * Int32.MinValue;
		    int move = 0;

		    for (int column = 0; column < board.getColumns(); column++) {
			    if (!board.isColumnFull(column)) {
				    double value = moveValue(column);
				    if (value > maxValue) {
					    maxValue = value;
					    move = column;
					    if (value == WinRevenue) {
						    break;
					    }
				    }
			    }
		    }
		    return move;
	    }//makeTurn

	    private double moveValue(int column) {
            int row = board.getLowestAvailableRowInColumn(column);
            board.insertToken(column, row, board.getPlayerAtTurn());
		    double val = alphabeta(MaxDepth, Int32.MinValue, Int32.MaxValue, false,  column,  row);
		    board.undoMoveAI(column);
		    return val;
	    }//moveValue

	    private double alphabeta(int depth, double alpha, double beta, bool maximizingPlayer, int column_par, int row_par ) {
      //      bool hasWinner = board.isCurrentGameWon(column_par, row_par, board.getPlayerAtTurn());
            bool hasWinner = board.hasWinner();
		   
            if (depth == 0 || hasWinner) {
			    double score = 0;

			    if (hasWinner) score = board.playerIsWinner() ? LoseRevenue : WinRevenue;
                else score = UncertainRevenue;

			    return score / (MaxDepth - depth + 1);
		    }

		    if (maximizingPlayer) {
			    for (int column = 0; column < board.getColumns(); column++) {
				    if (!board.isColumnFull(column)) {
                        int row = board.getLowestAvailableRowInColumn(column);
                        board.insertToken(column, row, 2);
					    alpha = Math.Max(alpha, alphabeta(depth - 1, alpha, beta, false, column, row));
					    board.undoMoveAI(column);
					    if (beta <= alpha) break;
				    }
			    }
			    return alpha;
		    } else {
			    for (int column = 0; column < board.getColumns(); column++) {
				    if (!board.isColumnFull(column)) {
                        int row = board.getLowestAvailableRowInColumn(column);
                        board.insertToken(column, row, 1);
					    beta = Math.Min(beta, alphabeta(depth - 1, alpha, beta, true, column, row));
					    board.undoMovePlayer(column);
					    if (beta <= alpha) break;
				    }
			    }
			    return beta;
		    }
        }//alphabeta

        public int chooseRandomSpot()
        {
            List<byte> emptySpots;
            Random rnd = new Random();
            emptySpots = getListOfAvailableColumns();
            int length = emptySpots.Count - 1;
            int spot = rnd.Next(0, length);

            return emptySpots[spot];
        }//chooseRandomSpot

        private List<byte> getListOfAvailableColumns()
        {
            List<byte> empySpots = new List<byte>();
            int[,] raster = board.getRaster();

            for (byte i = 0; i < board.getColumns(); i++)
            {
                if (raster[i, board.getRows() - 1] == 0) empySpots.Add(i);
            }
            return empySpots;
        }//getListOfAvailableColumns
        #endregion
    }
}