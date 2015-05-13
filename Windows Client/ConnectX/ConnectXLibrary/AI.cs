using System;
using System.Collections.Generic;

namespace ConnectXLibrary
{
    class AI
    {
        #region State
        static int MAX_DEPTH = 8;
	    static float WIN_REVENUE = 1f;
	    static float LOSE_REVENUE = -1f;
	    static float UNCERTAIN_REVENUE = 0f;
	    ConnectX board;
        #endregion

        #region Constructor
        public AI(ConnectX board) {
		    this.board = board;
	    }//AI
        #endregion

        #region Methods
        public int makeTurn() {
		    double maxValue = 2.0 * Int32.MinValue;
		    int move = 0;

		    for (int column = 0; column < board.getColumns(); column++) {
			    if (board.isValidMove(column)) {
				    double value = moveValue(column);
				    if (value > maxValue) {
					    maxValue = value;
					    move = column;
					    if (value == WIN_REVENUE) {
						    break;
					    }
				    }
			    }
		    }
		    //board.makeMoveAI(move);
		    return move;
	    }//makeTurn

	    private double moveValue(int column) {
		    board.makeMoveAI(column);
		    double val = alphabeta(MAX_DEPTH, Int32.MinValue, Int32.MaxValue, false);
		    board.undoMoveAI(column);
		    return val;
	    }//moveValue

	    private double alphabeta(int depth, double alpha, double beta, bool maximizingPlayer) {
		    bool hasWinner = board.hasWinner();
		    if (depth == 0 || hasWinner) {
			    double score = 0;
			    if (hasWinner) {
				    score = board.playerIsWinner() ? LOSE_REVENUE : WIN_REVENUE;
			    } else {
				    score = UNCERTAIN_REVENUE;
			    }
			    return score
			            / (MAX_DEPTH - depth + 1);
		    }

		    if (maximizingPlayer) {
			    for (int column = 0; column < board.getColumns(); column++) {
				    if (board.isValidMove(column)) {
					    board.makeMoveAI(column);
					    alpha = Math.Max(alpha, alphabeta(depth - 1, alpha, beta, false));
					    board.undoMoveAI(column);
					    if (beta <= alpha) {
						    break;
					    }
				    }
			    }
			    return alpha;
		    } else {
			    for (int column = 0; column < board.getColumns(); column++) {
				    if (board.isValidMove(column)) {
					    board.makeMovePlayer(column);
					    beta = Math.Min(beta, alphabeta(depth - 1, alpha, beta, true));
					    board.undoMovePlayer(column);
					    if (beta <= alpha) {
						    break;
					    }
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
            int length = emptySpots.Count;
            int spot = rnd.Next(0, length);

            return spot;
        }//chooseRandomSpot

        private List<byte> getListOfAvailableColumns()
        {
            List<byte> empySpots = new List<byte>();
            int[,] raster = board.getRaster();

            for (byte i = 0; i < board.getColumns(); i++)
            {
                if (raster[board.getRows() - 1, i] == 0)
                {
                    empySpots.Add(i);
                }
            }
            return empySpots;
        }//getListOfAvailableColumns
        #endregion
    }
}